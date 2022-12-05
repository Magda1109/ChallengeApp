namespace ChallengeApp
{
    public interface IStudent
    {
        void AddGrade(string grade);
        void ChangeName(string name);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedBelowCDelegate GradeBelowC;
    }
}