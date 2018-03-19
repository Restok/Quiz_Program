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

using AesEncDec;
using System.IO;

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

            string query = $"INSERT INTO users (id, username, password, email) VALUES ('', @username, @password, @email)";
            
            try {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    try
                    {
                        cmd.Parameters.Add("@username", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@password", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@email", MySqlDbType.VarChar);
                        cmd.Parameters["@username"].Value = user;
                        cmd.Parameters["@password"].Value = pass;
                        cmd.Parameters["@email"].Value = email;
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
                if (userNameText.Length < 25)
                {
                    warning.Visible = false;
                    Success.Visible = true;
                    string encpass = Aescryp.Encrypt(passwordText);
                    if (Register(userNameText, encpass, gmailText))
                    {
                        MessageBox.Show($"User {userNameText} has been created");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"User not created!");
                    }
                }
                else
                {
                    MessageBox.Show("Username too long!");
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
