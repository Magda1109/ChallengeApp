using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentInMemory = new InMemoryStudent("Magda");
            var studentSaved = new SavedStudent("Magda");

            studentInMemory.GradeBelowC += OnGradeBelowC;
            studentSaved.GradeBelowC += OnGradeBelowC;

            Console.WriteLine("Hello! Please type 'memory' if you would like to save statistics in computer's memory or 'file' in case it should be saved in a file.");
            var userInput = Console.ReadLine();

            if (userInput == "memory")
            {
                EnterGradeMemory(studentInMemory);
            }
            else if (userInput == "file")
            {
                EnterGradeSaved(studentSaved);
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }

        private static void EnterGradeMemory(IStudent studentInMemory)
        {
            while (true)
            {
                Console.WriteLine($"Enter grade for {studentInMemory.Name}. Press 's' to see statistics. To exit press 'q'");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                else if (input == "s")
                {
                    Statistics(studentInMemory);
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

        private static void EnterGradeSaved(IStudent studentSaved)
        {
            while (true)
            {
                Console.WriteLine($"Enter grade for {studentSaved.Name}. Press 's' to see statistics. To exit press 'q'.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                else if (input == "s")
                {
                    Statistics(studentSaved);
                    break;
                }
                try
                {
                    studentSaved.AddGrade(input);
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

        private static void Statistics(IStudent studentStats)
        {
            var stat = studentStats.GetStatistics();
            Console.WriteLine($"The maximum grade is: {stat.High:N2}");
            Console.WriteLine($"The minimum grade is: {stat.Low:N2}");
            Console.WriteLine($"The average is: {stat.Average:N2}");
            Console.WriteLine($"The letter grade is: {stat.Letter}");
        }

        static void OnGradeBelowC(object sender, EventArgs args)
        {
            Console.WriteLine($"Oh no! We should inform student's parents about this fact.");
        }
    }
}
