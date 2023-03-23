namespace ChallengeApp
{
    public interface IStudent
    {
        string Name { get; set; }
        void AddGrade(string grade);
        Statistics GetStatistics();
        void AddLetterGrade(string grade);
    
        event GradeAddedBelowCDelegate GradeBelowC;
    }
}
