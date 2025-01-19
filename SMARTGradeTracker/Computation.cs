using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMARTGradeTracker
{
    public class Computation
    {
        // Constants for better maintainability
        private const int MAX_SUBJECTS = 8;
        private const int MAX_ASSESSMENTS = 4;
        private const decimal ATTENDANCE_POINTS = 20m;
        private const decimal ASSESSMENT_WEIGHT = 0.20m;

        // Grade range constants
        private const decimal MIN_GRADE = 0m;
        private const decimal MAX_GRADE = 100m;

        // Assessment type enum for better code readability
        public enum AssessmentType
        {
            Midterm = 0,
            Finals = 1,
            Quizzes = 2,
            Activities = 3
        }

        public static readonly List<decimal>[,] grades;
        public static readonly decimal[,] weightedGrades;
        public static readonly decimal[] finalGrades;
        public static LinkedList<decimal> linkedListFinalGrades = new LinkedList<decimal>();
        public static readonly Queue<HistoryEntry> history;

        static Computation()
        {
            grades = new List<decimal>[MAX_SUBJECTS, MAX_ASSESSMENTS];
            weightedGrades = new decimal[MAX_SUBJECTS, MAX_ASSESSMENTS];
            finalGrades = new decimal[MAX_SUBJECTS];
            history = new Queue<HistoryEntry>();
            InitializeGrades();
        }

        private static void InitializeGrades()
        {
            for (int i = 0; i < MAX_SUBJECTS; i++)
            {
                for (int j = 0; j < MAX_ASSESSMENTS; j++)
                {
                    grades[i, j] = new List<decimal>();
                }
            }
        }

        // CALCULATING ALL
        public static void CalculateAllAssessments(int subject)
        {
            // Calculate each assessment type
            ExamCalculate(subject, (int)AssessmentType.Midterm);
            ExamCalculate(subject, (int)AssessmentType.Finals);
            weightedGrades[subject, (int)AssessmentType.Quizzes] = ActivityCalculate(subject, (int)AssessmentType.Quizzes);
            weightedGrades[subject, (int)AssessmentType.Activities] = ActivityCalculate(subject, (int)AssessmentType.Activities);

            // Calculate and store the final grade
            decimal totalWeightedAverage = CalculateSubjectGrade(subject);
            finalGrades[subject] = ConvertToGrade(totalWeightedAverage);

            // Display the grade breakdown
            DisplayGradeBreakdown(subject, totalWeightedAverage);

            UpdateLinkedList();
        }

        private static void DisplayGradeBreakdown(int subject, decimal totalWeightedAverage)
        {
            var breakdown = new StringBuilder();
            breakdown.AppendLine($"Grade Calculation Results");
            breakdown.AppendLine("------------------------");
            breakdown.AppendLine($"Weighted Grades:");

            // Show individual assessment weights
            breakdown.AppendLine($"Midterm (20%): {weightedGrades[subject, 0]:F2}");
            breakdown.AppendLine($"Finals (20%): {weightedGrades[subject, 1]:F2}");
            breakdown.AppendLine($"Quizzes (20%): {weightedGrades[subject, 2]:F2}");
            breakdown.AppendLine($"Activities (20%): {weightedGrades[subject, 3]:F2}");
            breakdown.AppendLine($"Attendance (20%): {ATTENDANCE_POINTS:F2}");
            breakdown.AppendLine("------------------------");
            breakdown.AppendLine($"Total Weighted Average: {totalWeightedAverage:F2}");
            breakdown.AppendLine($"Final Grade: {finalGrades[subject]:F2}");

            MessageBox.Show(breakdown.ToString(), "Grade Calculation Results",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // METHOD FOR CALCULATION OF EXAM
        public static void ExamCalculate(int subject, int assessment)
        {
            ValidateIndices(subject, assessment);

            var gradeList = grades[subject, assessment];
            if (!gradeList.Any())
            {
                weightedGrades[subject, assessment] = 0;
                return;
            }

            decimal examGrade = GetSpecificGrade(subject, assessment, 0);
            weightedGrades[subject, assessment] = examGrade * ASSESSMENT_WEIGHT;
        }

        // METHOD FOR CALCULATION OF ACTIVITY/QUIZ
        public static decimal ActivityCalculate(int subject, int assessment)
        {
            ValidateIndices(subject, assessment);

            var gradeList = grades[subject, assessment];
            if (!gradeList.Any())
                return 0;

            decimal multiplier = ASSESSMENT_WEIGHT / gradeList.Count;
            return gradeList.Sum(grade => grade * multiplier);
        }

        // METHOD FOR CALCULATING TOTAL WEIGHTED AVERAGE FOR ONE SUBJECT
        public static decimal CalculateSubjectGrade(int subject)
        {
            ValidateSubjectIndex(subject);

            decimal totalWeightedAverage = ATTENDANCE_POINTS;
            for (int assessment = 0; assessment < MAX_ASSESSMENTS; assessment++)
            {
                totalWeightedAverage += weightedGrades[subject, assessment];
            }

            return totalWeightedAverage;
        }

        // METHOD USED TO ADD GRADES FROM SCORE ENTRY FORM
        public static void AddGrade(int subject, int assessment, decimal score)
        {
            ValidateIndices(subject, assessment);
            ValidateGradeValue(score);

            grades[subject, assessment].Add(score);

            HistoryEntry entry = new HistoryEntry();
            entry.subject = subject;
            entry.assesment = assessment;
            entry.score = score;
            history.Enqueue(entry);
        }

        public static void RemoveOldGrade()
        {
            HistoryEntry entry = history.Dequeue();
            grades[entry.subject, entry.assesment].RemoveAt(0);
        }
        public static void RemoveOldGradeCount(int count)
        {
            for (int i = 0; i < count; i++) {
                RemoveOldGrade();
            }
        }

        public static decimal GetSpecificGrade(int subject, int assessment, int gradeIndex)
        {
            ValidateIndices(subject, assessment);
            var gradeList = grades[subject, assessment];

            if (gradeIndex < 0 || gradeIndex >= gradeList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(gradeIndex), "Grade index is out of range");
            }

            return gradeList[gradeIndex];
        }

        public static decimal ConvertToGrade(decimal totalWeightedAverage)
        {
            if (totalWeightedAverage >= 99)
            {
                return 1.00m;
            }
            else if (totalWeightedAverage >= 96 && totalWeightedAverage < 99)
            {
                return 1.25m;
            }
            else if (totalWeightedAverage >= 93 && totalWeightedAverage < 96)
            {
                return 1.50m;
            }
            else if (totalWeightedAverage >= 90 && totalWeightedAverage < 93)
            {
                return 1.75m;
            }
            else if (totalWeightedAverage >= 87 && totalWeightedAverage < 90)
            {
                return 2.00m;
            }
            else if (totalWeightedAverage >= 84 && totalWeightedAverage < 87)
            {
                return 2.25m;
            }
            else if (totalWeightedAverage >= 81 && totalWeightedAverage < 84)
            {
                return 2.50m;
            }
            else if (totalWeightedAverage >= 78 && totalWeightedAverage < 81)
            {
                return 2.75m;
            }
            else if (totalWeightedAverage >= 75 && totalWeightedAverage < 78)
            {
                return 3.00m;
            }
            else if (totalWeightedAverage >= 70 && totalWeightedAverage < 74)
            {
                return 4.00m;
            }
            else if (totalWeightedAverage < 70)
            {
                return 5.00m;
            }

            throw new ArgumentException("Invalid totalWeightedAverage value.");
        }

        public static void ShowGrades(string subject, int subjectIndex, Dictionary<string, int> assessmentMapping)
        {
            ValidateSubjectIndex(subjectIndex);

            var report = new StringBuilder($"All Grades for {subject}:\n\n");
            foreach (var assessment in assessmentMapping)
            {
                report.AppendLine($"{assessment.Key}:");
                var gradeList = grades[subjectIndex, assessment.Value];

                if (gradeList.Any())
                {
                    for (int i = 0; i < gradeList.Count; i++)
                    {
                        report.AppendLine($"Grade {i + 1}: {gradeList[i]:F2}");
                    }
                }
                else
                {
                    report.AppendLine("No grades recorded yet.");
                }
                report.AppendLine();
            }

            System.Windows.Forms.MessageBox.Show(report.ToString(), "Grade List",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Information);
        }

        public static void UpdateLinkedList()
        {
            linkedListFinalGrades.Clear();
            foreach (var grade in finalGrades)
            {
                linkedListFinalGrades.AddLast(grade);
            }
        }

        // VALIDATE VARIABLES
        private static void ValidateSubjectIndex(int subject)
        {
            if (subject < 0 || subject >= MAX_SUBJECTS)
            {
                throw new ArgumentOutOfRangeException(nameof(subject),
                    $"Subject index must be between 0 and {MAX_SUBJECTS - 1}");
            }
        }

        private static void ValidateAssessmentIndex(int assessment)
        {
            if (assessment < 0 || assessment >= MAX_ASSESSMENTS)
            {
                throw new ArgumentOutOfRangeException(nameof(assessment),
                    $"Assessment index must be between 0 and {MAX_ASSESSMENTS - 1}");
            }
        }

        private static void ValidateIndices(int subject, int assessment)
        {
            ValidateSubjectIndex(subject);
            ValidateAssessmentIndex(assessment);
        }

        private static void ValidateGradeValue(decimal grade)
        {
            if (grade < MIN_GRADE || grade > MAX_GRADE)
            {
                throw new ArgumentOutOfRangeException(nameof(grade),
                    $"Grade must be between {MIN_GRADE} and {MAX_GRADE}");
            }
        }
    }

    public class HistoryEntry
    {
        public int subject;
        public int assesment;
        public decimal score;
    }
}
