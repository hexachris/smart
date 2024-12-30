using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMARTGradeTracker
{
    public partial class scoreEntry : Form
    {
        public scoreEntry()
        {
            InitializeComponent();
            this.Load += ScoreEntry_Load;
        }

        private void ScoreEntry_Load(object sender, EventArgs e) // dito placement ng mga pang add ng values sa mga combo box etc.
        {
            
            SubjectComboBox.Items.Add("ITEC 104 - Data Structures and Algorithm");
            SubjectComboBox.Items.Add("ITEC 105 - Information Management");
            SubjectComboBox.Items.Add("CMSC 202 - Discrete Structures 2");
            SubjectComboBox.Items.Add("CMSC 203 - Object Oriented Programming");
            SubjectComboBox.Items.Add("GEC 106 - Art Appreciation");
            SubjectComboBox.Items.Add("SOSLIT - Sosyedad at Literatura");
            SubjectComboBox.Items.Add("MATH 24 - Calculus");
            SubjectComboBox.Items.Add("PATHFit 3");

            
            AssementComboBox.Items.Add("20% Midterms");
            AssementComboBox.Items.Add("20% Finals");
            AssementComboBox.Items.Add("20% Quiz");
            AssementComboBox.Items.Add("20% Activities");
            AssementComboBox.Items.Add("15% Participation");
            AssementComboBox.Items.Add("5% Attendance");

            
            this.rawScoreBox.KeyPress += new KeyPressEventHandler(this.rawScoreBox_KeyPress);
        }

        private void rawScoreBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Check if "Enter" key is pressed
            {
                Btn_add_Click(sender, e); // Trigger the button click event to store grades
            }
        }

        private void Btn_Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu form = new mainMenu();
            form.Show();
        }

        private void Btn_Home_MouseEnter(object sender, EventArgs e)
        {
            Btn_Home.Image = SMARTGradeTracker.Properties.Resources.hover_home;
        }

        private void Btn_Home_MouseLeave(object sender, EventArgs e)
        {
            Btn_Home.Image = SMARTGradeTracker.Properties.Resources.home;
        }

        private void SideBtn_gradeViewer_MouseEnter(object sender, EventArgs e)
        {
            SideBtn_gradeViewer.Image = SMARTGradeTracker.Properties.Resources.sidebtn_hover_grade_viewer;
        }

        private void SideBtn_gradeViewer_MouseLeave(object sender, EventArgs e)
        {
            SideBtn_gradeViewer.Image = SMARTGradeTracker.Properties.Resources.sidebtn_grade_viewer;
        }

        private void SideBtn_gradeViewer_Click(object sender, EventArgs e)
        {
            this.Hide();
            gradeViewer form = new gradeViewer();
            form.Show();
        }

        private void SideBtn_userGuide_Click(object sender, EventArgs e)
        {
            this.Hide();
            userGuide form = new userGuide();
            form.Show();
        }

        private void SideBtn_userGuide_MouseEnter(object sender, EventArgs e)
        {
            SideBtn_userGuide.Image = SMARTGradeTracker.Properties.Resources.sidebtn_hover_user_guide;
        }

        private void SideBtn_userGuide_MouseLeave(object sender, EventArgs e)
        {
            SideBtn_userGuide.Image = SMARTGradeTracker.Properties.Resources.sidebtn_user_guide;
        }

        private void SideBtn_systemCredits_Click(object sender, EventArgs e)
        {
            this.Hide();
            systemCredits form = new systemCredits();
            form.Show();
        }

        private void SideBtn_systemCredits_MouseEnter(object sender, EventArgs e)
        {
            SideBtn_systemCredits.Image = SMARTGradeTracker.Properties.Resources.sidebbtn_hover_system_credits;
        }

        private void SideBtn_systemCredits_MouseLeave(object sender, EventArgs e)
        {
            SideBtn_systemCredits.Image = SMARTGradeTracker.Properties.Resources.sidebbtn_system_credits;
        }

        private void Btn_add_Click(object sender, EventArgs e) // This is the "Add to Database" button
        {
            
            if (string.IsNullOrEmpty(rawScoreBox.Text) || string.IsNullOrEmpty(totalScoreBox.Text))
            {
                MessageBox.Show("Please enter values in all fields.");
                return;
            }

            
            decimal rawScore = decimal.Parse(rawScoreBox.Text);
            decimal totalScore = decimal.Parse(totalScoreBox.Text);
            decimal points = string.IsNullOrEmpty(pointBox.Text) ? 0 : decimal.Parse(pointBox.Text);

            // Store values in the arrays or perform further logic if meron na
            // Example: storing the score (you can replace this with actual array storage logic)
            MessageBox.Show($"Raw Score: {rawScore}, Total Score: {totalScore}, Additional Points: {points}");
        }

        private void Btn_add_MouseEnter(object sender, EventArgs e)
        {
            Btn_add.Image = SMARTGradeTracker.Properties.Resources.btn_add;
        }

        private void Btn_add_MouseLeave(object sender, EventArgs e)
        {
            Btn_add.Image = SMARTGradeTracker.Properties.Resources.btn_hover_add1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // eto pala yung assessmentcombobox
        {

        }

        private void SubjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rawScoreBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pointBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void totalScoreBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
