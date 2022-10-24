using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class Student : NamedObject
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public delegate void GradeAddedBelowCDelegate(object sender, EventArgs args);
        public event GradeAddedDelegate GradeAdded;
        public event GradeAddedBelowCDelegate GradeBelowC;

        private List<double> grades = new List<double>();

        public const string SUBJECT = "Math";

        public Student(string name) : base(name)
        {
        }

        public void ChangeName(string name)
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

        public void AddGrade(double grade)
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

        public void AddGrade(string grade)
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

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            if (grades.Count == 0)
            {
                Console.WriteLine("No grade has been entered.");
                return result;
            }

            for (var index = 0; index < grades.Count; index++)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }
            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60:
                    result.Letter = 'D';
                    break;

                case var d when d >= 50:
                    result.Letter = 'E';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }

            Console.WriteLine($"The maximum grade is: {result.High:N2}");
            Console.WriteLine($"The minimum grade is: {result.Low:N2}");
            Console.WriteLine($"The average is: {result.Average:N2}");
            Console.WriteLine($"The letter grade is: {result.Letter}");

            return result;
        }
    }
}