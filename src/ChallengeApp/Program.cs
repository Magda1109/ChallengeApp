using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentInMemory = new InMemoryStudent("Magda");
            var studentSaved = new SavedStudent("Magda");

            studentInMemory.ChangeName("123Magda456");

            studentInMemory.GradeAdded += OnGradeAdded;
            studentInMemory.GradeBelowC += OnGradeBelowC;

            studentSaved.GradeAdded += OnGradeAdded;
            studentSaved.GradeBelowC += OnGradeBelowC;

           // EnterGrade(studentInMemory);
           EnterGrade(studentSaved);

            var stat = studentInMemory.GetStatistics();
            Console.WriteLine($"The maximum grade is: {stat.High:N2}");
            Console.WriteLine($"The minimum grade is: {stat.Low:N2}");
            Console.WriteLine($"The average is: {stat.Average:N2}");
            Console.WriteLine($"The letter grade is: {stat.Letter}");
        }

        private static void EnterGrade(IStudent studentInMemory)
        {
            while (true)
            {
                Console.WriteLine($"Enter grade for {studentInMemory.Name}. To exit press 'q'.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    studentInMemory.AddGrade(input);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("*************");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine($"New grade has been added.");
        }

        static void OnGradeBelowC(object sender, EventArgs args)
        {
            Console.WriteLine($"Oh no! We should inform student's parents about this fact.");
        }
    }
}
