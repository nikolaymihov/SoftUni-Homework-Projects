namespace Computers.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PartConstructorShouldInitializeCorrectly()
        {
            string expPartName = "Keyboard";
            decimal expPartPrice = 10m;

            Part part = new Part(expPartName, expPartPrice);

            string actPartName = part.Name;
            decimal actParPrice = part.Price;

            Assert.AreEqual(expPartName, actPartName);
            Assert.AreEqual(expPartName, actPartName);
        }

        [Test]
        public void ComputerConstructorShouldInitializeCorrectly()
        {
            string expCompName = "Lenovo";

            Computer computer = new Computer(expCompName);

            string actCompName = computer.Name;

            Assert.AreEqual(expCompName, actCompName);
            Assert.IsNotNull(computer.Parts);
            Assert.IsAssignableFrom(typeof(System.Collections.ObjectModel.ReadOnlyCollection<Part>), computer.Parts);
        }

        [TestCase(null)]
        [TestCase("    ")]
        [TestCase("")]
        public void NameParameterShouldThrowsExceptionWhenIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = new Computer(name);
            }, "Name cannot be null or empty!");
        }

        [Test]
        public void AddPartShouldIncreasePartsCountWhenSuccessfull()
        {
            Part testPart1 = new Part("mouse", 5m);
            Part testPart2 = new Part("monitor", 100m);

            Computer computer = new Computer("HP");

            computer.AddPart(testPart1);
            computer.AddPart(testPart2);

            int expCount = 2;
            int actCount = computer.Parts.Count;

            Assert.AreEqual(expCount, actCount);
        }

        [Test]
        public void AddPartShouldThrowsExceptionWhenAddingNull()
        {
            Computer computer = new Computer("HP");

            Assert.Throws<InvalidOperationException>(() =>
            {
                computer.AddPart(null);
            }, "Cannot add null!");
        }

        [Test]
        public void TotalPriceShouldSumThePricesCorrectly()
        {
            Part testPart1 = new Part("mouse", 5m);
            Part testPart2 = new Part("monitor", 100m);

            Computer computer = new Computer("HP");

            computer.AddPart(testPart1);
            computer.AddPart(testPart2);

            decimal expTotalPrice = 105m;
            decimal actTotalPrice = computer.TotalPrice;

            Assert.AreEqual(expTotalPrice, actTotalPrice);
        }

        [Test]
        public void RemovePartShouldDecreasePartsCountWhenSuccessfull()
        {
            Part testPart1 = new Part("mouse", 5m);
            Part testPart2 = new Part("monitor", 100m);

            Computer computer = new Computer("HP");

            computer.AddPart(testPart1);
            computer.AddPart(testPart2);

            computer.RemovePart(testPart2);

            int expCount = 1;
            int actCount = computer.Parts.Count;

            Assert.AreEqual(expCount, actCount);
        }

        [Test]
        public void GetPartShouldReturnPartCorrectlyWhenSuchPartExists()
        {
            Part testPart1 = new Part("mouse", 5m);
            Part testPart2 = new Part("monitor", 100m);

            Computer computer = new Computer("HP");

            computer.AddPart(testPart1);
            computer.AddPart(testPart2);

            Part newPart = computer.GetPart(testPart1.Name);


            Assert.AreEqual(testPart1, newPart);
        }

        [Test]
        public void GetPartShouldReturnNullWhenThePartDoesntExists()
        {
            Part testPart1 = new Part("mouse", 5m);
            Part testPart2 = new Part("monitor", 100m);

            Computer computer = new Computer("HP");

            computer.AddPart(testPart1);
            computer.AddPart(testPart2);

            Part newPart = computer.GetPart("invalid part name");

            Assert.IsNull(newPart);
        }
    }
}