using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetStudentReturnsDifferentObjects()
        {
            var student1 = GetStudent("Adam");
            var student2 = GetStudent("Ewa");

            Assert.NotSame(student1, student2);
            Assert.False(Object.ReferenceEquals(student1, student2));
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var student1 = GetStudent("Adam");
            var student2 = student1;

            Assert.Same(student1, student2);
            Assert.True(Object.ReferenceEquals(student1, student2));
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var student1 = GetStudent("Adam");
            SetName(student1, "NewName");

            Assert.Equal("NewName", student1.Name);
        }

        private StudentInMemory GetStudent(string name)
        {
            return new StudentInMemory(name);
        }

        private void SetName(StudentInMemory student, string name)
        {
            student.Name = name;
        }

        [Fact]
        public void CheckValueType()
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void StringsBehaveLikeValueType()
        {
            var x = "Adam";
            var upper = MakeUppercase(x);

            Assert.Equal("Adam", x);
            Assert.Equal("ADAM", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }
    }
}
