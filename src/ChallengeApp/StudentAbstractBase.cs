using System;
using System.Reflection;

namespace ChallengeApp
{
    public delegate void GradeAddedBelowCDelegate(object sender, EventArgs args);
    public abstract class StudentAbstractBase : Person, IStudent
    {
        public event GradeAddedBelowCDelegate GradeBelowC;

        protected StudentAbstractBase(string name) : base(name)
        {
        }

        protected abstract void AddGradeInternal(double number);

        public virtual void AddGrade(string grade)
        {
            var success = double.TryParse(grade, out var number);
            switch (success)
            {
                case true when number > 75 && number <= 100:
                    AddGradeInternal(number);
                    Console.WriteLine($"Grade '{number}' has been added.");
                    break;
                case true when number >= 0 && number <= 75:
                    AddGradeInternal(number);
                    GradeBelowC(this, new EventArgs());
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
        public abstract Statistics GetStatistics();

        public void AddLetterGrade(string grade)
        {
            switch (grade)
            {
                case "a":
                    AddGrade("100");
                    break;
                case "b":
                    AddGrade("90");
                    break;
                case "b+" or "+b":
                    AddGrade("95");
                    break;
                case "c":
                    AddGrade("80");
                    break;
                case "c+" or "+c":
                    AddGrade("85");
                    break;
                case "d":
                    AddGrade("70");
                    break;
                case "d+" or "+d":
                    AddGrade("75");
                    break;
                case "e":
                    AddGrade("60");
                    break;
                case "e+" or "+e":
                    AddGrade("65");
                    break;
                case "f":
                    AddGrade("0");
                    break;
                default:
                    AddGrade("0");
                    break;
            }
        }
    }
}