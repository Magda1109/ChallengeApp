using System;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentInMemory = new StudentInMemory("Magda");
            var studentInFile = new StudentInFile("Magda");

            studentInMemory.GradeBelowC += OnGradeBelowC;
            studentInFile.GradeBelowC += OnGradeBelowC;

            Console.WriteLine("Hello! Welcome to GradeBook application. \n");

            while (true)
            {
                Console.WriteLine("Please type 'memory' if you would like to save statistics in computer's memory or 'file' in case it should be saved in a file.");
                var userInput = Console.ReadLine().ToLower();

                if (userInput == "memory")
                {
                    EnterGrade(studentInMemory);
                    break;
                }
                if (userInput == "file")
                {
                    EnterGrade(studentInFile);
                    break;
                }
                if (userInput == "q")
                {
                    Console.WriteLine("Bye!");
                    break;
                }

                Console.WriteLine("Incorrect input. Please try again.");
            }
        }

        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                Console.WriteLine($"Enter grade for {student.Name}. Press 's' to see statistics. To exit press 'q'.");
                var input = Console.ReadLine().ToLower();

                if (input == "q")
                {
                    break;
                }
                if (input == "s")
                {
                    PrintStatistics(student);
                    break;
                }
                student.AddGrade(input);
            }
        }

        private static void PrintStatistics(IStudent studentStats)
        {
            try
            {
                var stat = studentStats.GetStatistics();
                Console.WriteLine($"The maximum grade is: {stat.High:N2}");
                Console.WriteLine($"The minimum grade is: {stat.Low:N2}");
                Console.WriteLine($"The average is: {stat.Average:N2}");
                Console.WriteLine($"The letter grade is: {stat.Letter}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Exception has been identified ");
            }
            finally
            {
                Console.WriteLine("************************");
            }
        }

        static void OnGradeBelowC(object sender, EventArgs args)
        {
            Console.WriteLine("Oh no! We should inform student's parents about this fact.");
        }
    }
}
