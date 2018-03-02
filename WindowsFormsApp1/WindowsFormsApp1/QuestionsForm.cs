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
    public partial class QuestionsForm : Form
    {
        private MySqlConnection conn;
        SignUp SignUpBox = new SignUp();
        HomePage homepage = new HomePage();
        public QuestionsForm()
        {
            string connString;
            connString = "server =localhost; username = root; password =; database = tore";

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
        

        private void label2_Click(object sender, EventArgs e)
    {
            this.Close();
    }

        private string getQuestion(string subject, string details)
        {
            if (OpenConnection())
            {
                string query = $"SELECT * FROM questions WHERE category = {subject} AND Detail = {details};";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                

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
