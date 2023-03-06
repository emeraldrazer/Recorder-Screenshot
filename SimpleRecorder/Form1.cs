using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

namespace SimpleRecorder
{
    public partial class Form1 : Form
    {
        Bitmap sc;
        Bitmap bmp;
        Stopwatch stopwatch;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            stopwatch = new Stopwatch();
        }

        private Bitmap TakeScreenshot()
        {
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
            bmp = new Bitmap(screenBounds.Width, screenBounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, screenBounds.Size);
            }

            return bmp;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap screenShot = TakeScreenshot();
            pictureBox1.Image = screenShot;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button2.Enabled = false;
            button3.Enabled = true;
            
            stopwatch.Start();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button2.Enabled = true;
            button3.Enabled = false;

            stopwatch.Stop();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            sc = TakeScreenshot();
            pictureBox1.Image = sc;

            label1.Text = stopwatch.Elapsed.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            label1.Text = stopwatch.Elapsed.ToString();
        }
    }
}
