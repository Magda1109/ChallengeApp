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
                    this.AddGrade("80");
                    break;
                case "c+" or "+c":
                    this.AddGrade("85");
                    break;
                case "d":
                    this.AddGrade("70");
                    break;
                case "d+" or "+d":
                    this.AddGrade("75");
                    break;
                case "e":
                    this.AddGrade("60");
                    break;
                case "e+" or "+e":
                    this.AddGrade("65");
                    break;
                case "f":
                    this.AddGrade("0");
                    break;
                default:
                    this.AddGrade("0");
                    break;
            }
        }
    }
}