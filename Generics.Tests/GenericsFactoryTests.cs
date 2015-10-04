
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Generics.Tests
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }

    [TestClass]
    public class GenericsFactoryTests
    {
        [TestMethod]
        public void GivenNames_New_ShouldSucceed()
        {
            // Arrange
            const string firstName = "John";
            const string lastName = "Smith";

            // Act
            var result = GenericsFactory.New<string, string, Person>(firstName, lastName);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Person));
            Assert.AreEqual(firstName, result.FirstName);
            Assert.AreEqual(lastName, result.LastName);
        }
    }
}
