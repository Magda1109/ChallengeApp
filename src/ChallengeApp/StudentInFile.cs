using System;
using System.IO;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class StudentInFile : StudentAbstractBase
    {
        const string FileNameGrades = "Grades.txt";
        const string FileNameAudit = "Audit.txt";
        DateTime actualTime = DateTime.UtcNow;

        public override event GradeAddedBelowCDelegate GradeBelowC;
        public StudentInFile(string name) : base(name)
        {
        }

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
            var success = double.TryParse(grade, out var number);
            switch (success)
            {
                case true when number > 75 && number <= 100:
                    CreateFile(number);
                    Console.WriteLine($"Grade '{grade}' has been added as {number}.");
                    break;
                case true when number >= 0 && number <= 75:
                    GradeBelowC(this, new EventArgs());
                    CreateFile(number);
                    Console.WriteLine($"Grade '{grade}' has been added as {number}.");
                    break;
                case true:
                    Console.WriteLine($"Grade '{grade}' has not been added as the value must be in the range 0-100.");
                    break;
                case false when grade is "A" or "B" or "C" or "D" or "E" or "F" or "B+" or "+B" or "C+" or "+C" or "D+" or "+D" or "E+" or "+E" or "F":
                    AddLetterGrade(grade);
                    break;
                case false:
                    Console.WriteLine($"Grade '{grade}' is incorrect.");
                    break;
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
