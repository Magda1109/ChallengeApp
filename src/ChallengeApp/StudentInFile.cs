using System;
using System.IO;

namespace ChallengeApp
{
    public class StudentInFile : StudentAbstractBase
    {
        const string FileNameGrades = "Grades.txt";
        const string FileNameAudit = "Audit.txt";
        DateTime actualTime = DateTime.UtcNow;

        public StudentInFile(string name) : base(name)
        {
        }

        protected override void AddGradeInternal(double number)
        {
            CreateFile(number);
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
