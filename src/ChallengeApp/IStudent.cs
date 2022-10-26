namespace ChallengeApp
{
    public interface IStudent
    {
        void AddGrade(double grade);
        void AddGrade(string grade);
        void ChangeName(string name);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
        event GradeAddedBelowCDelegate GradeBelowC;
    }
}