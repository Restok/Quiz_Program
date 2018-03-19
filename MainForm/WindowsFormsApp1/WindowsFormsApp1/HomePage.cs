using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class HomePage : Form
    {
        public static WMPLib.WindowsMediaPlayer ids;
        public static bool load = false;
        public static string user;
        public static Settings settings = new Settings();
        public static StatsPage stats = new StatsPage();
        public static Quizzes quizpage = new Quizzes();
        public HomePage()
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

            ids = new WMPLib.WindowsMediaPlayer();
            ids.URL = "Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Audio Files\I_Don_t_See_the_Branches_I_See_the_Leaves.mp3");
            ids.settings.setMode("Loop", true);
            ids.settings.volume = settings.bunifuSlider1.Value;
            ids.controls.play();
            user = Form1.user;
            welcomeText.AutoSize = false;
            welcomeText.Text = $"Welcome, {user}";
        }

        private void welcomeText_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            quizpage.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            stats.Show();
            this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            ids.controls.stop();
            load = true;
            Form1.questionspage.Show();
            Form1.homepage.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            quizpage.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            settings.Show();
        }

        private void label2_Click(object sender, EventArgs e)
    {
            var current = Process.GetCurrentProcess();
            Process.GetProcessesByName(current.ProcessName)
                .Where(t => t.Id != current.Id)
                .ToList()
                .ForEach(t => t.Kill());

            current.Kill();
        }


    


    }

}
