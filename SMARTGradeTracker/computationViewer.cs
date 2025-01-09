using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMARTGradeTracker
{
    public partial class computationViewer : Form
    {
        private AssessmentGraph flowchart;

        public computationViewer()
        {
            InitializeComponent();
            flowchart = new AssessmentGraph();
        }

        private void computationViewer_Load(object sender, EventArgs e)
        {

        }

        public class FlowchartNode
        {
            public int Id { get; set; }
            public string Label { get; set; }
            public Point Position { get; set; }
            public Size Size { get; set; }

            public FlowchartNode(int id, string label, Point position)
            {
                Id = id;
                Label = label;
                Position = position;
                Size = new Size(120, 50);
            }
        }

        public class AssessmentGraph
        {
            private List<FlowchartNode> nodes;
            private int[,] adjacencyMatrix;
            private Dictionary<string, (List<FlowchartNode>, int[,])> graphs;

            public AssessmentGraph()
            {
                InitializeGraphs();
            }

            private void InitializeGraphs()
            {
                graphs = new Dictionary<string, (List<FlowchartNode>, int[,])>();

                // Midterm/Finals Graph
                var midtermNodes = new List<FlowchartNode>
                {
                    new FlowchartNode(0, "Start", new Point(325, 20)),
                    new FlowchartNode(1, "Get Exam Grade", new Point(325, 120)),
                    new FlowchartNode(2, "Apply Weight (20%)", new Point(325, 220)),
                    new FlowchartNode(3, "Store Result", new Point(325, 320))
                };

                var midtermMatrix = new int[4, 4]
                {
                    {0, 1, 0, 0},
                    {0, 0, 1, 0},
                    {0, 0, 0, 1},
                    {0, 0, 0, 0}
                };

                graphs["Midterm"] = (midtermNodes, midtermMatrix);
                graphs["Finals"] = (midtermNodes, midtermMatrix);

                // Quiz/Activity Graph
                var quizNodes = new List<FlowchartNode>
                {
                    new FlowchartNode(0, "Start", new Point(325, 20)),
                    new FlowchartNode(1, "Get All Grades", new Point(325, 120)),
                    new FlowchartNode(2, "Calculate Average", new Point(325, 220)),
                    new FlowchartNode(3, "Apply Weight (20%)", new Point(325, 320)),
                    new FlowchartNode(4, "Store Result", new Point(325, 420))
                };

                var quizMatrix = new int[5, 5]
                {
                    {0, 1, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 1, 0},
                    {0, 0, 0, 0, 1},
                    {0, 0, 0, 0, 0}
                };

                graphs["Quiz"] = (quizNodes, quizMatrix);
                graphs["Activity"] = (quizNodes, quizMatrix);
            }

            public Bitmap DrawFlowchart(string type)
            {
                if (!graphs.ContainsKey(type))
                    throw new ArgumentException("Invalid assessment type");

                var (currentNodes, currentMatrix) = graphs[type];

                Bitmap bmp = new Bitmap(750, 550);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.Clear(Color.White);

                    Font nodeFont = new Font("Arial", 10);
                    Pen arrowPen = new Pen(Color.DarkGray, 2);
                    arrowPen.CustomEndCap = new AdjustableArrowCap(5, 5);
                    SolidBrush nodeBrush = new SolidBrush(Color.LightBlue);
                    SolidBrush textBrush = new SolidBrush(Color.Black);

                    // Draw edges first using adjacency matrix
                    for (int i = 0; i < currentMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < currentMatrix.GetLength(1); j++)
                        {
                            if (currentMatrix[i, j] == 1)
                            {
                                var startNode = currentNodes[i];
                                var endNode = currentNodes[j];

                                Point start = new Point(
                                    startNode.Position.X + startNode.Size.Width / 2,
                                    startNode.Position.Y + startNode.Size.Height
                                );
                                Point end = new Point(
                                    endNode.Position.X + endNode.Size.Width / 2,
                                    endNode.Position.Y
                                );
                                g.DrawLine(arrowPen, start, end);
                            }
                        }
                    }

                    // Draw nodes
                    foreach (var node in currentNodes)
                    {
                        var rect = new Rectangle(node.Position, node.Size);
                        g.FillRectangle(nodeBrush, rect);
                        g.DrawRectangle(Pens.DarkGray, rect);

                        StringFormat sf = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };
                        g.DrawString(node.Label, nodeFont, textBrush, rect, sf);
                    }
                }
                return bmp;
            }
        }

        // Form implementation
        private void ShowFlowchart(string type)
        {
            Form flowchartForm = new Form
            {
                Width = 800,
                Height = 600,
                Text = $"{type} Computation Flowchart",
                FormBorderStyle = FormBorderStyle.FixedSingle,  // Makes window non-adjustable
                MaximizeBox = false,
                MinimizeBox = false
            };

            PictureBox pb = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = flowchart.DrawFlowchart(type)
            };

            flowchartForm.Controls.Add(pb);
            flowchartForm.ShowDialog();
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
            this.Hide();
            gradeViewer form = new gradeViewer();
            form.Show();
        }

        private void Btn_overall_MouseEnter(object sender, EventArgs e)
        {
            Btn_overall.Image = SMARTGradeTracker.Properties.Resources.btn_overall;
        }

        private void Btn_overall_MouseLeave(object sender, EventArgs e)
        {
            Btn_overall.Image = SMARTGradeTracker.Properties.Resources.btn_overall_1;
        }

        private void Btn_subject_Click(object sender, EventArgs e)
        {
            this.Hide();
            subjectViewer form = new subjectViewer();
            form.Show();
        }

        private void Btn_subject_MouseEnter(object sender, EventArgs e)
        {
            Btn_subject.Image = SMARTGradeTracker.Properties.Resources.btn_subject;
        }

        private void Btn_subject_MouseLeave(object sender, EventArgs e)
        {
            Btn_subject.Image = SMARTGradeTracker.Properties.Resources.btn_subject_1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.NavigationHistory.BackForm();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            Program.NavigationHistory.ForwardForm();
        }

        private void btn_quiz_Click(object sender, EventArgs e)
        {
            ShowFlowchart("Quiz"); 
        }

        private void btn_exam_Click(object sender, EventArgs e)
        {
            ShowFlowchart("Midterm"); 
        }
    }
}
