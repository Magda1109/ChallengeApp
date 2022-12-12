using System;
using System.IO;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class SavedStudent : StudentBase
    {
        const string FileNameGrades = "Grades.txt";
        const string FileNameAudit = "Audit.txt";
        DateTime actualTime = DateTime.UtcNow;

        public SavedStudent(string name) : base(name)
        {
        }

        public override event GradeAddedBelowCDelegate GradeBelowC;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{FileNameGrades}"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }

        public override void AddGrade(string grade)
        {
            bool success = double.TryParse(grade, out double number);
            if (success)
            {
                if (number >= 0 && number <= 100)
                {
                    if (number > 75 && number <= 100)
                    {
                        CreateFile(number);
                        Console.WriteLine($"Grade '{grade}' has been added as {number}.");
                    }
                    else if (number >= 0 && number <= 75)
                    {
                        GradeBelowC(this, new EventArgs());
                        CreateFile(number);
                        Console.WriteLine($"Grade '{grade}' has been added as {number}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Grade '{grade}' has not been added as the value must be in the range 0-100.");
                }
            }

            else if (!success)
            {
                if (grade == "A" || grade == "B" || grade == "C" || grade == "D" || grade == "E" || grade == "F" || grade == "B+" || grade == "+B" || grade == "C+" || grade == "+C" || grade == "D+" || grade == "+D" || grade == "E+" || grade == "+E" || grade == "F")
                {
                    AddLetterGrade(grade);
                }

                else
                {
                    Console.WriteLine($"Grade '{grade}' is incorrect.");
                }
            }
        }

        private void CreateFile(double result)
        {
            using (var writer = File.AppendText($"{FileNameGrades}"))
            {
                writer.WriteLine(result);
            }
            using (var writer = File.AppendText($"{FileNameAudit}"))
            {
                writer.WriteLine($"{actualTime}: {result}");
            }
        }
    }
}
