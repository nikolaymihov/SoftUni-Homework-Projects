using System;
using NUnit.Framework;

using ExtendedDatabase;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person testPerson = new Person(21, "pesho123");
        private Person[] people;
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            this.people = new Person[] { new Person(22, "Gosho"), new Person(23, "terminatora") };
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(this.people);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            //Arrange
            int expectedCount = this.people.Length;

            //Act
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(this.people);
            int actualCount = this.extendedDatabase.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorShouldThrowAnExceptionWhenBiggerCollection()
        {
            //Arrange
            this.people = this.CreatePeopleForTesting(17);

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(this.people); //Act
            });
        }

        [Test]
        public void AddShouldIncreaseCountWhenAddedSuccessfully()
        {
            //Arrange
            int expectedCount = 3;

            //Act
            this.extendedDatabase.Add(this.testPerson);
            int actualCount = this.extendedDatabase.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionWhenDatabaseIsFull()
        {
            //Arrange
            this.people = this.CreatePeopleForTesting(16);
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(this.people);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(this.testPerson); //Act
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenPersonWithTheSameNameAlreadyExist()
        {
            //Arrange
            Person person = new Person(100, "Gosho");

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(person); //Act
            }, "There is already user with this username!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenPersonWithTheSameIdAlreadyExist()
        {
            //Arrange
            Person person = new Person(22, "Penka");

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(person); //Act
            }, "There is already user with this Id!");
        }

        [Test]
        public void RemoveShouldDecreaseCountWhenRemovedSuccessfully()
        {
            //Arrange
            int expectedCount = 1;

            //Act
            this.extendedDatabase.Remove();
            int actualCount = this.extendedDatabase.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            //Arrange
            Person[] people = new Person[] { };
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Remove(); //Act
            }, "The collection is empty!");
        }

        [TestCase ("Gosho")]
        [TestCase("terminatora")]
        public void TestIfFindByUserameWorksCorrectly(string name)
        {
            //Act
            Person person = this.extendedDatabase.FindByUsername(name);

            //Assert
            Assert.AreEqual(name, person.UserName);

        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameShouldThrowExceptionWhenUsernameIsNullOrEmpty(string name)
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.extendedDatabase.FindByUsername(name); //Act
            }, "Username parameter is null!");
        }

        [TestCase("Stamat")]
        [TestCase("  ")]
        public void FindByUsernameShouldThrowExceptionWhenUsernameDoesNotExist(string name)
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.FindByUsername(name); //Act
            }, "No user is present by this username!");
        }

        [TestCase(22)]
        [TestCase(23)]
        public void TestIfFindByIdWorksCorrectly(long id)
        {
            //Act
            Person person = this.extendedDatabase.FindById(id);

            //Assert
            Assert.AreEqual(id, person.Id);

        }

        [TestCase(-5)]
        [TestCase(-150)]
        public void FindByIdShouldThrowExceptionWhenIdIsNegative(long id)
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.extendedDatabase.FindById(id); //Act
            }, "Id should be a positive number!");
        }

        [TestCase(null)]
        [TestCase(0)]
        [TestCase(150)]
        public void FindByIdShouldThrowExceptionWhenIdDoesNotExist(long id)
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.FindById(id); //Act
            }, "No user is present by this ID!");
        }

        private ExtendedDatabase.Person[] CreatePeopleForTesting(int neededPeople)
        {
            ExtendedDatabase.Person[] people = new ExtendedDatabase.Person[neededPeople];

            for (int i = 0; i < neededPeople; i++)
            {
                ExtendedDatabase.Person person = new ExtendedDatabase.Person(i, string.Format($"Person {i}"));
                people[i] = person;
            }

            return people;
        }
    }
}