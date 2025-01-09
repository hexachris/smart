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
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
            Btn_scoreEntry.Image = SMARTGradeTracker.Properties.Resources._1_score_entry;
        }

        private void SmartMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void Btn_scoreEntry_Click(object sender, EventArgs e)
        {
            scoreEntry form = new scoreEntry();
            Program.NavigationHistory.AddToHistory(form, this);
        }

        private void Btn_scoreEntry_MouseEnter(object sender, EventArgs e)
        {
            Btn_scoreEntry.Image = SMARTGradeTracker.Properties.Resources._1_pressed_score_entry;
        }

        private void Btn_scoreEntry_MouseLeave(object sender, EventArgs e)
        {
            Btn_scoreEntry.Image = SMARTGradeTracker.Properties.Resources._1_score_entry;
        }

        private void Btn_gradeViewer_Click(object sender, EventArgs e)
        {
            gradeViewer form = new gradeViewer();
            Program.NavigationHistory.AddToHistory(form, this);
        }

        private void Btn_gradeViewer_MouseEnter(object sender, EventArgs e)
        {
            Btn_gradeViewer.Image = SMARTGradeTracker.Properties.Resources._2_pressed_grade_viewer;
        }

        private void Btn_gradeViewer_MouseLeave(object sender, EventArgs e)
        {
            Btn_gradeViewer.Image = SMARTGradeTracker.Properties.Resources._2_grade_viewer;
        }

        private void Btn_userGuide_Click(object sender, EventArgs e)
        {
            userGuide form = new userGuide();
            Program.NavigationHistory.AddToHistory(form, this);
        }

        private void Btn_userGuide_MouseEnter(object sender, EventArgs e)
        {
            Btn_userGuide.Image = SMARTGradeTracker.Properties.Resources._3_pressed_user_guide;
        }
        private void Btn_userGuide_MouseLeave(object sender, EventArgs e)
        {
            Btn_userGuide.Image = SMARTGradeTracker.Properties.Resources._3_user_guide;
        }

        private void Btn_systemCredits_Click(object sender, EventArgs e)
        {
            systemCredits form = new systemCredits();
            Program.NavigationHistory.AddToHistory(form, this   );
        }

        private void Btn_systemCredits_MouseEnter(object sender, EventArgs e)
        {
            Btn_systemCredits.Image = SMARTGradeTracker.Properties.Resources._4_pressed_system_credits;
        }

        private void Btn_systemCredits_MouseLeave(object sender, EventArgs e)
        {
            Btn_systemCredits.Image = SMARTGradeTracker.Properties.Resources._4_system_guide;
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
