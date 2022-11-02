using System;
using System.IO;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class SavedStudent : StudentBase
    {
        // const string FileNameName = "Rate.txt";
        // const string FileNameAudit = "Audit.txt";
        // DateTime actualTime = DateTime.UtcNow;
        public SavedStudent(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;
        public override event GradeAddedBelowCDelegate GradeBelowC;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override void AddGrade(string grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }
 
        public override void ChangeName(string name)
        {
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
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

    }
}