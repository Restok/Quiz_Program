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
using WMPLib;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class QuestionsForm : Form
    {
        public static bool hassave = false;
        public static WMPLib.WindowsMediaPlayer sp;
        int interval;
        bool hardmode = false;
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
            var current = Process.GetCurrentProcess();
            Process.GetProcessesByName(current.ProcessName)
                .Where(t => t.Id != current.Id)
                .ToList()
                .ForEach(t => t.Kill());

            current.Kill();
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
            this.BackgroundImageLayout = ImageLayout.Zoom;
            sp = new WindowsMediaPlayer();
            sp.URL = @"Audio Files\Bovi.mp3";
            sp.settings.setMode("Loop", true);
            sp.settings.volume = HomePage.settings.bunifuSlider1.Value;
            sp.controls.play();
            int selectedin = HomePage.settings.bunifuDropdown1.selectedIndex;
            if (selectedin == 0){
                interval = 500;
            }
            else if(selectedin == 1)
            {
                interval = 1000;
            }
            else if(selectedin == 2)
            {
                interval = 2000;
            }
            else if(selectedin == 3)
            {
                interval = 3000;
            }
            else if(selectedin == 4)
            {
                interval = 4000;
            }
            timer1.Interval = interval;
            timer2.Interval = interval;
            timer3.Interval = interval;
            totalQuestionNumber = 15;
            if (HomePage.load == true)
            {
                HomePage.load = false;
                load_save();
                if(currentQuestion == null)
                {
                    Form1.questionspage.Hide();
                    Form1.homepage.Show();
                    MessageBox.Show("No saved data found!");
                }
                questionBox.Text = currentQuestion;
                getQuestionBank(Subject, Details);
                setLabels();
                setQuestionValues();
            }
            else
            {
                getQuestionBank(Subject, Details);
                questionBox.Text = getQuestion();
                currentQuestionNumber = 1;
                setLabels();
                setQuestionValues();
            }
        }
        private void deleteSave()
        {
            if (OpenConnection())
            {
                string currentUser = Form1.user;
                string delete = $"DELETE FROM saveslot WHERE USER = {currentUser}";
            }
        }
        private void checkCorrect(Button chosen) {

            currentQuestionNumber += 1;
            if(currentQuestionNumber < 16){
                if (chosen.Text == correctAnswer)
                {
                    if (hardmode == false)
                    {
                        bunifuTransition1.ShowSync(pictureBox4);
                        timer1.Start();
                        correctCount += 1;
                    }
                    else
                    {
                        bunifuTransition1.ShowSync(pictureBox2);
                        timer3.Start();
                        correctCount += 1;
                    }
                    setQuestionValues();
                    questionBox.Text = getQuestion();
                    setLabels();

                }
                else {
                    bunifuTransition1.ShowSync(pictureBox5);
                    timer2.Start();
                    missedCount += 1;
                    questionBox.Text = getQuestion();
                    setLabels();
                    setQuestionValues();
                }
            }
            else
            {
                if (hardmode == false)
                {
                    bunifuTransition1.ShowSync(pictureBox4);
                    timer1.Start();
                    correctCount += 1;
                }
                else
                {
                    bunifuTransition1.ShowSync(pictureBox2);
                    timer3.Start();
                    correctCount += 1;
                }
                setQuestionValues();
                questionBox.Text = getQuestion();
                setLabels();
                deleteSave();
                hassave = false;
                MessageBox.Show($"Quiz End! You got a total of {percentage.Text}");
                Form1.homepage.Show();
                sp.controls.stop();
                HomePage.ids.controls.play();
                hardmode = false;
                this.Close();

            }
            if(HomePage.settings.bunifuCheckbox1.Checked = true && currentQuestionNumber == 6 && percentage.Text == "100%")
            {
                panel9.Visible = true;
            }
        }
        private void pause()
        {
            hassave = true;
            conn.Close();
            if (OpenConnection())
            {
                string currentUser = Form1.user;
                string getdata = $"SELECT * FROM saveslot WHERE user = '{currentUser}'";
                MySqlCommand cd = new MySqlCommand(getdata, conn);
                MySqlDataReader checkExistence = cd.ExecuteReader();
                if (checkExistence.Read())
                {
                    string updateSave = $"UPDATE saveslot SET CurrentQuestion = '{currentQuestion}', CurrentQuestionNumber = {currentQuestionNumber}, CorrectCount = {correctCount}, MIssedCount = {missedCount}, category = '{Subject}', Details = '{Details}' WHERE user = '{currentUser}'";
                    MySqlCommand update = new MySqlCommand(updateSave, conn);
                    try
                    {
                        checkExistence.Close();
                        update.ExecuteNonQuery();
                        conn.Close();

                    }
                    catch (MySqlException x)
                    {
                        MessageBox.Show("Error updating save!" + x);
                        checkExistence.Close();
                        conn.Close();
                    }
                }
                else
                {
                    string newsave = $"INSERT INTO saveslot VALUES ('', '{currentUser}', '{currentQuestion}', {currentQuestionNumber}, {correctCount}, {missedCount}, '{Subject}', '{Details}');";
                    MySqlCommand newEntry = new MySqlCommand(newsave, conn);
                    try
                    {
                        conn.Close();
                        conn.Open();
                        newEntry.ExecuteNonQuery();
                        conn.Close();
                    }                
                    catch(MySqlException ex)
                    {
                        MessageBox.Show("Error creating new entry!" + ex);
                        conn.Close();
                    }
                }
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
        private void load_save()
        {
            if (OpenConnection())
            {
                string currentUser = Form1.user;
                string load = $"SELECT * FROM saveslot WHERE user = '{currentUser}'";
                MySqlCommand loadsave = new MySqlCommand(load, conn);
                MySqlDataReader readsave = loadsave.ExecuteReader();
                while (readsave.Read())
                {
                    currentQuestion = readsave["currentQuestion"].ToString();
                    currentQuestionNumber = Convert.ToDouble(readsave["currentQuestionNumber"].ToString());
                    correctCount = Convert.ToDouble(readsave["correctCount"].ToString());
                    missedCount = Convert.ToDouble(readsave["MissedCount"].ToString());
                    Subject = readsave["category"].ToString();
                    Details = readsave["Details"].ToString();


                }
                readsave.Close();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Connection not opened!");
            }
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            sp.controls.stop();
            pause();
            Form1.questionspage.Hide();
            Form1.homepage.Show();
            HomePage.ids.controls.play();
            panel5.Visible = false;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            sp.controls.stop();
            panel4.Visible = false;
            Form1.questionspage.Hide();
            HomePage.ids.controls.play();
            Form1.homepage.Show();

        }

        private void percentage_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            hardmode = true;
            questionsBank.Clear();
            getQuestionBank("Insane", "No Details");
            questionBox.Text = getQuestion();
            setLabels();
            pictureBox1.Visible = true;
            questionBox.BackColor = Color.DarkRed;
            button1.BackColor = Color.DarkRed;
            button2.BackColor = Color.DarkRed;
            button3.BackColor = Color.DarkRed;
            button4.BackColor = Color.DarkRed;
            bunifuImageButton1.Visible = false;
            bunifuImageButton2.Visible = false;
            label3.Visible = false;
            label2.Visible = false;
            panel9.Visible = false;
            sp.controls.stop();
            sp.URL = @"Audio Files\Thomas The Tank Engine [EarRape].mp3";
            sp.controls.play();
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            hardmode = true;
            questionsBank.Clear();
            getQuestionBank("Insane", "No Details");
            questionBox.Text = getQuestion();
            setLabels();
            pictureBox1.Visible = true;
            questionBox.BackColor = Color.DarkRed;
            button1.BackColor = Color.DarkRed;
            button2.BackColor = Color.DarkRed;
            button3.BackColor = Color.DarkRed;
            button4.BackColor = Color.DarkRed;
            bunifuImageButton1.Visible = false;
            bunifuImageButton2.Visible = false;
            label3.Visible = false;
            label2.Visible = false;
            panel9.Visible = false;
            sp.controls.stop();
            sp.URL = @"Audio Files\Thomas The Tank Engine [EarRape].mp3";
            sp.controls.play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(pictureBox4);
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(pictureBox5);
            timer2.Stop();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(pictureBox2);
            timer3.Stop();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            panel4.Show();
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

