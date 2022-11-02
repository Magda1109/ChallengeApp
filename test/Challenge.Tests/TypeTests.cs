using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class TypeTests
    {
        public delegate string WriteMessage(string message);

        int counter = 0;

         [Fact]
        public void WriteMessageDelegateCanPointToMethod()
        {
           WriteMessage del = ReturnMessage;
           del += ReturnMessage;
           del += ReturnMessage2;

           var result = del("HELLO!");

           Assert.Equal(3, counter);
        }

        string ReturnMessage(string message)
        {
            counter++;
            return message;
        }

        string ReturnMessage2(string message)
        {
            counter++;
            return message.ToUpper();
        }

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
            this.SetName(student1, "NewName");

            Assert.Equal("NewName", student1.Name);
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var student1 = GetStudent("Student 1");
            GetStudentSetName(out student1, "New Name");

            Assert.Equal("New Name", student1.Name);
        }

        private void GetStudentSetName(out InMemoryStudent student, string name)
        {
            student = new InMemoryStudent(name);
        }

        private InMemoryStudent GetStudent(string name)
        {
            return new InMemoryStudent(name);
        }

        private void SetName(InMemoryStudent student, string name)
        {
            student.Name = name;
        }

         [Fact]
        public void Test1()
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
            var upper = this.MakeUppercase(x);

            Assert.Equal("Adam", x);
            Assert.Equal("ADAM", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }
    }
}
