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
    public partial class gradeViewer : Form
    {
        public gradeViewer()
        {
            InitializeComponent();
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

        private void Btn_subject_Click(object sender, EventArgs e)
        {
            subjectViewer form = new subjectViewer();
            Program.NavigationHistory.AddToHistory(form, this );
        }

        private void Btn_subject_MouseEnter(object sender, EventArgs e)
        {
            Btn_subject.Image = SMARTGradeTracker.Properties.Resources.btn_subject;
        }

        private void Btn_subject_MouseLeave(object sender, EventArgs e)
        {
            Btn_subject.Image = SMARTGradeTracker.Properties.Resources.btn_subject_1;
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

        private void gradeViewer_Load(object sender, EventArgs e)
        {

        }

        private void btn_ITEC104_Click(object sender, EventArgs e)
        {
            decimal testgrade = Computation.weightedGrades[0, 2] + Computation.weightedGrades[0, 3];
            decimal examgrade = Computation.weightedGrades[0, 0] + Computation.weightedGrades[0, 1];

            label_final.Text = Computation.finalGrades[0].ToString(); label_final.Refresh();
            label_test.Text = (testgrade + "%").ToString(); label_test.Refresh();
            label_exam.Text = (examgrade + "%").ToString(); label_exam.Refresh();   
            label_quiz.Text = (Computation.weightedGrades[0, 2]+"%").ToString(); label_quiz.Refresh();
            label_activity.Text = (Computation.weightedGrades[0, 3] + "%").ToString(); label_activity.Refresh();
            label_midtermexam.Text = (Computation.weightedGrades[0, 0]+"%").ToString(); label_midtermexam.Refresh();
            label_finalexam.Text = (Computation.weightedGrades[0, 1] + "%").ToString(); label_finalexam.Refresh();
        }

        private void btn_ITEC105_Click(object sender, EventArgs e)
        {
            decimal testgrade = Computation.weightedGrades[1, 2] + Computation.weightedGrades[1, 3];
            decimal examgrade = Computation.weightedGrades[1, 0] + Computation.weightedGrades[1, 1];

            label_final.Text = Computation.finalGrades[1].ToString(); label_final.Refresh();
            label_test.Text = (testgrade + "%").ToString(); label_test.Refresh();
            label_exam.Text = (examgrade + "%").ToString(); label_exam.Refresh();
            label_quiz.Text = (Computation.weightedGrades[1, 2].ToString()+"%"); label_quiz.Refresh();
            label_activity.Text = (Computation.weightedGrades[1, 3].ToString()+"%"); label_activity.Refresh();
            label_midtermexam.Text = (Computation.weightedGrades[1, 0].ToString()+"%"); label_midtermexam.Refresh();
            label_finalexam.Text = (Computation.weightedGrades[1, 1].ToString()+"%"); label_finalexam.Refresh();
        }

        private void btn_CMSC202_Click(object sender, EventArgs e)
        {
            decimal testgrade = Computation.weightedGrades[2, 2] + Computation.weightedGrades[2, 3];
            decimal examgrade = Computation.weightedGrades[2, 0] + Computation.weightedGrades[2, 1];

            label_final.Text = Computation.finalGrades[2].ToString(); label_final.Refresh();
            label_test.Text = (testgrade + "%").ToString(); label_test.Refresh();
            label_exam.Text = (examgrade + "%").ToString(); label_exam.Refresh();
            label_quiz.Text = (Computation.weightedGrades[2, 2].ToString()+"%"); label_quiz.Refresh();
            label_activity.Text = (Computation.weightedGrades[2, 3] + "%").ToString(); label_activity.Refresh();
            label_midtermexam.Text = (Computation.weightedGrades[2, 0] + "%").ToString(); label_midtermexam.Refresh();
            label_finalexam.Text = (Computation.weightedGrades[2, 1] + "%").ToString(); label_finalexam.Refresh();
        }

        private void btn_CMSC203_Click(object sender, EventArgs e)
        {
            decimal testgrade = Computation.weightedGrades[3, 2] + Computation.weightedGrades[3, 3];
            decimal examgrade = Computation.weightedGrades[3, 0] + Computation.weightedGrades[3, 1];

            label_final.Text = Computation.finalGrades[3].ToString(); label_final.Refresh();
            label_test.Text = (testgrade + "%").ToString(); label_test.Refresh();
            label_exam.Text = (examgrade + "%").ToString(); label_exam.Refresh();
            label_quiz.Text = (Computation.weightedGrades[3, 2].ToString() + "%"); label_quiz.Refresh();
            label_activity.Text = (Computation.weightedGrades[3, 3].ToString() + "%"); label_activity.Refresh();
            label_midtermexam.Text = (Computation.weightedGrades[3, 0].ToString() + "%"); label_midtermexam.Refresh();
            label_finalexam.Text = (Computation.weightedGrades[3, 1].ToString() + "%"); label_finalexam.Refresh();
        }

        private void btn_GEC106_Click(object sender, EventArgs e)
        {
            decimal testgrade = Computation.weightedGrades[4, 2] + Computation.weightedGrades[2, 3];
            decimal examgrade = Computation.weightedGrades[4, 0] + Computation.weightedGrades[2, 1];

            label_final.Text = Computation.finalGrades[4].ToString(); label_final.Refresh();
            label_test.Text = (testgrade + "%").ToString(); label_test.Refresh();
            label_exam.Text = (examgrade + "%").ToString(); label_exam.Refresh();
            label_quiz.Text = (Computation.weightedGrades[4, 2].ToString() + "%"); label_quiz.Refresh();
            label_activity.Text = (Computation.weightedGrades[4, 3].ToString() + "%"); label_activity.Refresh();
            label_midtermexam.Text = (Computation.weightedGrades[4, 0].ToString() + "%"); label_midtermexam.Refresh();
            label_finalexam.Text = (Computation.weightedGrades[4, 1].ToString() + "%"); label_finalexam.Refresh();
        }

        private void btn_SOSLIT_Click(object sender, EventArgs e)
        {
            decimal testgrade = Computation.weightedGrades[5, 2] + Computation.weightedGrades[2, 3];
            decimal examgrade = Computation.weightedGrades[5, 0] + Computation.weightedGrades[2, 1];

            label_final.Text = Computation.finalGrades[5].ToString(); label_final.Refresh();
            label_test.Text = (testgrade + "%").ToString(); label_test.Refresh();
            label_exam.Text = (examgrade + "%").ToString(); label_exam.Refresh();
            label_quiz.Text = (Computation.weightedGrades[5, 2].ToString() + "%"); label_quiz.Refresh();
            label_activity.Text = (Computation.weightedGrades[5, 3].ToString() + "%"); label_activity.Refresh();
            label_midtermexam.Text = (Computation.weightedGrades[5, 0].ToString() + "%"); label_midtermexam.Refresh();
            label_finalexam.Text = (Computation.weightedGrades[5, 1].ToString() + "%"); label_finalexam.Refresh();
        }

        private void btn_PATHFIT_Click(object sender, EventArgs e)
        {
            decimal testgrade = Computation.weightedGrades[7, 2] + Computation.weightedGrades[7, 3];
            decimal examgrade = Computation.weightedGrades[7, 0] + Computation.weightedGrades[7, 1];

            label_final.Text = Computation.finalGrades[7].ToString(); label_final.Refresh();
            label_test.Text = (testgrade + "%").ToString(); label_test.Refresh();
            label_exam.Text = (examgrade + "%").ToString(); label_exam.Refresh();
            label_quiz.Text = (Computation.weightedGrades[7, 2].ToString() + "%"); label_quiz.Refresh();
            label_activity.Text = (Computation.weightedGrades[7, 3].ToString() + "%"); label_activity.Refresh();
            label_midtermexam.Text = (Computation.weightedGrades[7, 0].ToString() + "%"); label_midtermexam.Refresh();
            label_finalexam.Text = (Computation.weightedGrades[7, 1].ToString() + "%"); label_finalexam.Refresh();
        }

        private void btn_MATH24_Click(object sender, EventArgs e)
        {
            decimal testgrade = Computation.weightedGrades[6, 2] + Computation.weightedGrades[6, 3];
            decimal examgrade = Computation.weightedGrades[6, 0] + Computation.weightedGrades[6, 1];

            label_final.Text = Computation.finalGrades[6].ToString(); label_final.Refresh();
            label_test.Text = (testgrade + "%").ToString(); label_test.Refresh();
            label_exam.Text = (examgrade + "%").ToString(); label_exam.Refresh();
            label_quiz.Text = (Computation.weightedGrades[6, 2].ToString() + "%"); label_quiz.Refresh();
            label_activity.Text = (Computation.weightedGrades[6, 3].ToString() + "%"); label_activity.Refresh();
            label_midtermexam.Text = (Computation.weightedGrades[6, 0].ToString() + "%"); label_midtermexam.Refresh();
            label_finalexam.Text = (Computation.weightedGrades[6, 1].ToString() + "%"); label_finalexam.Refresh();
        }

        private void label_final_Click(object sender, EventArgs e)
        {

        }
    }
}
