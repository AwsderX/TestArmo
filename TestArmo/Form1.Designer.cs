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
            buttonPath = new Button();
            labelPath = new Label();
            buttonSearchStart = new Button();
            buttonDel = new Button();
            textBoxSearch = new TextBox();
            buttonPause = new Button();
            label1 = new Label();
            doubleBufferedTreeView1 = new DoubleBufferedTreeView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
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
            buttonDel.Click += buttonDel_Click;
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
            buttonPause.Click += buttonPause_Click;
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
            // doubleBufferedTreeView1
            // 
            doubleBufferedTreeView1.Location = new Point(12, 12);
            doubleBufferedTreeView1.Name = "doubleBufferedTreeView1";
            doubleBufferedTreeView1.Size = new Size(1018, 662);
            doubleBufferedTreeView1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(1036, 265);
            label2.Name = "label2";
            label2.Size = new Size(52, 21);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(1036, 296);
            label3.Name = "label3";
            label3.Size = new Size(52, 21);
            label3.TabIndex = 5;
            label3.Text = "label2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(1036, 333);
            label4.Name = "label4";
            label4.Size = new Size(52, 21);
            label4.TabIndex = 5;
            label4.Text = "label2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1352, 686);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(doubleBufferedTreeView1);
            Controls.Add(textBoxSearch);
            Controls.Add(label1);
            Controls.Add(labelPath);
            Controls.Add(buttonPause);
            Controls.Add(buttonDel);
            Controls.Add(buttonSearchStart);
            Controls.Add(buttonPath);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonPath;
        private Label labelPath;
        private Button buttonSearchStart;
        private Button buttonDel;
        private TextBox textBoxSearch;
        private Button buttonPause;
        private Label label1;
        private DoubleBufferedTreeView doubleBufferedTreeView1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
