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
        public static List<decimal>[,] grades = new List<decimal>[8, 4];
        public static decimal[,] weightedGrades = new decimal[8, 4];
        public static decimal[] finalGrades = new decimal[8];

        static Computation()
        {
            // Initialize all Lists in the array
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    grades[i, j] = new List<decimal>();
                }
            }
        }

        // CALCULATING ALL
        public static void CalculateAll(int subject)
        {
            try
            {
                // Calculate Midterm (20%)
                ExamCalculate(subject, 0);

                // Calculate Finals (20%)
                ExamCalculate(subject, 1);

                // Calculate Quizzes (20%)
                weightedGrades[subject, 2] = ActivityCalculate(subject, 2);

                // Calculate Activities (20%)
                weightedGrades[subject, 3] = ActivityCalculate(subject, 3);

                // Get final grade (includes the 20% attendance/participation)
                decimal finalGrade = SubjectGrade(subject);

                // Show results
                MessageBox.Show($"Subject Grade Breakdown:\n" +
                               $"Midterm (20%): {weightedGrades[subject, 0]:F2}\n" +
                               $"Finals (20%): {weightedGrades[subject, 1]:F2}\n" +
                               $"Quizzes (20%): {weightedGrades[subject, 2]:F2}\n" +
                               $"Activities (20%): {weightedGrades[subject, 3]:F2}\n" +
                               $"Attendance/Participation (20%): 20\n" +
                               $"Total: {finalGrade:F2}\n" +
                               $"Final Grade: {finalGrades[subject]:F2}",
                               "Grade Calculation Results");

                // Add final grade to finalGrades array
                finalGrades[subject] = finalGrade;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating grades: {ex.Message}");
            }
        }


        // METHOD FOR CALCULATION OF EXAM
        public static void ExamCalculate(int subject, int assessment) 
        {
            decimal examGrade = 0;

            try
            {
                // retrieves grade based on whether if midterm or finals ang hanap
                if (assessment == 0)
                {
                    examGrade = GetSpecificGrade(subject, 0, 0); // midterms
                }

                else if (assessment == 1)
                {
                    examGrade = GetSpecificGrade(subject, 1, 0); // finals
                }

                else
                {
                    throw new ArgumentException("Invalid assessment type");
                }

                // CALCULATES THE PERCENTAGE
                if (examGrade != null)
                {
                    weightedGrades[subject, assessment] = examGrade * 0.20m;
                }
                
            }

            catch (ArgumentException ex)
            {
                // Handle exception (e.g., grade not found or invalid assessment type)
                MessageBox.Show($"Error: {ex.Message}");
            }


        }

        // METHOD FOR CALCULATION OF ACTIVITY/QUIZ
        public static decimal ActivityCalculate(int subject, int assessment) 
        {
            var gradeList = grades[subject, assessment]; // Gets grades for specific subject & assessment

            // Counts how many "grades" are recorded in a certain assessment and divides
            decimal sumWeightedScore = 0;
            decimal multiplier = 0.20m / gradeList.Count; 
            
            // Iterate thru each grade and applies the multiplier
            foreach(var grade in gradeList)
            {
                decimal weightedGrade = grade * multiplier;
                sumWeightedScore += weightedGrade;
            }

            return sumWeightedScore;
        }

        // METHOD FOR CALCULATING TOTAL WEIGHTED AVERAGE FOR ONE SUBJECT
        public static decimal SubjectGrade(int row) 
        {
            decimal totalWeightedAverage = 20; // ASSUMING PARTICIPATION & ATTENDANCE IS PERFECT

            if (row >= 0 && row < weightedGrades.GetLength(0))
            {
                for (int column = 0; column < weightedGrades.GetLength(1); column++)
                {
                    totalWeightedAverage += weightedGrades[row, column];
                }

                finalGrades[row] = ConvertToGrade(totalWeightedAverage);
            }

            else { MessageBox.Show("Invalid row index."); }

            return totalWeightedAverage;
        }
        
        // METHOD USED TO ADD GRADES FROM SCORE ENTRY FORM
        public static void AddGrade(int subject, int assessment, decimal score) 
        {
            grades[subject, assessment].Add(score);
        }

        public static decimal GetSpecificGrade(int subject, int assessment, int gradeIndex)
        {
            if (gradeIndex < 0 || gradeIndex >= grades[subject, assessment].Count)
            {
                throw new ArgumentException("Grade index out of range");
            }
            return grades[subject, assessment][gradeIndex];
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

        // FOR DEBUG
        /*
                public static void ShowAllGrades(Dictionary<string, int> subjectMapping, Dictionary<string, int> assessmentMapping)
                {
                    StringBuilder message = new StringBuilder("Complete Grade Report:\n\n");

                    foreach (var subject in subjectMapping)
                    {
                        message.AppendLine($"=== {subject.Key} ===");

                        foreach (var assessment in assessmentMapping)
                        {
                            message.AppendLine($"\n{assessment.Key}:");
                            var gradeList = grades[subject.Value, assessment.Value];

                            if (gradeList.Any())
                                message.AppendLine(string.Join("\n", gradeList.Select((grade, index) =>
                                    $"Grade {index + 1}: {grade:F2}")));
                            else
                                message.AppendLine("No grades recorded");
                        }
                        message.AppendLine("\n");
                    }

                    MessageBox.Show(message.ToString(), "Complete Grade Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        */

        public static void ShowGrades(string subject, int subjectIndex, Dictionary<string, int> assessmentMapping)
        {
            StringBuilder message = new StringBuilder($"All Grades for {subject}:\n\n");

            foreach (var assessment in assessmentMapping)
            {
                message.AppendLine($"{assessment.Key}:");
                var gradeList = grades[subjectIndex, assessment.Value];

                if (gradeList.Any())
                    message.AppendLine(string.Join("\n", gradeList.Select((grade, index) => $"Grade {index + 1}: {grade:F2}")));
                else
                    message.AppendLine("No grades recorded yet.");

                message.AppendLine(); // Add blank line between assessments
            }

            MessageBox.Show(message.ToString(), "Grade List", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
