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
    public partial class subjectViewer : Form
    {
        public subjectViewer()
        {
            
            InitializeComponent();

            DisplayLinkedList();
        }

        private void DisplayLinkedList()
        {

            var linkedListFinalGrades = Computation.linkedListFinalGrades;

            // List of subject names para mag display sa linked list box
            string[] subjectNames = new string[]
            {
                "\nITEC 104 - ",
                "\nITEC 105 - ",
                "\nCMSC 202 - ",
                "\nCMSC 203 - ",
                "\nGEC 106 - ",
                "\nSOSLIT - ",
                "\nMATH 24 - ",
                "\nPATHFIT 3 - "
            };

            // Build the text to display
            StringBuilder gradesDisplay = new StringBuilder();
            int subjectIndex = 0; // Index to loop through subjectNames

            foreach (var grade in linkedListFinalGrades)
            {
                // Append subject name with the grade
                gradesDisplay.AppendLine($"{subjectNames[subjectIndex++]} {grade:F2}"); // Format grade to 2 decimal places

                // Check to prevent accessing an index beyond the subjectNames array
                if (subjectIndex >= subjectNames.Length)
                    break;
            }

            // Set the text of the LinkedListDisplay label
            if(linkedListFinalGrades == null || !linkedListFinalGrades.Any())
            {
                LinkedListDisplay.Text = "No grades available. Please ensure grades have been inputted and calculated.";
            }

            else
            {
                LinkedListDisplay.Text = gradesDisplay.ToString();
                LinkedListDisplay.Refresh();
            }
            
        }

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

        private void SideBtn_scoreEntry_Click(object sender, EventArgs e)
        {
            scoreEntry form = new scoreEntry();
            Program.NavigationHistory.AddToHistory(form, this);
        }

        private void SideBtn_scoreEntry_MouseEnter(object sender, EventArgs e)
        {
            SideBtn_scoreEntry.Image = SMARTGradeTracker.Properties.Resources.btn_hover_score_entry;
        }

        private void SideBtn_scoreEntry_MouseLeave(object sender, EventArgs e)
        {
            SideBtn_scoreEntry.Image = SMARTGradeTracker.Properties.Resources.btn_score_entry;
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
            Program.NavigationHistory.AddToHistory(form, this);
        }

        private void SideBtn_systemCredits_MouseEnter(object sender, EventArgs e)
        {
            SideBtn_systemCredits.Image = SMARTGradeTracker.Properties.Resources.sidebbtn_hover_system_credits;
        }

        private void SideBtn_systemCredits_MouseLeave(object sender, EventArgs e)
        {
            SideBtn_systemCredits.Image = SMARTGradeTracker.Properties.Resources.sidebbtn_system_credits;
        }

        private void Btn_overall_Click(object sender, EventArgs e)
        {
            gradeViewer form = new gradeViewer();
            Program.NavigationHistory.AddToHistory(form, this);
        }

        private void Btn_overall_MouseEnter(object sender, EventArgs e)
        {
            Btn_overall.Image = SMARTGradeTracker.Properties.Resources.btn_overall;
        }

        private void Btn_overall_MouseLeave(object sender, EventArgs e)
        {
            Btn_overall.Image = SMARTGradeTracker.Properties.Resources.btn_overall_1;
        }

        private void Btn_computation_Click(object sender, EventArgs e)
        {
            computationViewer form = new computationViewer();
            Program.NavigationHistory.AddToHistory(form, this);
        }

        private void Btn_computation_MouseEnter(object sender, EventArgs e)
        {
            Btn_computation.Image = SMARTGradeTracker.Properties.Resources.btn_computation_y;
        }

        private void Btn_computation_MouseLeave(object sender, EventArgs e)
        {
            Btn_computation.Image = SMARTGradeTracker.Properties.Resources.btn_computation_1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.NavigationHistory.BackForm();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            Program.NavigationHistory.ForwardForm();
        }
    }
}
