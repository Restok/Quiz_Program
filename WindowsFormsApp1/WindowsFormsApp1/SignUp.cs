﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userNameText = textBox1.Text;
            string passwordText = textBox2.Text;
            string gmailText = textBox3.Text;
            if(userNameText == null || passwordText == null || gmailText == null)
            {
                warning.Visible = true;
            }
            else
            {
                warning.Visible = false;
                Success.Visible = true;
            }


        }
    }
}
