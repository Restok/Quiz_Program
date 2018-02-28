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
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private MySqlConnection conn;
        SignUp SignUpBox = new SignUp();
        HomePage homepage = new HomePage();
        public Form1()
        {
            string connString;
            connString = "server =localhost; username = root; password =; database = tore";

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
            string user = textBox1.Text;
            string pass = textBox2.Text;
            if (IsLogin(user, pass))
            {
                incorrectLabel.Visible = false;

                homepage.Show();
                this.Hide();
            }
            else
            {
                incorrectLabel.Visible = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
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
