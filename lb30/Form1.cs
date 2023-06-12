using System.Net;

namespace lb30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            filesTreeView.Nodes.Clear();
            string host = hostTxtBox.Text;
            string username = usernameTxtBox.Text;
            string password = passwordTxtBox.Text;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                PopulateTreeView(response.GetResponseStream(), filesTreeView.Nodes);

                response.Close();

                MessageBox.Show(response.WelcomeMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("������� ������������ �����: " + ex.Message);
            }
        }

        private void DeleteItem(string path, TreeNode node)
        {
            string host = hostTxtBox.Text;
            string username = usernameTxtBox.Text;
            string password = passwordTxtBox.Text;
            string filePath = path.Trim();

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + "/" + filePath);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(username, password);

                // ��������� �������� � FTP-�������
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    MessageBox.Show("������� ������ ��������!");
                }

                // ��������� ����� � TreeView
                node.Remove();
            }
            catch (Exception ex)
            {
                MessageBox.Show("������� ��������� ��������: " + ex.Message);
            }
        }

        private void DownloadItem(string path)
        {
            string host = hostTxtBox.Text;
            string username = usernameTxtBox.Text;
            string password = passwordTxtBox.Text;
            string filePath = path.Trim();

            string userRoot = Environment.GetEnvironmentVariable("USERPROFILE");
            string downloadFolder = Path.Combine(userRoot, "Downloads");
           
            try
            {
                // ��������� ��'���� WebRequest ��� ������������ �������� ����� � FTP-�������
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + "/" + filePath.Replace("\\", "/"));
                MessageBox.Show(host + "/" + filePath.Replace("\\", "/"));
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(username, password);

                // ��������� ������ � ������������ �����
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream ftpStream = response.GetResponseStream())
                using (FileStream fileStream = File.Create(downloadFolder + Path.GetFileName(filePath)))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    while ((bytesRead = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }
                }

                MessageBox.Show("���� ������ �����������!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("������� ������������ �����: " + ex.Message);
            }
        }

        private void PopulateTreeView(Stream stream, TreeNodeCollection nodes)
        {
            using StreamReader reader = new StreamReader(stream);
            var lines = reader.ReadToEnd().Split("\n");

            for (int i = 2; i < lines.Length - 1; i++)
            {
                var line = lines[i];
                var words = line.Split(" ");

                TreeNode folderNode = new TreeNode(words.Last());

                ContextMenuStrip folderContextMenu = new ContextMenuStrip();

                ToolStripMenuItem downloadMenuItem = new ToolStripMenuItem("�����������");
                downloadMenuItem.Click += (s, args) => DownloadItem(folderNode.FullPath);
                folderContextMenu.Items.Add(downloadMenuItem);

                ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("��������");
                deleteMenuItem.Click += (_, _) => DeleteItem(folderNode.FullPath, folderNode);
                folderContextMenu.Items.Add(deleteMenuItem);

                ToolStripMenuItem appendMenuItem = new ToolStripMenuItem("������");
                appendMenuItem.Click += (_, _) => AppendItem(folderNode.FullPath);
                folderContextMenu.Items.Add(appendMenuItem);

                folderNode.ContextMenuStrip = folderContextMenu;

                if (line[0] == 'd')
                {
                    folderNode.Nodes.Add(new TreeNode());
                }

                nodes.Add(folderNode);
            }
        }

        private void AppendItem(string path)
        {
            string host = hostTxtBox.Text;
            string username = usernameTxtBox.Text;
            string password = passwordTxtBox.Text;
            string filePath = path.Trim();

            var localFilePath = "";

            try
            {
                // ��������� ��'���� WebRequest ��� ������������ �������� ����� � FTP-�������

                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "������� ����";
                fdlg.InitialDirectory = @"c:\";
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    filePathTxtBox.Text = fdlg.FileName;
                    localFilePath = fdlg.FileName;
                }

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + "/" + Path.GetFileName(localFilePath));
                MessageBox.Show(host + "/" + Path.GetFileName(localFilePath));
                request.Method = WebRequestMethods.Ftp.AppendFile;
                request.Credentials = new NetworkCredential(username, password);

                using (Stream fileStream = File.OpenRead(localFilePath))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, bytesRead);
                    }
                }

                MessageBox.Show("���� ������ ������!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("������� ������������ �����: " + ex.Message);
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            string host = hostTxtBox.Text;
            string username = usernameTxtBox.Text;
            string password = passwordTxtBox.Text;
            string localFilePath = ""; // ���� �� ���������� �����

            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "������� ����";
            fdlg.InitialDirectory = @"c:\";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                filePathTxtBox.Text = fdlg.FileName;
                localFilePath = fdlg.FileName;
            }

            try
            {
                // ��������� ��'���� WebRequest ��� ������������ ����� �� FTP-������
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + "/" + Path.GetFileName(localFilePath));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(username, password);

                // ������������ �����
                using (Stream fileStream = File.OpenRead(localFilePath))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, bytesRead);
                    }
                }

                MessageBox.Show("���� ����������� ������!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("������� ������������ �����: " + ex.Message);
            }
        }

        private void filesTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            filesTreeView.BeginUpdate();

            e.Node.Nodes.Clear();

            string host = hostTxtBox.Text;
            string username = usernameTxtBox.Text;
            string password = passwordTxtBox.Text;
            string folderPath = e.Node.FullPath;
            try
            {
                // ��������� ��'���� WebRequest ��� ������� ����� ���������� �����
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + "/" + folderPath);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Credentials = new NetworkCredential(username, password);

                // ³���������� ������ �� ��������� ������
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                // ³���������� ����� ���������� ����� � TreeView
                PopulateTreeView(response.GetResponseStream(), e.Node.Nodes);

                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("������� ����������� �����: " + ex.Message);
            }

            filesTreeView.EndUpdate();
        }
    }
}

