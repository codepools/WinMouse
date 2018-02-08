using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinMouse
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        private extern static bool SwapMouseButton(bool fSwap);
       

        [DllImport("user32.dll")]
        private extern static int GetSystemMetrics(int index);

        [DllImport("user32.dll")]
        public static extern IntPtr SetCursor(IntPtr cursorHandle);

        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string fileName);

        [DllImport("user32.dll")]
        public static extern bool SetSystemCursor(IntPtr hCursor, int id);


        public Form1()
        {
            InitializeComponent();
            int flag = GetSystemMetrics(23);//获取当前鼠标设置状态 
            if (flag == 0)//左手习惯 
            {
                LeftMouse();
            }
            else//右手习惯 
            {
                RightMouse();

            }


        }
        void LeftMouse()
        {
            notifyIcon1.Icon = IcoLeft;
            SwapMouseButton(true);//设置成左手
         //   LabelText.Text = "左手鼠标";

            string lcur = "aero_arrow_left.cur";
            if (File.Exists(lcur))
            {
                IntPtr cur = LoadCursorFromFile(lcur);//鼠标图标路径  
                Boolean a = SetSystemCursor(cur, 32512);//32512
            }

            pictureBox2.Visible = false;
            pictureBox1.Visible = true;

        }
        void RightMouse()
        {
            notifyIcon1.Icon = IcoRight;
            SwapMouseButton(false);//设置成右手 aero_arrow.cur
        //    LabelText.Text = "右手鼠标";
            string rcur = "aero_arrow.cur";
            if (File.Exists(rcur))
            {
                IntPtr cur = LoadCursorFromFile(rcur);//鼠标图标路径  
                Boolean a = SetSystemCursor(cur, 32512);//32512
            }

            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }
     
          

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            int flag = GetSystemMetrics(23);//获取当前鼠标设置状态 
            if (flag == 0)//左手习惯 
            {

                LeftMouse();
            }
            else//右手习惯 
            {
                RightMouse();


            }
        }
    }
}
