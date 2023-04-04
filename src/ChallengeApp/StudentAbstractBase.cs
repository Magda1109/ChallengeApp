using System;

namespace ChallengeApp
{
    public delegate void GradeAddedBelowCDelegate(object sender, EventArgs args);
    public abstract class StudentAbstractBase : Person, IStudent
    {
        public abstract event GradeAddedBelowCDelegate GradeBelowC;

        public StudentAbstractBase(string name) : base(name)
        {
        }

        public abstract void AddGrade(string grade);
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