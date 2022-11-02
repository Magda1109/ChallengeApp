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

        public override event GradeAddedDelegate GradeAdded;
        public override event GradeAddedBelowCDelegate GradeBelowC;

        public override void AddGrade(double grade)
        {
        //    {
        //         if (grade > 75 && grade <= 100)
        //         {
        //             this.grades.Add(grade);

        //             if (GradeAdded != null)
        //             {
        //                 GradeAdded(this, new EventArgs());
        //             }
        //         }
        //         else if (GradeBelowC != null && grade >= 0 && grade <= 75)
        //         {
        //             GradeAdded(this, new EventArgs());
        //             GradeBelowC(this, new EventArgs());
        //             this.grades.Add(grade);
        //         }
        //         else
        //         {
        //             throw new ArgumentException($"Grade '{grade}' has not been added as the value must be in the range 0-100.");
        //         }
        //     }
        }

        public override void AddGrade(string grade)
        {
             using (var writer = File.AppendText($"{FileNameGrades}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            using (var writer = File.AppendText($"{FileNameAudit}"))
            {
                writer.WriteLine($"{actualTime}: {grade}");
            }
        }

        public override void ChangeName(string name)
        {
            bool checkName = true;
            foreach (var sign in name)
            {
                if (char.IsDigit(sign))
                {
                    checkName = true;
                }
            }
            if (checkName)
            {
                Console.WriteLine("Invalid name");
            }
            else
            {
                Name = name;
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{FileNameGrades}.txt"))
            {
                var line = reader.ReadLine();
                
               if (line == null)
            {
                Console.WriteLine("No grade has been entered.");
                return result;
            }
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }

    }
}