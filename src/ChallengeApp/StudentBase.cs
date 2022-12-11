using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public abstract class StudentBase : NamedObject, IStudent
    {
        public StudentBase(string name) : base(name)
        {
        }

        public abstract event GradeAddedBelowCDelegate GradeBelowC;
        public abstract void AddGrade(string grade);
        public abstract Statistics GetStatistics();

        public void ChangeName(string name)
        {
            bool checkName = false;
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