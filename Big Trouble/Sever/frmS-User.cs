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
using System.Text.RegularExpressions;

namespace SUser
{
    public partial class SUser : Form
    {
        BigInteger P, G, x, a, y, ka;
        AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        AES_Enc enc = new AES_Enc();
        string adding;

        public SUser()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        IPEndPoint ipe;
        Socket server;
        List<Socket> clientlist;

        void Connect()
        {
            clientlist = new List<Socket>();
            ipe = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            server.Bind(ipe);
            Thread Listen = new Thread(() => {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientlist.Add(client);
                        //server.Send(Encoding.ASCII.GetBytes("Connect|" + tbName.Text));

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);                      
                    }
                }
                catch
                {
                    ipe = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }

            });
            Listen.IsBackground = true;
            Listen.Start();

        }

        void Receive(object obj)
        {
            Socket client = obj as Socket;
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

                            foreach (Socket item in clientlist)
                            {
                                string[] tmp = cmd[1].Split(':');
                                string hash = cmd[2].ToString();
                                string name = tmp[0].ToString().Trim();
                                string mess = tmp[1].ToString().Trim();
                                string dec = enc.DecryptText(mess, tbKey.Text);
                                int n = dec.Length;
                                int pad = Convert.ToInt32(cmd[3]);
                                string txt = dec.Substring(0, n - pad);
                                string hash1 = txt + tbKey.Text;
                                if (enc.MD5Hash(hash1) == hash)
                                    MessList.Items.Add(name + " : " + txt);
                                else
                                    MessList.Items.Add(name + " : Contents may have been changed !!");
                                break;
                            }        
                            break;
                        case "Key":
                            int s = Convert.ToInt32(cmd[1]);
                            string ad = cmd[2];
                            adding = ad;
                            sendkey();
                            y = s;
                            GenKey();                         
                            break;
                        case "<>":
                            BigInteger p = getNum(cmd[1]);
                            P = p;
                            break;
                    }
                }
            }
            catch
            {
                clientlist.Remove(client);
                client.Close();
            }
        }
        int getNum(string input)
        {
            int i = 1;
            string[] numbers = Regex.Split(input, @"\D+");
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    i = int.Parse(value);
                }
            }
            return i;
        }
        void AddKey(string k)
        {
            tbKey.Text = k;

        }
       
        private void Sever_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Close();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            string host = Dns.GetHostName();
            IPHostEntry iph = Dns.Resolve(host);
            IPAddress[] ip = iph.AddressList;
            lbIP.Text = ip[0].ToString();

        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            if (tbName.Text != string.Empty)
            {
                btnConn.Visible = false;
                tbName.Visible = false;
                lbName.Text = tbName.Text;
                lbName.Visible = true;
                Text = "Secret Message - Connect As : " + tbName.Text + "( " + lbIP.Text + " )";

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
        private static string Random(int length)
        {
            const string pool = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ+-*/~!@#$%&*();:'""\|<>,./?";
            var builder = new StringBuilder();
            Random random = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {

            foreach (Socket item in clientlist)
            {
                if (item != null && txtInput.Text != string.Empty)
                {
                    string tmp = tbKey.Text;
                    string pad;
                    int n = txtInput.TextLength;
                    n = n % 16 == 0 ? n : 16 - n % 16;
                    pad = Random(n).ToString();
                    string message = enc.EncryptText(txtInput.Text + pad, tbKey.Text);

                    item.Send(Encoding.ASCII.GetBytes("Message|" + tbName.Text + " : " + message + "|" + enc.MD5Hash(txtInput.Text + tbKey.Text) + "|" + n + "|"));

                    MessList.Items.Add(tbName.Text + " : " + txtInput.Text);
                    txtInput.Clear();
                }
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
        private void btnNoise_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientlist)
            {
                if (item != null && txtInput.Text != string.Empty)
                {
                    string tmp = tbKey.Text;
                    string pad;
                    int n = txtInput.TextLength;
                    n = n % 16 == 0 ? n : 16 - n % 16;
                    pad = Random(n).ToString();
                    string message = enc.EncryptText(txtInput.Text + pad, tbKey.Text);                 
                    item.Send(Encoding.ASCII.GetBytes("Message|" + tbName.Text + " : " + message + "|" + enc.MD5Hash(Noise() + tbKey.Text) + "|" + n + "|"));

                    MessList.Items.Add(tbName.Text + " : " + txtInput.Text);
                    txtInput.Clear();
                }
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

        private void txtInput_Click(object sender, EventArgs e)
        {
            if (txtInput.Text == "Say something...")
            {
                txtInput.Text = "";
                txtInput.ForeColor = Color.Black;
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
            Random rd = new Random();
            string txt = txtInput.Text.Insert(rd.Next(0, x + 1), Random(2));
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
            P = 79825; // A prime number P is taken

            G = (P + 1997) - 201;
            a = new BigInteger(rand.Next(1000 * 50, 9999 * 50));// a is the chosen private key 
            x = power(G, a, P); // gets the generated key
            var pKey = x.ToString();
            string add = Random(25);
            foreach (Socket item in clientlist)
            {
                if (item != null)
                {

                    item.Send(Encoding.ASCII.GetBytes("Key|" + pKey + "|" + "" + add + "|" ));
                }

            }
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
