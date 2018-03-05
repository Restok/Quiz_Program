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

    public partial class SignUp : Form
    {
        private MySqlConnection conn;
        public SignUp()
        {

            string connString;
            connString = "server = den1.mysql1.gear.host; username = toredatabase; password =c-production; database = toredatabase";

            conn = new MySqlConnection(connString);

            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public bool Register(string user, string pass, string email) {

            string query = $"INSERT INTO users (id, username, password, email) VALUES ('', '{user}', '{pass}', '{email}')";
            try {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error running query");
                        return false;
                    }
                }
                else {
                    MessageBox.Show("Connection not opened!");
                    conn.Close();
                    return false;
                    }
            }
            
            catch(Exception ex)
            {
                MessageBox.Show("error!");
                conn.Close();
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string userNameText = textBox1.Text;
            string passwordText = textBox2.Text;
            string gmailText = textBox3.Text;

            if (userNameText == "" || passwordText == "" || gmailText == "")
            {
                warning.Visible = true;
                Success.Visible = false;
            }
            else
            {
                warning.Visible = false;
                Success.Visible = true;
                if (Register(userNameText, passwordText, gmailText))
                {
                    MessageBox.Show($"User {userNameText} has been created");
                }
                else
                {
                    MessageBox.Show($"User not created!");
                }


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

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
