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
    public partial class userGuide : Form
    {
        public userGuide()
        {
            InitializeComponent();
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
        private void SideBtn_scoreEntry_Click(object sender, EventArgs e)
        {
            this.Hide();
            scoreEntry form = new scoreEntry();
            form.Show();
        }

        private void SideBtn_scoreEntry_MouseEnter(object sender, EventArgs e)
        {
            SideBtn_scoreEntry.Image = SMARTGradeTracker.Properties.Resources.btn_hover_score_entry;
        }

        private void SideBtn_scoreEntry_MouseLeave(object sender, EventArgs e)
        {
            SideBtn_scoreEntry.Image = SMARTGradeTracker.Properties.Resources.btn_score_entry;
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
    }
}
