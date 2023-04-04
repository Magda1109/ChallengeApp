using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ChallengeApp
{
    public class StudentInMemory : StudentAbstractBase
    {
        private List<double> grades = new List<double>();
        public override event GradeAddedBelowCDelegate GradeBelowC;

        public StudentInMemory(string name) : base(name)
        {
        }

        public override void AddGrade(string grade)
        {
            var success = double.TryParse(grade, out var number);
            switch (success)
            {
                case true when number > 75 && number <= 100:
                    grades.Add(number);
                    Console.WriteLine($"Grade '{number}' has been added.");
                    break;
                case true when number >= 0 && number <= 75:
                    GradeBelowC(this, new EventArgs());
                    grades.Add(number);
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

        public override Statistics GetStatistics()
        {
            if (grades.Count == 0)
            {
                Console.WriteLine("No grade has been entered.");
                return null;
            }
            var result = new Statistics();

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);
            }
            return result;
        }
    }
}