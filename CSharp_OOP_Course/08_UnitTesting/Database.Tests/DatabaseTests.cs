using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] initialData = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(this.initialData);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        public void TestIfConstructorWorksCorrectly(int[] data)
        {
            //Arrange
            int expectedCount = data.Length;

            //Act
            this.database = new Database.Database(data);
            int actualCount = this.database.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorShouldThrowAnExceptionWhenBiggerCollection()
        {
            //Arrange
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            
            //Assert
            Assert.Throws<InvalidOperationException> (() =>
            {
                this.database = new Database.Database(data); //Act
            });
        }

        [Test]
        public void AddShouldIncreaseCountWhenAddedSuccessfully()
        {
            //Arrange
            int expectedCount = 3;

            //Act
            this.database.Add(3);
            int actualCount = this.database.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionWhenDatabaseIsFull()
        {
            //Arrange
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
           {
               this.database.Add(17); //Act
           }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemoveShouldDecreaseCountWhenRemovedSuccessfully()
        {
            //Arrange
            int expectedCount = 1;

            //Act
            this.database.Remove();
            int actualCount = this.database.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            //Arrange
            int[] initialData = new int[] { };
            this.database = new Database.Database(initialData);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove(); //Act
            }, "The collection is empty!");
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void FetchShouldReturnCoppyOfData(int[] expectedData)
        {
            //Arrange
            this.database = new Database.Database(expectedData);

            //Act
            int[] actualData = this.database.Fetch();

            //Assert
            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}