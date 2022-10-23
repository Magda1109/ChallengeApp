using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student("Magda");
            student.ChangeName("123Magda456");

            // var name = student.Name;
            // student.Name = "ABC";

            student.GradeAdded += OnGradeAdded;
            student.GradeBelowC += OnGradeBelowC;

            while (true)
            {
                Console.WriteLine($"Enter grade for {student.Name}. To exit press 'q'.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    student.AddGrade(grade);
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

            var stat = student.GetStatistics();

        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine($"New grade {sender} has been added.");
            //co tu wpisać, jaki argument, żeby pojawiało się jaka ocena została dodana
        }

        static void OnGradeBelowC(object sender, EventArgs args)
        {
            Console.WriteLine($"Oh no! We should inform student's parents about this fact.");
        }
    }
}
