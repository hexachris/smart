using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMARTGradeTracker
{
    public partial class scoreEntry : Form
    {
        private Dictionary<string, int> subjectMapping;
        private Dictionary<string, int> assessmentMapping;
        private string[] subjectReverseMapping;
        private string[] assesmentReverseMapping;
        int row, column;
        

        public scoreEntry()
        {
            InitializeComponent();
            this.Load += ScoreEntry_Load;

            subjectMapping = new Dictionary<string, int>
            {
                {"ITEC 104 - Data Structures and Algorithm", 0},
                {"ITEC 105 - Information Management", 1},
                {"CMSC 202 - Discrete Structures 2", 2},
                {"CMSC 203 - Object Oriented Programming", 3},
                {"GEC 106 - Art Appreciation", 4},
                {"SOSLIT - Sosyedad at Literatura", 5},
                {"MATH 24 - Calculus", 6},
                {"PATHFIT 3", 7}
            };
            subjectReverseMapping = new string[] {
                "ITEC 104 - Data Structures and Algorithm",
                "ITEC 105 - Information Management",
                "CMSC 202 - Discrete Structures 2",
                "CMSC 203 - Object Oriented Programming",
                "GEC 106 - Art Appreciation",
                "SOSLIT - Sosyedad at Literatura",
                "MATH 24 - Calculus",
                "PATHFIT 3",
            };

            assessmentMapping = new Dictionary<string, int>
            {
                {"Midterm Examination", 0},
                {"Final Examination", 1},
                {"Quiz Assessment", 2},
                {"Activity", 3}
            };
            assesmentReverseMapping = new string[] {
                "Midterm Examination",
                "Final Examination",
                "Quiz Assessment",
                "Activity",
            };
        }

        private void UpdateHistory()
        {
            // Discard all entries
            historyBox.Nodes.Clear();

            // Readd all entries
            foreach (HistoryEntry entry in Computation.history)
            {
                TreeNode node = new TreeNode(assesmentReverseMapping[entry.assesment]);
                string remark = entry.score >= 50 ? "Passed" : "Failed";
                node.Nodes.Add($"{remark}: {entry.score}%");
                historyBox.Nodes.Insert(0, node);
            }
            historyBox.ExpandAll();
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

            
            AssementComboBox.Items.Add("Midterm Examination");
            AssementComboBox.Items.Add("Final Examination");
            AssementComboBox.Items.Add("Quiz Assessment");
            AssementComboBox.Items.Add("Activity");
            
            this.rawScoreBox.KeyPress += new KeyPressEventHandler(this.rawScoreBox_KeyPress);
        }

        private void showGrades_Click(object sender, EventArgs e)
        {
            string selectedSubject = SubjectComboBox.SelectedItem.ToString();
            row = subjectMapping[selectedSubject];
            Computation.ShowGrades(selectedSubject, row, assessmentMapping);
        }

        private void Btn_add_Click(object sender, EventArgs e) // This is the "Add to Database" button
        {
            var breakdown = new StringBuilder();

            // This checks if both text boxes have text in them
            if (string.IsNullOrEmpty(rawScoreBox.Text) || string.IsNullOrEmpty(totalScoreBox.Text))
            {
                breakdown.AppendLine("Please enter values in all fields.");
                MessageBox.Show(breakdown.ToString(), "SMART Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // checks if number was inputted in raw score
            if (!decimal.TryParse(rawScoreBox.Text, out decimal rawScore))
            {
                breakdown.AppendLine("Please enter a valid number for RAW score.");
                MessageBox.Show(breakdown.ToString(), "SMART Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // checks if number was inputted in total score
            if (!decimal.TryParse(totalScoreBox.Text, out decimal totalScore))
            {
                breakdown.AppendLine("Please enter a valid number for TOTAL score.");
                MessageBox.Show(breakdown.ToString(), "SMART Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SubjectComboBox.SelectedItem != null && AssementComboBox.SelectedItem != null)
            {
                string selectedSubject = SubjectComboBox.SelectedItem.ToString();
                string selectedAssess = AssementComboBox.SelectedItem.ToString();

                row = subjectMapping[selectedSubject];
                column = assessmentMapping[selectedAssess];

                // Check if trying to add exam grade and one already exists
                CheckExamGrade(selectedAssess, row, column);

                rawScore = decimal.Parse(rawScoreBox.Text);
                totalScore = decimal.Parse(totalScoreBox.Text);
                decimal points = string.IsNullOrEmpty(pointBox.Text) ? 0 : decimal.Parse(pointBox.Text);

                decimal computedScore = ((rawScore + points) / totalScore) * 100;

                MessageBox.Show($"Raw Score: {rawScore}, Total Score: {totalScore}, Additional Points: {points}, Computed Score: {computedScore}");

                if(computedScore <= 100 && computedScore >= 0)
                {
                    Computation.AddGrade(row, column, computedScore);
                    UpdateHistory();

                    // NOTE TO SEAN: Pa-update ng UpdateHistory method so that it also removes extra grades inputted into Exam Assessments

                MessageBox.Show($"A score of {computedScore} has been put into {selectedSubject} ({row}) under {selectedAssess} ({column})");
                }
                else 
                {
                    breakdown.AppendLine("Grade not added.Please ensure score does not exceed 100 and falls below 0.");
                    MessageBox.Show(breakdown.ToString(), "SMART Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                }

            }

            else 
            {
                breakdown.AppendLine("Grade not added. Please select a subject/assessment type.");
                MessageBox.Show(breakdown.ToString(), "SMART Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }

        }

        private void rawScoreBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Check if "Enter" key is pressed
            {
                Btn_add_Click(sender, e); // Trigger the button click event to store grades
            }
        }

        private void CheckExamGrade(string selectedAssess, int row, int column)
        {
            if ((selectedAssess == "Midterm Examination" || selectedAssess == "Final Examination")
                   && Computation.grades[row, column].Any())
            {
                var response = MessageBox.Show(
                    "An exam grade already exists. Do you want to replace it?",
                    "Existing Grade",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (response == DialogResult.No)
                {
                    return;
                }
                else
                {
                    // Clear existing grade before adding new one
                    Computation.grades[row, column].Clear();
                }
            }
        }

        private void Btn_calculate_Click(object sender, EventArgs e)
        {

            var breakdown = new StringBuilder();
            if (SubjectComboBox.SelectedItem != null && AssementComboBox.SelectedItem != null)
            {
                string selectedSubject = SubjectComboBox.SelectedItem.ToString();
                int subject = subjectMapping[selectedSubject];
                Computation.CalculateAllAssessments(subject);
            }
            else
            {
                breakdown.AppendLine("Grade not added. Please select a subject/assessment type.");
                MessageBox.Show(breakdown.ToString(), "SMART Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // eto pala yung assessmentcombobox
        {

        }

        // front end stuff below
        private void Btn_Home_Click(object sender, EventArgs e)
        {
            mainMenu form = new mainMenu();
            Program.NavigationHistory.AddToHistory(form, this);
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
            gradeViewer form = new gradeViewer();
            Program.NavigationHistory.AddToHistory(form, this);
        }

        private void SideBtn_userGuide_Click(object sender, EventArgs e)
        {
            userGuide form = new userGuide();
            Program.NavigationHistory.AddToHistory(form, this);
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
            systemCredits form = new systemCredits();
            Program.NavigationHistory.AddToHistory(form, this   );
        }

        private void SideBtn_systemCredits_MouseEnter(object sender, EventArgs e)
        {
            SideBtn_systemCredits.Image = SMARTGradeTracker.Properties.Resources.sidebbtn_hover_system_credits;
        }

        private void SideBtn_systemCredits_MouseLeave(object sender, EventArgs e)
        {
            SideBtn_systemCredits.Image = SMARTGradeTracker.Properties.Resources.sidebbtn_system_credits;
        }

        private void Btn_add_MouseEnter(object sender, EventArgs e)
        {
            Btn_add.Image = SMARTGradeTracker.Properties.Resources.btn_add;
        }

        private void Btn_add_MouseLeave(object sender, EventArgs e)
        {
            Btn_add.Image = SMARTGradeTracker.Properties.Resources.btn_hover_add1;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void totalScoreBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void scoreEntry_Load_1(object sender, EventArgs e)
        {
            UpdateHistory();
        }

        private void historyBox_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void totalScoreBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Check if "Enter" key is pressed
            {
                Btn_add_Click(sender, e); // Trigger the button click event to store grades
            }
        }

        private void btnForward_MouseEnter(object sender, EventArgs e)
        {
            btnForward.Image = SMARTGradeTracker.Properties.Resources.arrow_right_hover;
        }

        private void btnForward_MouseLeave(object sender, EventArgs e)
        {
            btnForward.Image = SMARTGradeTracker.Properties.Resources.arrow_right;
        }

        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            btnBack.Image = SMARTGradeTracker.Properties.Resources.arrow_left_hover;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.Image = SMARTGradeTracker.Properties.Resources.arrow_left;
        }

        private void btnCalculate_MouseEnter(object sender, EventArgs e)
        {
            btnCalculate.Image = SMARTGradeTracker.Properties.Resources.btn_calculate_hover;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.NavigationHistory.BackForm();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            Program.NavigationHistory.ForwardForm();
        }

        private void btnCalculate_MouseLeave(object sender, EventArgs e)
        {
            btnCalculate.Image = SMARTGradeTracker.Properties.Resources.btn_calculate_normal;
        }
    }
}
