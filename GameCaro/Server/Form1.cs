using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using General;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        Socket server, skclient;
        IPEndPoint ipe;
        List<Player> player = new List<Player>();

        List<Room> phong = new List<Room>();
        Thread thclient;
        private class bdata
        {
          
        }
      
        
        private void button1_Click(object sender, EventArgs e) // mở server để lắng nghe CLient
        {
           

        }
        private void AppendTextThongBao(string s)
        {
        }
        private void LangNgheClient()
        {


            while (true)
            {
                try
                {

                    skclient = server.Accept();
                    Player pl = new Player();
                    pl.socket = skclient;
                    pl.ipaddress = pl.socket.RemoteEndPoint.ToString();
                    player.Add(pl);

                    thclient = new Thread(LangNgheClientMoi);
                    thclient.IsBackground = true;
                    thclient.Start(pl);

                    richTextBox1.SelectionColor = Color.Blue;
                    richTextBox1.AppendText("\nChấp Nhận kết nối từ " + pl.socket.RemoteEndPoint.ToString());
                    richTextBox1.ScrollToCaret();
                }
                catch
                {

                }
            }
        }
        string str;
        string[] a_str;
        int recv;

        bdata bb = new bdata();



        private void LangNgheClientMoi(object obj)
        {
           
        }
        private void LangNgheClient2(string s, byte[] data, Player ple)
        {
          
        }
        private void thoatphonggame(string str,byte[] data,Player ple)
        {
            

        }
        private void vaophong(string str,Player ple)
        {
         
        }
        private Player timphong(int idphong)
        {
           
        }
        private void laydanhsachphong(Player ply)
        {
        }
        private void layidphong(Player ple)
        {
        }
        private void taophongmoi(string str, Player ple)
        {
           
        }
        private void setnameclient(string str,Player ple)
        {
            
        }
        private void Winner(string str, byte[] data,Player ple)
        {
            
        }
        private void chatphong(byte[] data, Player ple)
        {
            if (ple.room.siso == 1)
                SendAClient(ple.socket, data);
            else
            {
                SendAClient(ple.room.plnguoichoi1.socket, data);
                SendAClient(ple.room.plnguoichoi2.socket, data);
            }
        }
        private void DanhCaRo(string str, byte[] data, Player ple)
        {
            a_str = str.Split(',');
            SendAClient((int.Parse(a_str[3]) == 2) ? ple.room.plnguoichoi2.socket : ple.room.plnguoichoi1.socket, data);
        }
        private void SendAClient(Socket sk, byte[] data)
        {
            sk.Send(data, data.Length, SocketFlags.None);
        }
        private void SendAllClient(byte[] data)
        {
            foreach (Player pl in player)
            {
                pl.socket.Send(data, data.Length, SocketFlags.None);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
