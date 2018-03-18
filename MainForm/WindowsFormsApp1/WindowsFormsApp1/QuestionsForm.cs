using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AnimatorNS;
namespace WindowsFormsApp1
{
    public partial class QuestionsForm : Form
    {
        double cur_percent;
        string choiceA;
        string choiceB;
        string choiceC;
        string choiceD;
        string AnswerText;
        string correctAnswer;
        public static string Subject;
        public static string Details;
        string currentQuestion;
        double currentQuestionNumber;
        int totalQuestionNumber;
        double correctCount;
        double missedCount;
        Random rnd = new Random();
        int index;
        List<string> questionsBank = new List<string>();
        private MySqlConnection conn;
        SignUp SignUpBox = new SignUp();
        HomePage homepage = new HomePage();
        public QuestionsForm()
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
        

        private void label2_Click(object sender, EventArgs e)
    {
            this.Close();
    }


        private void getAnswerChoices(string question)
        {

        }

        private void getQuestionBank(string subject, string details)
        {
            if (OpenConnection()) {
                try
                {
                    string query = $"SELECT * FROM questions WHERE category = '{subject}' AND Details = '{details}';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        questionsBank.Add(reader.GetString(2));
                    }
                    conn.Close();
                    reader.Close();
                }
                catch(Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("Error running query!" + ex);
                }
            }
            else
            {
                conn.Close();
                MessageBox.Show("Connection not opened!");
            }
        }

        private string getQuestion()
        {
            index = rnd.Next(0, questionsBank.Count - 1);
            currentQuestion = questionsBank[index];
            questionsBank.Remove(currentQuestion);
            return currentQuestion;
        }
        private void setAnswers(string choice, string cur_question) {
            if (OpenConnection())
            {
                string getChoice = $"SELECT {choice} FROM questions WHERE question = '{cur_question}'";
                MySqlCommand getans = new MySqlCommand(getChoice, conn);
                MySqlDataReader ans_reader = getans.ExecuteReader();
                while (ans_reader.Read())
                {
                    AnswerText = ans_reader.GetString(0);
                }
                ans_reader.Close();
                conn.Close();
            }

            else
            {
                MessageBox.Show("Connection not opened!");
                conn.Close();
            }
        }
        private void setLabels()
        {
            setAnswers("answer_A", currentQuestion);
            choiceA = AnswerText;
            setAnswers("answer_B", currentQuestion);
            choiceB = AnswerText;
            setAnswers("answer_C", currentQuestion);
            choiceC = AnswerText;
            setAnswers("answer_D", currentQuestion);
            choiceD = AnswerText;
            setAnswers("Correct_Answer", currentQuestion);
            correctAnswer = AnswerText;
            button1.Text = choiceA;
            button2.Text = choiceB;
            button3.Text = choiceC;
            button4.Text = choiceD;
        }
        private void QuestionsForm_Load(object sender, EventArgs e)
        {

            currentQuestionNumber = 1;
            totalQuestionNumber = 15;
            getQuestionBank(Subject, Details);
            questionBox.Text = getQuestion();
            setLabels();
            setQuestionValues();
        }
        private void checkCorrect(Button chosen) {

            currentQuestionNumber += 1;
            if(currentQuestionNumber < 16){
                if (chosen.Text == correctAnswer)
                {
                    bunifuTransition1.ShowSync(pictureBox4);
                    Thread.Sleep(1500);
                    bunifuTransition1.HideSync(pictureBox4);
                    correctCount += 1;
                    setQuestionValues();
                    questionBox.Text = getQuestion();
                    setLabels();

                }
                else {
                    bunifuTransition1.ShowSync(pictureBox5);
                    Thread.Sleep(1500);
                    bunifuTransition1.HideSync(pictureBox5);
                    missedCount += 1;
                    questionBox.Text = getQuestion();
                    setLabels();
                    setQuestionValues();
                }
            }
            else
            {
                if (chosen.Text == correctAnswer)
                {
                    bunifuTransition1.ShowSync(pictureBox4);
                    Thread.Sleep(1500);
                    bunifuTransition1.HideSync(pictureBox4);
                    correctCount += 1;
                    setQuestionValues();
                    recordScore();
                }
                else
                {
                    bunifuTransition1.ShowSync(pictureBox5);
                    Thread.Sleep(1500);
                    bunifuTransition1.HideSync(pictureBox5);
                    missedCount += 1;
                    setQuestionValues();
                    recordScore();
                }
                MessageBox.Show("Quiz End!");
                this.Hide();
                Form1.homepage.Show();

            }
        }
        private void pause(string user)
        {
            if (OpenConnection())
            {
                string getdata = $"SELECT * FROM '{}'"
                MySqlCommand comd = new MySqlCommand();
            }
        }
        private void recordScore()
        {
            if (OpenConnection())
            {
                string curscore = percentage.Text; 
                string currentUser = Form1.user;
                string checkExisting = $"SELECT * FROM scores WHERE user = '{currentUser}'";
                string query = $"INSERT INTO scores (id, user, {Details}) VALUES ('', '{currentUser}', '{curscore}')";
                string update = $"UPDATE scores SET {Details} = '{curscore}' WHERE user = '{currentUser}'";
                MySqlCommand checkex = new MySqlCommand(checkExisting, conn);
                try
                {
                    MySqlDataReader excheck = checkex.ExecuteReader();
                    conn.Close();
                    conn.Open();
                    MySqlCommand up = new MySqlCommand(update, conn);
                    up.ExecuteNonQuery();
                }
                catch(MySqlException ex)
                {
                    MySqlCommand insertScore = new MySqlCommand(query, conn);
                    try
                    {
                        insertScore.ExecuteNonQuery();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("error running query" + x);
                    }
                    
                    MessageBox.Show("error!" + ex);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Connection not opened!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            checkCorrect(button1);
        }

        private void setQuestionValues() {
            if (currentQuestionNumber != 16)
            {
                questionCount.Text = $"{currentQuestionNumber.ToString()}/{totalQuestionNumber.ToString()}";
            }
            correctNum.Text = $"{correctCount.ToString()}/{(currentQuestionNumber-1).ToString()}";
            if (currentQuestionNumber - 1 == 0)
            {
                percentage.Text = "N/A";
            }
            else {
                cur_percent = correctCount / (currentQuestionNumber - 1) * 100;
                percentage.Text = (Math.Round(cur_percent, 2)).ToString() + '%';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkCorrect(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkCorrect(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkCorrect(button4);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

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
