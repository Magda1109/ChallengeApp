using System;
using System.IO;

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
                case false when grade is "a" or "b" or "c" or "d" or "e" or "f" or "b+" or "+b" or "c+" or "+c" or "d+" or "+d" or "e+" or "+e" or "f":
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

        public override Statistics GetStatistics()
        {
            try
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
            catch (FileNotFoundException)
            {
                Console.WriteLine("No grade has been entered.");
                return null;
            }
        }
    }
}
