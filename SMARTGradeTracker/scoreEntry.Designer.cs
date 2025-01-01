namespace SMARTGradeTracker
{
    partial class scoreEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(scoreEntry));
            this.Btn_Home = new System.Windows.Forms.PictureBox();
            this.SideBtn_systemCredits = new System.Windows.Forms.PictureBox();
            this.SideBtn_gradeViewer = new System.Windows.Forms.PictureBox();
            this.SideBtn_userGuide = new System.Windows.Forms.PictureBox();
            this.Btn_add = new System.Windows.Forms.PictureBox();
            this.SubjectComboBox = new System.Windows.Forms.ComboBox();
            this.AssementComboBox = new System.Windows.Forms.ComboBox();
            this.rawScoreBox = new System.Windows.Forms.TextBox();
            this.totalScoreBox = new System.Windows.Forms.TextBox();
            this.pointBox = new System.Windows.Forms.TextBox();
            this.showGrades = new System.Windows.Forms.Button();
            this.Btn_calculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SideBtn_systemCredits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SideBtn_gradeViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SideBtn_userGuide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_add)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Home
            // 
            this.Btn_Home.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Home.Image = global::SMARTGradeTracker.Properties.Resources.home;
            this.Btn_Home.Location = new System.Drawing.Point(57, 64);
            this.Btn_Home.Name = "Btn_Home";
            this.Btn_Home.Size = new System.Drawing.Size(64, 64);
            this.Btn_Home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Btn_Home.TabIndex = 2;
            this.Btn_Home.TabStop = false;
            this.Btn_Home.Click += new System.EventHandler(this.Btn_Home_Click);
            this.Btn_Home.MouseEnter += new System.EventHandler(this.Btn_Home_MouseEnter);
            this.Btn_Home.MouseLeave += new System.EventHandler(this.Btn_Home_MouseLeave);
            // 
            // SideBtn_systemCredits
            // 
            this.SideBtn_systemCredits.BackColor = System.Drawing.Color.Transparent;
            this.SideBtn_systemCredits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SideBtn_systemCredits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SideBtn_systemCredits.Image = global::SMARTGradeTracker.Properties.Resources.sidebbtn_system_credits;
            this.SideBtn_systemCredits.Location = new System.Drawing.Point(60, 471);
            this.SideBtn_systemCredits.Name = "SideBtn_systemCredits";
            this.SideBtn_systemCredits.Size = new System.Drawing.Size(170, 44);
            this.SideBtn_systemCredits.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SideBtn_systemCredits.TabIndex = 3;
            this.SideBtn_systemCredits.TabStop = false;
            this.SideBtn_systemCredits.Click += new System.EventHandler(this.SideBtn_systemCredits_Click);
            this.SideBtn_systemCredits.MouseEnter += new System.EventHandler(this.SideBtn_systemCredits_MouseEnter);
            this.SideBtn_systemCredits.MouseLeave += new System.EventHandler(this.SideBtn_systemCredits_MouseLeave);
            // 
            // SideBtn_gradeViewer
            // 
            this.SideBtn_gradeViewer.BackColor = System.Drawing.Color.Transparent;
            this.SideBtn_gradeViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SideBtn_gradeViewer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SideBtn_gradeViewer.Image = global::SMARTGradeTracker.Properties.Resources.sidebtn_grade_viewer;
            this.SideBtn_gradeViewer.Location = new System.Drawing.Point(52, 288);
            this.SideBtn_gradeViewer.Name = "SideBtn_gradeViewer";
            this.SideBtn_gradeViewer.Size = new System.Drawing.Size(164, 48);
            this.SideBtn_gradeViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SideBtn_gradeViewer.TabIndex = 4;
            this.SideBtn_gradeViewer.TabStop = false;
            this.SideBtn_gradeViewer.Click += new System.EventHandler(this.SideBtn_gradeViewer_Click);
            this.SideBtn_gradeViewer.MouseEnter += new System.EventHandler(this.SideBtn_gradeViewer_MouseEnter);
            this.SideBtn_gradeViewer.MouseLeave += new System.EventHandler(this.SideBtn_gradeViewer_MouseLeave);
            // 
            // SideBtn_userGuide
            // 
            this.SideBtn_userGuide.BackColor = System.Drawing.Color.Transparent;
            this.SideBtn_userGuide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SideBtn_userGuide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SideBtn_userGuide.Image = global::SMARTGradeTracker.Properties.Resources.sidebtn_user_guide;
            this.SideBtn_userGuide.Location = new System.Drawing.Point(70, 381);
            this.SideBtn_userGuide.Name = "SideBtn_userGuide";
            this.SideBtn_userGuide.Size = new System.Drawing.Size(132, 44);
            this.SideBtn_userGuide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SideBtn_userGuide.TabIndex = 5;
            this.SideBtn_userGuide.TabStop = false;
            this.SideBtn_userGuide.Click += new System.EventHandler(this.SideBtn_userGuide_Click);
            this.SideBtn_userGuide.MouseEnter += new System.EventHandler(this.SideBtn_userGuide_MouseEnter);
            this.SideBtn_userGuide.MouseLeave += new System.EventHandler(this.SideBtn_userGuide_MouseLeave);
            // 
            // Btn_add
            // 
            this.Btn_add.BackColor = System.Drawing.Color.Transparent;
            this.Btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_add.Image = global::SMARTGradeTracker.Properties.Resources.btn_hover_add1;
            this.Btn_add.Location = new System.Drawing.Point(414, 844);
            this.Btn_add.Name = "Btn_add";
            this.Btn_add.Size = new System.Drawing.Size(350, 51);
            this.Btn_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Btn_add.TabIndex = 6;
            this.Btn_add.TabStop = false;
            this.Btn_add.Click += new System.EventHandler(this.Btn_add_Click);
            this.Btn_add.MouseEnter += new System.EventHandler(this.Btn_add_MouseEnter);
            this.Btn_add.MouseLeave += new System.EventHandler(this.Btn_add_MouseLeave);
            // 
            // SubjectComboBox
            // 
            this.SubjectComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SubjectComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SubjectComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectComboBox.ForeColor = System.Drawing.Color.MidnightBlue;
            this.SubjectComboBox.FormattingEnabled = true;
            this.SubjectComboBox.Location = new System.Drawing.Point(442, 290);
            this.SubjectComboBox.Name = "SubjectComboBox";
            this.SubjectComboBox.Size = new System.Drawing.Size(568, 28);
            this.SubjectComboBox.Sorted = true;
            this.SubjectComboBox.TabIndex = 7;
            this.SubjectComboBox.Text = "Yuh";
            this.SubjectComboBox.SelectedIndexChanged += new System.EventHandler(this.SubjectComboBox_SelectedIndexChanged);
            // 
            // AssementComboBox
            // 
            this.AssementComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AssementComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AssementComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssementComboBox.ForeColor = System.Drawing.Color.MidnightBlue;
            this.AssementComboBox.FormattingEnabled = true;
            this.AssementComboBox.Location = new System.Drawing.Point(442, 388);
            this.AssementComboBox.Name = "AssementComboBox";
            this.AssementComboBox.Size = new System.Drawing.Size(568, 28);
            this.AssementComboBox.Sorted = true;
            this.AssementComboBox.TabIndex = 8;
            this.AssementComboBox.Text = "Yuh";
            this.AssementComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // rawScoreBox
            // 
            this.rawScoreBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rawScoreBox.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rawScoreBox.Location = new System.Drawing.Point(442, 614);
            this.rawScoreBox.Name = "rawScoreBox";
            this.rawScoreBox.Size = new System.Drawing.Size(226, 26);
            this.rawScoreBox.TabIndex = 9;
            this.rawScoreBox.TextChanged += new System.EventHandler(this.rawScoreBox_TextChanged);
            // 
            // totalScoreBox
            // 
            this.totalScoreBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.totalScoreBox.ForeColor = System.Drawing.Color.MidnightBlue;
            this.totalScoreBox.Location = new System.Drawing.Point(783, 612);
            this.totalScoreBox.Name = "totalScoreBox";
            this.totalScoreBox.Size = new System.Drawing.Size(226, 26);
            this.totalScoreBox.TabIndex = 10;
            this.totalScoreBox.TextChanged += new System.EventHandler(this.totalScoreBox_TextChanged);
            // 
            // pointBox
            // 
            this.pointBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pointBox.ForeColor = System.Drawing.Color.MidnightBlue;
            this.pointBox.Location = new System.Drawing.Point(442, 724);
            this.pointBox.Name = "pointBox";
            this.pointBox.Size = new System.Drawing.Size(568, 26);
            this.pointBox.TabIndex = 11;
            this.pointBox.TextChanged += new System.EventHandler(this.pointBox_TextChanged);
            // 
            // showGrades
            // 
            this.showGrades.Location = new System.Drawing.Point(791, 845);
            this.showGrades.Name = "showGrades";
            this.showGrades.Size = new System.Drawing.Size(113, 50);
            this.showGrades.TabIndex = 23;
            this.showGrades.Text = "Show Grades";
            this.showGrades.UseVisualStyleBackColor = true;
            this.showGrades.Click += new System.EventHandler(this.showGrades_Click);
            // 
            // Btn_calculate
            // 
            this.Btn_calculate.Location = new System.Drawing.Point(920, 844);
            this.Btn_calculate.Name = "Btn_calculate";
            this.Btn_calculate.Size = new System.Drawing.Size(113, 50);
            this.Btn_calculate.TabIndex = 24;
            this.Btn_calculate.Text = "Calculate";
            this.Btn_calculate.UseVisualStyleBackColor = true;
            this.Btn_calculate.Click += new System.EventHandler(this.Btn_calculate_Click);
            // 
            // scoreEntry
            // 
            this.AccessibleDescription = "Your Personal Grade Tracker";
            this.AccessibleName = "SMART";
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::SMARTGradeTracker.Properties.Resources.background4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1478, 1054);
            this.Controls.Add(this.Btn_calculate);
            this.Controls.Add(this.showGrades);
            this.Controls.Add(this.pointBox);
            this.Controls.Add(this.totalScoreBox);
            this.Controls.Add(this.rawScoreBox);
            this.Controls.Add(this.AssementComboBox);
            this.Controls.Add(this.SubjectComboBox);
            this.Controls.Add(this.Btn_add);
            this.Controls.Add(this.SideBtn_userGuide);
            this.Controls.Add(this.SideBtn_gradeViewer);
            this.Controls.Add(this.SideBtn_systemCredits);
            this.Controls.Add(this.Btn_Home);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1500, 1110);
            this.MinimumSize = new System.Drawing.Size(1500, 1110);
            this.Name = "scoreEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMART • Score Entry";
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SideBtn_systemCredits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SideBtn_gradeViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SideBtn_userGuide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_add)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Btn_Home;
        private System.Windows.Forms.PictureBox SideBtn_systemCredits;
        private System.Windows.Forms.PictureBox SideBtn_gradeViewer;
        private System.Windows.Forms.PictureBox SideBtn_userGuide;
        private System.Windows.Forms.PictureBox Btn_add;
        private System.Windows.Forms.ComboBox SubjectComboBox;
        private System.Windows.Forms.ComboBox AssementComboBox;
        private System.Windows.Forms.TextBox rawScoreBox;
        private System.Windows.Forms.TextBox totalScoreBox;
        private System.Windows.Forms.TextBox pointBox;
        private System.Windows.Forms.Button showGrades;
        private System.Windows.Forms.Button Btn_calculate;
    }
}