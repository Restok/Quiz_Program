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
    public partial class Form2 : Form
    {
        private MySqlConnection conn;
        public Form2()
        {
            string connString;
            connString = "server = den1.mysql6.gear.host; username = tsubasaquiz; password = Sy5_~vAvcfTV; database = tsubasaquiz";

            conn = new MySqlConnection(connString);
            InitializeComponent();
        }
    private bool openConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Connection not opened" + ex);
                return false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            openConnection();
        }
    }
    
}
