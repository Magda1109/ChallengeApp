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
                EnterGrade(studentInMemory);
            }
            else if (userInput == "file")
            {
                EnterGrade(studentSaved);
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }

        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                Console.WriteLine($"Enter grade for {student.Name}. Press 's' to see statistics. To exit press 'q'.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                else if (input == "s")
                {
                    PrintStatistics(student);
                    break;
                }
                try
                {
                    student.AddGrade(input);
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

        private static void PrintStatistics(IStudent studentStats)
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
