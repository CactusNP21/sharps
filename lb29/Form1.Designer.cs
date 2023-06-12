namespace lb29
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
            nameTextBox = new TextBox();
            LoginBtn = new Button();
            LogoutBtn = new Button();
            panel1 = new Panel();
            label2 = new Label();
            SendBtn = new Button();
            sendTextBox = new TextBox();
            exportBtn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 42);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(89, 42);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(254, 27);
            nameTextBox.TabIndex = 1;
            // 
            // LoginBtn
            // 
            LoginBtn.Location = new Point(409, 18);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(122, 51);
            LoginBtn.TabIndex = 2;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // LogoutBtn
            // 
            LogoutBtn.Location = new Point(409, 75);
            LogoutBtn.Name = "LogoutBtn";
            LogoutBtn.Size = new Size(122, 42);
            LogoutBtn.TabIndex = 3;
            LogoutBtn.Text = "Log out";
            LogoutBtn.UseVisualStyleBackColor = true;
            LogoutBtn.Click += LogoutBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Location = new Point(45, 123);
            panel1.Name = "panel1";
            panel1.Size = new Size(703, 203);
            panel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 25);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 0;
            // 
            // SendBtn
            // 
            SendBtn.Location = new Point(598, 365);
            SendBtn.Name = "SendBtn";
            SendBtn.Size = new Size(150, 73);
            SendBtn.TabIndex = 5;
            SendBtn.Text = "Send";
            SendBtn.UseVisualStyleBackColor = true;
            SendBtn.Click += SendBtn_Click;
            // 
            // sendTextBox
            // 
            sendTextBox.Location = new Point(89, 388);
            sendTextBox.Name = "sendTextBox";
            sendTextBox.Size = new Size(450, 27);
            sendTextBox.TabIndex = 6;
            // 
            // exportBtn
            // 
            exportBtn.Location = new Point(587, 40);
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(159, 49);
            exportBtn.TabIndex = 7;
            exportBtn.Text = "Export chatlog";
            exportBtn.UseVisualStyleBackColor = true;
            exportBtn.Click += exportBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(exportBtn);
            Controls.Add(sendTextBox);
            Controls.Add(SendBtn);
            Controls.Add(panel1);
            Controls.Add(LogoutBtn);
            Controls.Add(LoginBtn);
            Controls.Add(nameTextBox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox nameTextBox;
        private Button LoginBtn;
        private Button LogoutBtn;
        private Panel panel1;
        private Button SendBtn;
        private TextBox sendTextBox;
        private Label label2;
        private Button exportBtn;
    }
}