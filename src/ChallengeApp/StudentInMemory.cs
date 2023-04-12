using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ChallengeApp
{
    public class StudentInMemory : StudentAbstractBase
    {
        public List<double> grades = new List<double>();

        public StudentInMemory(string name) : base(name)
        {
        }

        protected override void AddGradeInternal(double number)
        {
           grades.Add(number);
        }

        public override Statistics GetStatistics()
        {
            if (grades.Count == 0)
            {
                Console.WriteLine("No grade has been entered.");
                return null;
            }
            var result = new Statistics();

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);
            }
            return result;
        }
    }
}