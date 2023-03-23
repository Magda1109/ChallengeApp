using System;

namespace ChallengeApp
{
    public abstract class StudentAbstractBase : Person, IStudent
    {
        public delegate void GradeAddedBelowCDelegate(object sender, EventArgs args);
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
                case "A":
                    AddGrade("100");
                    break;
                case "B":
                    AddGrade("90");
                    break;
                case "B+" or "+B":
                    AddGrade("95");
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
    }
}