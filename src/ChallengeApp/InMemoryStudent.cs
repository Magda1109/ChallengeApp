using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ChallengeApp
{
    public delegate void GradeAddedBelowCDelegate(object sender, EventArgs args);

    public class InMemoryStudent : StudentBase
    {
        private List<double> grades = new List<double>();

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
                    AddLetterGrade(grade);
                }
                else
                {
                    Console.WriteLine($"Grade '{grade}' is incorrect.");
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);
            }
            return result;
        }
    }
}