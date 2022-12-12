namespace ChallengeApp
{
    public interface IStudent
    {
        string Name { get; set; }
        void AddGrade(string grade);
        void ChangeName(string name);
        Statistics GetStatistics();
        void AddLetterGrade(string grade);
        event GradeAddedBelowCDelegate GradeBelowC;
    }
}
