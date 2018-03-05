using System;
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
    public partial class Quizzes : Form
    {
        string switches = "Sub";
        public Quizzes()
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.homepage.Show();
        }



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

        private void welcomeText_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (Sub2.Visible == false && Sub3.Visible == false)
            {
                bunifuTransition1.HideSync(Sub1);
                bunifuTransition2.ShowSync(Sub2);
                label1.Text = "Science";
            }
            else if(Sub1.Visible == false && Sub3.Visible == false)
            {
                bunifuTransition1.HideSync(Sub2);
                bunifuTransition2.Show(Sub3);
                label1.Text = "History";
            }
            else
            {
                bunifuTransition2.HideSync(Sub3);
                bunifuTransition1.ShowSync(Sub1);
                label1.Text = "Math";
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (Sub2.Visible == false && Sub3.Visible == false)
            {
                bunifuTransition1.HideSync(Sub1);
                bunifuTransition2.ShowSync(Sub3);
                label1.Text = "History";
            }
            else if (Sub1.Visible == false && Sub3.Visible == false)
            {
                bunifuTransition1.HideSync(Sub2);
                bunifuTransition2.Show(Sub1);
                label1.Text = "Math";
            }
            else
            {
                bunifuTransition2.HideSync(Sub3);
                bunifuTransition1.ShowSync(Sub2);
                label1.Text = "Science";
            }
        }

        private void Sub3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Subject is currently locked!");
        }

        private void Sub2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This subject is currentlt locked!");
        }

        private void Sub1_Click(object sender, EventArgs e)
        {
            bunifuTransition3.ShowSync(panel3);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            bunifuTransition4.HideSync(panel3);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            QuestionsForm.Subject = "Math";
            QuestionsForm.Details = "Addition";
            this.Hide();
            Form1.questionspage.Show();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            QuestionsForm.Subject = "Math";
            QuestionsForm.Details = "Subtraction";
            this.Hide();
            Form1.questionspage.Show();
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            QuestionsForm.Subject = "Math";
            QuestionsForm.Details = "Multiplication";
            this.Hide();
            Form1.questionspage.Show();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            QuestionsForm.Subject = "Math";
            QuestionsForm.Details = "Division";
            this.Hide();
            Form1.questionspage.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            QuestionsForm.Subject = "Math";
            QuestionsForm.Details = "Powers";
            this.Hide();
            Form1.questionspage.Show();
        }

        private void label2_Click(object sender, EventArgs e)
    {
            this.Close();
    }


    


    }

}
