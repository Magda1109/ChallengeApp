namespace ChallengeApp
{
    public interface IStudent
    {
        void AddGrade(string grade);
        void ChangeName(string name);
        Statistics GetStatistics();
        void AddLetterGrade(string grade);
        string Name { get; }
        event GradeAddedBelowCDelegate GradeBelowC;
    }
}