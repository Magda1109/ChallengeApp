using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class StudentTests
    {
        [Fact]
        public void GetStatisticsWorksCorrectly()
        {
            var student = new Student("Magda");
            student.AddGrade(10);
            student.AddGrade(20);
            student.AddGrade(30);

            var result = student.GetStatistics();

            Assert.Equal(20, result.Average, 1);
            Assert.Equal(30, result.High);
            Assert.Equal(10, result.Low);
        }
    }
}
