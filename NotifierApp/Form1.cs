using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NotifierApp
{
    public partial class Form1 : Form
    {       
     

        public Form1()
        {
            InitializeComponent();          
            
        }

        protected void Displaynotify()
        {
            try
            {                
                notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@"image\notification.ico"));
                notifyIcon1.Text = "Warning about eye protection";
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "After every 20 minutes Skip monitor for about 3 minutes ";
                notifyIcon1.BalloonTipText = "Warning about eye protection";
                notifyIcon1.ShowBalloonTip(2000);
            }
            catch (Exception ex)
            {
            }
        }  

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer gt = new Timer();
            gt.Interval = 1000 * 60 * 20;//for 20 seconds
            //gt.Interval = 20000;
            gt.Tick += new EventHandler(gt_Tick);            
           
            gt.Start();
            
        }

        void gt_Tick(object sender, EventArgs e)
        {
            Displaynotify();
        }     

       

        private void Form1_Shown(object sender, EventArgs e)
        {
            //to minimize window
            this.WindowState = FormWindowState.Minimized;

            //to hide from taskbar
            this.Hide();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        
    }
}
