namespace lb30
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            hostTxtBox = new TextBox();
            usernameTxtBox = new TextBox();
            passwordTxtBox = new TextBox();
            connectBtn = new Button();
            label4 = new Label();
            filePathTxtBox = new TextBox();
            browseFileBtn = new Button();
            uploadBtn = new Button();
            filesTreeView = new TreeView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(21, 29);
            label1.Name = "label1";
            label1.Size = new Size(53, 28);
            label1.TabIndex = 0;
            label1.Text = "Host";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(21, 68);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(21, 104);
            label3.Name = "label3";
            label3.Size = new Size(93, 28);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // hostTxtBox
            // 
            hostTxtBox.Location = new Point(198, 33);
            hostTxtBox.Name = "hostTxtBox";
            hostTxtBox.Size = new Size(319, 27);
            hostTxtBox.TabIndex = 3;
            hostTxtBox.Text = "ftp://192.168.0.104";
            // 
            // usernameTxtBox
            // 
            usernameTxtBox.Location = new Point(198, 72);
            usernameTxtBox.Name = "usernameTxtBox";
            usernameTxtBox.Size = new Size(319, 27);
            usernameTxtBox.TabIndex = 4;
            usernameTxtBox.Text = "user1";
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Location = new Point(198, 116);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.Size = new Size(319, 27);
            passwordTxtBox.TabIndex = 5;
            // 
            // connectBtn
            // 
            connectBtn.Location = new Point(543, 27);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(149, 116);
            connectBtn.TabIndex = 6;
            connectBtn.Text = "Connect n recieve files";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.Click += connectBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(81, 495);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 8;
            label4.Text = "Путь файлу";
            // 
            // filePathTxtBox
            // 
            filePathTxtBox.Location = new Point(246, 494);
            filePathTxtBox.Name = "filePathTxtBox";
            filePathTxtBox.Size = new Size(319, 27);
            filePathTxtBox.TabIndex = 9;
            // 
            // browseFileBtn
            // 
            browseFileBtn.Location = new Point(591, 480);
            browseFileBtn.Name = "browseFileBtn";
            browseFileBtn.Size = new Size(95, 51);
            browseFileBtn.TabIndex = 10;
            browseFileBtn.Text = "Browse";
            browseFileBtn.UseVisualStyleBackColor = true;
            // 
            // uploadBtn
            // 
            uploadBtn.Location = new Point(21, 165);
            uploadBtn.Name = "uploadBtn";
            uploadBtn.Size = new Size(113, 51);
            uploadBtn.TabIndex = 11;
            uploadBtn.Text = "Upload file";
            uploadBtn.UseVisualStyleBackColor = true;
            uploadBtn.Click += uploadBtn_Click;
            // 
            // filesTreeView
            // 
            filesTreeView.Location = new Point(811, 33);
            filesTreeView.Name = "filesTreeView";
            filesTreeView.Size = new Size(480, 379);
            filesTreeView.TabIndex = 12;
            filesTreeView.BeforeExpand += filesTreeView_BeforeExpand;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 684);
            Controls.Add(filesTreeView);
            Controls.Add(uploadBtn);
            Controls.Add(browseFileBtn);
            Controls.Add(filePathTxtBox);
            Controls.Add(label4);
            Controls.Add(connectBtn);
            Controls.Add(passwordTxtBox);
            Controls.Add(usernameTxtBox);
            Controls.Add(hostTxtBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private void FilesTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox hostTxtBox;
        private TextBox usernameTxtBox;
        private TextBox passwordTxtBox;
        private Button connectBtn;
        private Label label4;
        private TextBox filePathTxtBox;
        private Button browseFileBtn;
        private Button uploadBtn;
        private TreeView filesTreeView;
    }
}