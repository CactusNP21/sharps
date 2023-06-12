using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace lb29
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LogoutBtn.Enabled = false;
            SendBtn.Enabled = false;
            groupAddress = IPAddress.Parse(HOST);
        }

        bool alive = false; // �� ���� ��������� ���� ��� ���������
        UdpClient client;
        const int LOCALPORT = 8001; // ���� ��� ��������� ����������
        const int REMOTEPORT = 8001; // ���� ��� ����������� ����������
        const int TTL = 20;
        const string HOST = "235.5.5.1"; // ���� ��� ��������� ����������
        IPAddress groupAddress; // ������ ��� ��������� ����������
        string userName; // ��� ����������� � ���

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            userName = nameTextBox.Text;
            nameTextBox.ReadOnly = true;
            try
            {
                client = new UdpClient(LOCALPORT);
                //�������� �� ��������� ����������
                client.JoinMulticastGroup(groupAddress, TTL);

                // ������ �� ��������� ����������
                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();
                // ����� ����������� ��� ���� ������ �����������
                string message = userName + " ����� � ���";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, HOST, REMOTEPORT);
                LoginBtn.Enabled = false;
                LogoutBtn.Enabled = true;
                SendBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReceiveMessages()
        {
            alive = true;
            try
            {
                while (alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = client.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);
                    // ��������� ���������� ��������� � ��������� ����
                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        label2.Text = time + " " + message + "\r\n"
                        + label2.Text;
                    }));
                }
            }
            catch (ObjectDisposedException)
            {
                if (!alive)
                    return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("{0}: {1}", userName,
               sendTextBox.Text);
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, HOST, REMOTEPORT);
                sendTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            ExitChat();
        }

        private void ExitChat()
        {
            string message = userName + " left ���";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, HOST, REMOTEPORT);
            client.DropMulticastGroup(groupAddress);
            alive = false;
            client.Close();
            LoginBtn.Enabled = true;
            LogoutBtn.Enabled = false;
            SendBtn.Enabled = false;
            nameTextBox.ReadOnly = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive)
                ExitChat();
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            string userRoot = System.Environment.GetEnvironmentVariable("USERPROFILE");

            try
            {
                // Create the .txt file and write the text
                File.WriteAllText(userRoot + "\\chat.txt", label2.Text);

                MessageBox.Show("Text exported successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting text: " + ex.Message);
            }
        }
    }
}