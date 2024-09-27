using System.Collections.Concurrent;
using System.IO;
using System.Management;
using System.Text.RegularExpressions;

namespace TestArmo
{
    public partial class Form1 : Form
    {
        ManualResetEvent pauseEvent = new ManualResetEvent(true);
        CancellationTokenSource cts = new CancellationTokenSource();

        Task searchTask;
        bool hddDisk = false;
        string selectedPath = string.Empty;
        string searchPattern = string.Empty;
        ConcurrentQueue<string> directoriesQueue = new();
        System.Windows.Forms.Timer queueMonitorTimer;

        DateTime lastQueueUpdateTime;
        const int IdleThresholdInSeconds = 2;
        public Form1()
        {
            InitializeComponent();
            queueMonitorTimer = new System.Windows.Forms.Timer();
            queueMonitorTimer.Interval = 200;
            queueMonitorTimer.Tick += QueueMonitorTimer_Tick;
        }

        private void TypeDisk(string path)
        {
            DriveInfo drive = new DriveInfo(Path.GetPathRoot(path));
            string physicalDeviceId = GetPhysicalDiskIdForLogicalDrive(drive.Name.Substring(0, 2));
            string deviceNumber = physicalDeviceId.Replace(@"\\.\PHYSICALDRIVE", string.Empty);

            ManagementScope scope = new ManagementScope(@"\\.\root\microsoft\windows\storage");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM MSFT_PhysicalDisk");
            scope.Connect();
            searcher.Scope = scope;

            foreach (ManagementObject queryObj in searcher.Get())
            {
                if (queryObj["DeviceID"].ToString() == deviceNumber)
                {
                    switch (Convert.ToInt16(queryObj["MediaType"]))
                    {
                        case 3: // HDD
                            hddDisk = true;
                            break;
                        default:
                            hddDisk = false;
                            break;
                    }
                    break;
                }
            }
            searcher.Dispose();
        }
        private string GetPhysicalDiskIdForLogicalDrive(string logicalDriveLetter)
        {
            string deviceId = null;
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                "ASSOCIATORS OF {Win32_LogicalDisk.DeviceID='" + logicalDriveLetter + "'} WHERE AssocClass=Win32_LogicalDiskToPartition"))
            {
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string partitionDeviceId = queryObj["DeviceID"].ToString();

                    using (ManagementObjectSearcher diskSearcher = new ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partitionDeviceId + "'} WHERE AssocClass=Win32_DiskDriveToDiskPartition"))
                    {
                        foreach (ManagementObject disk in diskSearcher.Get())
                        {
                            deviceId = disk["DeviceID"].ToString();
                            return deviceId;
                        }
                    }
                }
            }

            return deviceId;
        }
        private void buttonSearchStart_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
            cts = new CancellationTokenSource();
            pauseEvent.Set();
            if (selectedPath != string.Empty)
            {
                TypeDisk(selectedPath);
                searchPattern = textBoxSearch.Text;
                if (hddDisk)
                {
                    searchTask = Task.Run(() => SearchFilesHDD(selectedPath, cts.Token));
                    //Thread mainThread = new Thread(() => SearchFilesHDD(selectedPath));
                    //mainThread.Start();
                    //mainThread.Join();
                }
                else
                {
                    searchTask = Task.Run(() => SearchFiles(selectedPath, cts.Token));
                }
                lastQueueUpdateTime = DateTime.Now; 
                queueMonitorTimer.Start();
                label1.Text = "����� �������";

            }
        }
        private async Task SearchFiles(string directoryPath, CancellationToken token)
        {
            Regex regex = new Regex(searchPattern, RegexOptions.IgnoreCase);
            try
            {
                foreach (string file in Directory.GetFiles(directoryPath))
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    pauseEvent.WaitOne();

                    string str = Path.GetFileName(file);
                    if (regex.IsMatch(str))
                    {
                        directoriesQueue.Enqueue(file);
                    }
                }
                foreach (string dir in Directory.GetDirectories(directoryPath))
                {
                    if (token.IsCancellationRequested)
                    {
                        return; // ��������� ������, ���� ��� ������ �� ������
                    }
                    await Task.Delay(1);
                    // ����������� ����� ��� ��������� �������������
                    SearchFiles(dir, token);
                }
            }
            catch (UnauthorizedAccessException)
            {
                lock (Console.Out)
                {
                    Console.WriteLine($"��� ������� � ����������: {directoryPath}");
                }
            }
        }

        private void buttonPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedPath = folderBrowserDialog.SelectedPath;
                    labelPath.Text = selectedPath;
                }
            }
        }
        private void SearchFilesHDD(string directoryPath, CancellationToken token)
        {
            Regex regex = new Regex(searchPattern, RegexOptions.IgnoreCase);
            foreach (string file in Directory.GetFiles(directoryPath))
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                pauseEvent.WaitOne();
                string str = Path.GetFileName(file);
                if (regex.IsMatch(str))
                {
                    directoriesQueue.Enqueue(file);
                }
            }
            foreach (string dir in Directory.GetDirectories(directoryPath))
            {
                try
                {
                    SearchFilesHDD(dir, cts.Token);
                }
                catch { }
            }
        }
        private void QueueMonitorTimer_Tick(object sender, EventArgs e)
        {
            bool queueUpdated = false;

            while (!directoriesQueue.IsEmpty)
            {
                if (directoriesQueue.TryDequeue(out string filePath))
                {
                    treeView1.SuspendLayout();
                    AddFileToTreeView(filePath);
                    treeView1.ResumeLayout();

                    lastQueueUpdateTime = DateTime.Now;
                    queueUpdated = true;
                }
            }

            if (!queueUpdated && (DateTime.Now - lastQueueUpdateTime).TotalSeconds >= IdleThresholdInSeconds)
            {
                queueMonitorTimer.Stop(); 
                label1.Text = "����� ��������";
            }
        }
        private void AddFileToTreeView(string filePath)
        {
            string[] pathParts = filePath.Split(Path.DirectorySeparatorChar);
            TreeNode currentNode = null;
            for (int i = 0; i < pathParts.Length; i++)
            {
                string currentPart = pathParts[i];

                if (i == 0)
                {
                    currentNode = FindOrCreateNode(treeView1.Nodes, currentPart);
                }
                else if (currentNode != null)
                {
                    currentNode = FindOrCreateNode(currentNode.Nodes, currentPart);
                }
            }
        }

        private TreeNode FindOrCreateNode(TreeNodeCollection nodes, string nodeName)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text == nodeName)
                {
                    return node;
                }
            }
            TreeNode newNode = new TreeNode(nodeName);
            nodes.Add(newNode);
            return newNode;
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            pauseEvent.Reset();
            label1.Text = "�����";
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
