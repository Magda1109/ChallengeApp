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

        public List<double> grades
        {
            get
            {
                return grades;
            }
        }

        private List<double> newList = new List<double>();

        public override void AddGrade(double grade)
        {
           {
                if (grade > 75 && grade <= 100)
                {
                    this.grades.Add(grade);

                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
                else if (GradeBelowC != null && grade >= 0 && grade <= 75)
                {
                    GradeAdded(this, new EventArgs());
                    GradeBelowC(this, new EventArgs());
                    this.grades.Add(grade);
                }
                else
                {
                    throw new ArgumentException($"Grade '{grade}' has not been added as the value must be in the range 0-100.");
                }
            }
        }
        public override void AddGrade(string grade)
        {
            bool success = int.TryParse(grade, out int number);
            if (success)
            {
                if (number >= 0 && number <= 100)
                {
                    this.grades.Add(number);
                    Console.WriteLine($"Grade '{grade}' has been added as {number}.");
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
                    switch (grade)
                    {
                        case "A":
                            this.AddGrade(100);
                            break;
                        case "B":
                            this.AddGrade(90);
                            break;
                        case "B+" or "+B":
                            this.AddGrade(95);
                            break;
                        case "C":
                            this.AddGrade(80);
                            break;
                        case "C+" or "+C":
                            this.AddGrade(85);
                            break;
                        case "D":
                            this.AddGrade(70);
                            break;
                        case "D+" or "+D":
                            this.AddGrade(75);
                            break;
                        case "E":
                            this.AddGrade(60);
                            break;
                        case "E+" or "+E":
                            this.AddGrade(65);
                            break;
                        case "F":
                            this.AddGrade(0);
                            break;
                        default:
                            this.AddGrade(0);
                            break;
                    }
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
                writer.WriteLine(grades);
            }
            using (var writer = File.AppendText($"{FileNameAudit}"))
            {
                writer.WriteLine($"{actualTime}: {grades}");
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








        // const string FileNameGrades = "Grades.txt";
        // const string FileNameAudit = "Audit.txt";
        // DateTime actualTime = DateTime.UtcNow; 
        // public SavedStudent(string name) : base(name)
        // {
        // }

        // public override event GradeAddedDelegate GradeAdded;
        // public override event GradeAddedBelowCDelegate GradeBelowC;

        // public override void AddGrade(double grade)
        // {
        // }

        // public override void AddGrade(string grade)
        // {
        //      using (var writer = File.AppendText($"{FileNameGrades}"))
        //     {
        //         writer.WriteLine(grade);
        //         if (GradeAdded != null)
        //         {
        //             GradeAdded(this, new EventArgs());
        //         }
        //     }
        //     using (var writer = File.AppendText($"{FileNameAudit}"))
        //     {
        //         writer.WriteLine($"{actualTime}: {grade}");
        //     }
        // }

        

        // public override void ChangeName(string name)
        // {
        //     bool checkName = true;
        //     foreach (var sign in name)
        //     {
        //         if (char.IsDigit(sign))
        //         {
        //             checkName = true;
        //         }
        //     }
        //     if (checkName)
        //     {
        //         Console.WriteLine("Invalid name");
        //     }
        //     else
        //     {
        //         Name = name;
        //     }
        // }

        // public override Statistics GetStatistics()
        // {
        //     var result = new Statistics();

        //     using (var reader = File.OpenText($"{FileNameGrades}.txt"))
        //     {
        //         var line = reader.ReadLine();
                
        //        if (line == null)
        //     {
        //         Console.WriteLine("No grade has been entered.");
        //         return result;
        //     }
        //         while (line != null)
        //         {
        //             var number = double.Parse(line);
        //             result.Add(number);
        //             line = reader.ReadLine();
        //         }
        //     }

        //     return result;
        // }

    }
}