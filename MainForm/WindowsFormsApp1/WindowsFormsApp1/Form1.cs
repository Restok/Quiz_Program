using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WMPLib;
using AesEncDec;
using System.IO;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        WMPLib.WindowsMediaPlayer wplayer;
        private MySqlConnection conn;
        SignUp SignUpBox = new SignUp();
        public static HomePage homepage = new HomePage();
        public static QuestionsForm questionspage = new QuestionsForm();
        public static string user;
        public Form1()
        {
            string connString;
            connString = "server = den1.mysql1.gear.host; username = toredatabase; password =c-production; database = toredatabase;";

            conn = new MySqlConnection(connString);
            InitializeComponent();
        }

        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        
        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        public bool IsLogin(string user, string pass)
        {
            string query = $"SELECT * FROM users WHERE username = '{user}' AND password = '{pass}';";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        conn.Close();
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch(Exception ex)
            {
                conn.Close();
                return false;
            }
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            SignUpBox.Show();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = bunifuCustomTextbox1.Text;
            string pass = bunifuCustomTextbox2.Text;
            pass = Aescryp.Encrypt(pass);
            if (IsLogin(user, pass))
            {
                incorrectLabel.Visible = false;
                homepage.Show();
                wplayer.controls.stop();
                this.Hide();
            }
            else
            {
                incorrectLabel.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            wplayer = new WMPLib.WindowsMediaPlayer();
<<<<<<< HEAD
            wplayer.URL = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Audio Files\Brittle_Rille_Reunited.mp3");
=======
            wplayer.URL = @"..\\Tore\Audio Files\Brittle_Rille_Reunited.mp3";
>>>>>>> db623f87af6017b49da7bd37f8902f1058334580
            wplayer.settings.setMode("Loop", true);
            wplayer.controls.play();
            wplayer.settings.volume = bunifuSlider1.Value;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuSlider1_ValueChanged(object sender, EventArgs e)
        {
            wplayer.settings.volume = bunifuSlider1.Value;
        }

        private void bunifuCustomTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void bunifuCustomTextbox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
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
