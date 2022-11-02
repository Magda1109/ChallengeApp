using System.Collections.Generic;

namespace ChallengeApp
{
    public abstract class StudentBase : NamedObject, IStudent
    {
        public StudentBase(string name) : base(name)
        {
        }

        public abstract event GradeAddedBelowCDelegate GradeBelowC;
        public abstract List<double> Grades { get; }
        public abstract void AddGrade(string grade);
        public abstract void ChangeName(string name);
        public abstract Statistics GetStatistics(); 

    }
}