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
            var student = new InMemoryStudent("Magda");
            student.AddGrade("100");
            student.AddGrade("90");
            student.AddGrade("80");

            var result = student.GetStatistics();

            Assert.Equal(90, result.Average, 1);
            Assert.Equal(100, result.High);
            Assert.Equal(80, result.Low);
        }
    }
}
