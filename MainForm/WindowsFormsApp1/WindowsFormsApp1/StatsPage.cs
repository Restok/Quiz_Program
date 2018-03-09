﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class  StatsPage : Form
    {
        public StatsPage()
        {
            InitializeComponent();
        }

    int mouseX = 0, mouseY = 0;
    bool mouseDown;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 600;
                mouseY = MousePosition.Y - 20;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

/*        private void hover1_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Hovering!");
        }
*/



        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox5.Visible = true;
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox1.Visible = true;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox1.Visible = true;
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
            pictureBox2.Visible = true;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
            pictureBox2.Visible = true;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox6.Visible = true;
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox7.Visible = true;
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            pictureBox8.Visible = false;
            pictureBox4.Visible = true;
        }


        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox8.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            pictureBox8.Visible = true;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            string user = Form1.user;
        }

        private void welcomeText_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            HomePage.quizpage.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
    {
            this.Close();
    }


    


    }
    class CustomTabControl : TabControl
    {
        private const int TCM_ADJUSTRECT = 0x1328;

        protected override void WndProc(ref Message m)
        {
            //Hide the tab headers at run-time
            if (m.Msg == TCM_ADJUSTRECT)
            {

                RECT rect = (RECT)(m.GetLParam(typeof(RECT)));
                rect.Left = this.Left - this.Margin.Left;
                rect.Right = this.Right + this.Margin.Right;

                rect.Top = this.Top - this.Margin.Top;
                rect.Bottom = this.Bottom + this.Margin.Bottom;
                Marshal.StructureToPtr(rect, m.LParam, true);
                //m.Result = (IntPtr)1;
                //return;
            }
            //else
            // call the base class implementation
            base.WndProc(ref m);
        }

        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }
    }

}
