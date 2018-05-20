using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Numerics;

namespace User
{
    public partial class frmUser : Form
    {
        IPEndPoint ipe;
        Socket client;

        private System.Windows.Forms.Timer timer;
        BigInteger P, G, x, a, y, ka;
        string adding;
        AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        AES_Enc enc = new AES_Enc();
        public frmUser()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string host = Dns.GetHostName();
            IPHostEntry iph = Dns.Resolve(host);
            IPAddress[] ip = iph.AddressList;
            lbIP.Text = ip[0].ToString();
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            if ((tbName.Text != ""))
            {
                ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                try
                {
                    client.Connect(ipe);
                    client.Send(Encoding.ASCII.GetBytes("Connect|" + tbName.Text));
                }
                catch
                {
                    MessageBox.Show("Cannot connect to server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    client.Close();
                }
                Thread listen = new Thread(Receive);
                listen.IsBackground = true;
                listen.Start();

                btnConn.Visible = false;
                tbName.Visible = false;
                lbName.Text = tbName.Text;
                lbName.Visible = true;
                Text = "Secret Message - Connect As : " + tbName.Text + "( " + lbIP.Text + " )";

                Thread t = new Thread(sendkey);
                t.Start();
                timer = new System.Windows.Forms.Timer();
                timer.Enabled = true;
                timer.Interval = 30000;
                timer.Tick += timer_tick;
                timer.Start();
                MainTimer.Start();

                MessList.Enabled = true;
                btnKey.Enabled = true;
                btnSend.Enabled = true;
                btnNoise.Enabled = true;
                txtInput.Enabled = true;
            }
            else
            {
                MessageBox.Show("Check your name !");
            }
        }
        void timer_tick(object sender, EventArgs e)
        {
            timer.Stop();
            MessageBox.Show("Out of session ! Change key");
            sendkey();
            timer.Start();
        }
  
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5];
                    client.Receive(data);
                    var cmd = Encoding.ASCII.GetString(data).Split('|');
                    switch (cmd[0])
                    {

                        case "Message":
                            string[] tmp = cmd[1].Split(':');
                            string hash = cmd[2].ToString();
                            string name = tmp[0].ToString().Trim();
                            string mess = tmp[1].ToString().Trim();
                            string dec = enc.DecryptText(mess, tbKey.Text);
                            int n = dec.Length;
                            int pad = Convert.ToInt32(cmd[3]);
                            string txt = dec.Substring(0, n - pad);
                            string hash1 = txt + tbKey.Text;
                            if(enc.MD5Hash(hash1) == hash)
                                MessList.Items.Add(name + " : " + txt);
                            else
                                MessList.Items.Add(name + " : Contents may have been changed !!");
                            break;
                        case "Key":
                            int key = Convert.ToInt32(cmd[1]);
                            string ad = cmd[2];
                            adding = ad;
                            y = key;
                            GenKey();


                            break;
                    }

                }
            }
            catch
            {
                Close();
            }
        }
        void AddKey(string k)
        {

            tbKey.Text = k;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != string.Empty)
            {
                string tmp = tbKey.Text;

                string pad;
                int n = txtInput.TextLength;
                n = n % 16 == 0 ? n : 16 - n % 16;
                pad = Random(n).ToString();
                string message = enc.EncryptText(txtInput.Text + pad, tbKey.Text);
                client.Send(Encoding.ASCII.GetBytes("Message|" + tbName.Text + " : " + message + "|" + enc.MD5Hash(txtInput.Text + tbKey.Text) + "|" + n + "|"));

                MessList.Items.Add(tbName.Text + " : " + txtInput.Text);
                txtInput.Clear();
            }
        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            if (tbKey.Visible == false)
            {
                tbKey.Visible = true;
            }
            else
                tbKey.Visible = false;

        }


        //Encrypt
        private static string Random(int length)
        {
            const string pool = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890+-*/~!@#$%&*();:'""\|<>,./?";
            var builder = new StringBuilder();
            Random random = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
        private string getHashSha256(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:X2}", x);
            }
            return hashString;
        }
        private string Get_Day()
        {
            string str = DateTime.Now.ToString("yyyymmddhhmmss").Trim();
            return str;
        }

        private static string ToHexString(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:X2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }

        private void frmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
        }
        private void btnNoise_Click(object sender, EventArgs e)
        {
                if (txtInput.Text != string.Empty)
                {
                    string tmp = tbKey.Text;
                    string pad;
                    int n = txtInput.TextLength;
                    n = n % 16 == 0 ? n : 16 - n % 16;
                    pad = Random(n).ToString();
                    string message = enc.EncryptText(txtInput.Text + pad, tbKey.Text);
                    client.Send(Encoding.ASCII.GetBytes("Message|" + tbName.Text + " : " + message + "|" + enc.MD5Hash(Noise() + tbKey.Text) + "|" + n + "|"));

                    MessList.Items.Add(tbName.Text + " : " + txtInput.Text);
                    txtInput.Clear();
                }
        }

        //Thay đổi P sau 15'
        //P được gửi kèm 1 chuỗi random(chữ hoặc kí tự đặc biệt)
        //b sau khi nhận sẽ tách lấy số và gán vào P
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            MainTimer.Stop();
            BigInteger p = new BigInteger(rand.Next(1000 * 50, 9999 * 50));
            P = p;
            string tmp = p.ToString();
            string txt = tmp.Insert(rand.Next(0, tmp.Length +1), Random(7));
            client.Send(Encoding.ASCII.GetBytes("<>|" + txt + "|"));
            MessageBox.Show("Update !");
            MainTimer.Start();
        }

        private void txtInput_Click(object sender, EventArgs e)
        {
            if(txtInput.Text == "Say something...")
            {
                txtInput.Text = "";
                txtInput.ForeColor = Color.Black;
            }

        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            if (txtInput.Text == "")
            {
                txtInput.Text = "Say something...";
                txtInput.ForeColor = Color.Gray;
            }
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnConn.PerformClick();
            }
            if (e.KeyChar == 13)
            {
                btnConn.PerformClick();
            }
        }

        string Noise()
        {
            int x = txtInput.TextLength;
            string txt = txtInput.Text.Insert(rand.Next(0, x + 1), Random(2));
            return txt;
        }


        //Diffie Hellman
        Random rand = new Random();

        BigInteger power(BigInteger a, BigInteger b, BigInteger P)
        {
            if (b == 1)
                return a;

            else
                return BigInteger.ModPow(a, b, P);
        }
        void sendkey()
        {
            P = 79825;

            G = (P + 1997) - 201;
            
            a = new BigInteger(rand.Next(1000 * 50, 9999 * 50));// a is the chosen private key 
            x = power(G, a, P); // gets the generated key
            adding = Random(25);
            var pKey = x.ToString();
            client.Send(Encoding.ASCII.GetBytes("Key|" + pKey + "|" + adding + "|"));
        }
        void GenKey()
        {
            ka = power(y, a, P);
            adding += ka.ToString();
            byte[] SecretKey = Encoding.ASCII.GetBytes(adding);
            tbKey.Text = Convert.ToBase64String(SecretKey);
        }



    }
}
