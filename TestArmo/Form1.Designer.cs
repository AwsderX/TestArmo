namespace TestArmo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            treeView1 = new TreeView();
            buttonPath = new Button();
            labelPath = new Label();
            buttonSearchStart = new Button();
            buttonDel = new Button();
            textBoxSearch = new TextBox();
            buttonPause = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 12);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(1003, 662);
            treeView1.TabIndex = 0;
            // 
            // buttonPath
            // 
            buttonPath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonPath.Location = new Point(1036, 50);
            buttonPath.Name = "buttonPath";
            buttonPath.Size = new Size(174, 41);
            buttonPath.TabIndex = 1;
            buttonPath.Text = "Выбрать Путь";
            buttonPath.UseVisualStyleBackColor = true;
            buttonPath.Click += buttonPath_Click;
            // 
            // labelPath
            // 
            labelPath.AutoSize = true;
            labelPath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelPath.Location = new Point(1036, 12);
            labelPath.Name = "labelPath";
            labelPath.Size = new Size(52, 21);
            labelPath.TabIndex = 2;
            labelPath.Text = "label1";
            // 
            // buttonSearchStart
            // 
            buttonSearchStart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSearchStart.Location = new Point(1036, 132);
            buttonSearchStart.Name = "buttonSearchStart";
            buttonSearchStart.Size = new Size(174, 41);
            buttonSearchStart.TabIndex = 1;
            buttonSearchStart.Text = "Начать поиск";
            buttonSearchStart.UseVisualStyleBackColor = true;
            buttonSearchStart.Click += buttonSearchStart_Click;
            // 
            // buttonDel
            // 
            buttonDel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonDel.Location = new Point(1036, 633);
            buttonDel.Name = "buttonDel";
            buttonDel.Size = new Size(174, 41);
            buttonDel.TabIndex = 1;
            buttonDel.Text = "Сбросить";
            buttonDel.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxSearch.Location = new Point(1036, 97);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(174, 29);
            textBoxSearch.TabIndex = 3;
            // 
            // buttonPause
            // 
            buttonPause.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonPause.Location = new Point(1036, 179);
            buttonPause.Name = "buttonPause";
            buttonPause.Size = new Size(174, 41);
            buttonPause.TabIndex = 1;
            buttonPause.Text = "Пауза";
            buttonPause.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(1036, 234);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1222, 686);
            Controls.Add(textBoxSearch);
            Controls.Add(label1);
            Controls.Add(labelPath);
            Controls.Add(buttonPause);
            Controls.Add(buttonDel);
            Controls.Add(buttonSearchStart);
            Controls.Add(buttonPath);
            Controls.Add(treeView1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Button buttonPath;
        private Label labelPath;
        private Button buttonSearchStart;
        private Button buttonDel;
        private TextBox textBoxSearch;
        private Button buttonPause;
        private Label label1;
    }
}
