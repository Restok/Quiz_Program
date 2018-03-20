using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{

    public partial class StatsPage : Form
    {
        bool onm = true;
        bool ons = false;
        bool onh = false;
        string tempscore;
        string adsc;
        string susc;
        string musc;
        string disc;
        string posc;
        private MySqlConnection conn;
        public StatsPage()
        {
            string connString;
            connString = "server =den1.mysql1.gear.host; username = toredatabase; password =c-production; database = toredatabase";

            conn = new MySqlConnection(connString);
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
            label1.Text = "None";

            label4.Text = "None";
            label5.Text = "None";
            label6.Text = "None";
            label7.Text = "None";
            label8.Text = "None";
            label9.Text = "None";
            label10.Text = "None";
            label11.Text = "None";
            label12.Text = "None";
        }


        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void getStats(string us, string cate, Label perc)
        {
            if (OpenConnection())
            {
                try
                {
                    string getuserstats = $"SELECT {cate} FROM scores WHERE user = '{us}';";
                    MySqlCommand cmd = new MySqlCommand(getuserstats, conn);
                    MySqlDataReader getscore = cmd.ExecuteReader();
                    while(getscore.Read())
                    {
                        perc.Text = getscore.GetString(0);
                    }
                    getscore.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting scores!");
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Connection not opened!");
            }
        }
        private void checkNull(Label emp){
            if(emp.Text == null)
            {
                emp.Text = "None";
            }
            
        }
        private void setTable(string user)
        {
            label1.Text = "Addition";
            label5.Text = "Subtraction";
            label7.Text = "Multiplication";
            label9.Text = "Division";
            label11.Text = "Exponents";
            getStats(user, "Addition", label4);
            getStats(user, "Subtraction", label6);
            getStats(user, "Multiplication", label8);
            getStats(user, "Division", label10);
            getStats(user, "Powers",label12);
            checkNull(label4);
            checkNull(label6);
            checkNull(label8);
            checkNull(label10);
            checkNull(label12);
        }
        private void StatsPage_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            string user = HomePage.user;
            setTable(user);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.homepage.Show();
        }



        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            onm = false;
            ons = true;
            onh = false;
            label1.Text = "None";
            label4.Text = "None";
            label5.Text = "None";
            label6.Text = "None";
            label7.Text = "None";
            label8.Text = "None";
            label9.Text = "None";
            label10.Text = "None";
            label11.Text = "None";
            label12.Text = "None";
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string user = Form1.user;
            onm = true;
            ons = false;
            onh = false;
            setTable(user);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage.settings.Show();
        }

        private bool OpenConnection()
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Connection not opened");
                    return false;
                }
            }



        }
    }
