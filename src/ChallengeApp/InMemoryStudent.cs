using System;
using System.Collections.Generic;

namespace ChallengeApp
{

    public delegate void GradeAddedBelowCDelegate(object sender, EventArgs args);

    public class InMemoryStudent : StudentBase
    {
        private List<double> grades = new List<double>();
        public override List<double> Grades
        {
            get
            {
                return this.grades;
            }
        }

        public InMemoryStudent(string name) : base(name)
        {
        }

        public override event GradeAddedBelowCDelegate GradeBelowC;

        public override void AddGrade(string grade)
        {
            bool success = double.TryParse(grade, out double number);
            if (success)
            {
                if (number >= 0 && number <= 100)
                {
                    if (number > 75 && number <= 100)
                    {
                        this.grades.Add(number);
                        Console.WriteLine($"Grade '{grade}' has been added as {number}.");
                    }
                    else if (number >= 0 && number <= 75)
                    {
                        GradeBelowC(this, new EventArgs());
                        this.grades.Add(number);
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
                    switch (grade)
                    {
                        case "A":
                            this.AddGrade("100");
                            break;
                        case "B":
                            this.AddGrade("90");
                            break;
                        case "B+" or "+B":
                            this.AddGrade("95");
                            break;
                        case "C":
                            this.AddGrade("80");
                            break;
                        case "C+" or "+C":
                            this.AddGrade("85");
                            break;
                        case "D":
                            this.AddGrade("70");
                            break;
                        case "D+" or "+D":
                            this.AddGrade("75");
                            break;
                        case "E":
                            this.AddGrade("60");
                            break;
                        case "E+" or "+E":
                            this.AddGrade("65");
                            break;
                        case "F":
                            this.AddGrade("0");
                            break;
                        default:
                            this.AddGrade("0");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Grade '{grade}' is incorrect.");
                }
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

            if (grades.Count == 0)
            {
                Console.WriteLine("No grade has been entered.");
                return result;
            }

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);
            }
            return result;
        }
    }
}