using System;
using NUnit.Framework;

using CarManager;

namespace Tests
{
    public class CarTests
    {
        private const string MAKE_FOR_TESTS = "Mercedes";
        private const string MODEL_FOR_TESTS = "CLS 500";
        private const double FUEL_CONSUMPTION_FOR_TESTS = 20;
        private const double FUEL_CAPACITY_FOR_TESTS = 60;

        private Car testCar;

        [SetUp]
        public void Setup()
        {
            this.testCar = new Car(MAKE_FOR_TESTS, MODEL_FOR_TESTS, FUEL_CONSUMPTION_FOR_TESTS, FUEL_CAPACITY_FOR_TESTS);
        }

        [Test]
        public void CarShouldHaveZeroFuelWhenInitialized()
        {
            //Arrange
            double expectedFuel = 0;

            //Act
            double actualFuel = this.testCar.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuel, actualFuel);
        }

        [Test]
        public void MakeShouldSetCorrectly()
        {
            //Arrange
            string expectedMake = MAKE_FOR_TESTS;

            //Act
            string actualMake = this.testCar.Make;

            //Assert
            Assert.AreEqual(expectedMake, actualMake);
        }

        [TestCase("")]
        [TestCase(null)]
        public void MakeShouldThrowAnExceptionWhenIsSetToNullOrEmpty(string make)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.testCar = new Car(make, MODEL_FOR_TESTS, FUEL_CONSUMPTION_FOR_TESTS, FUEL_CAPACITY_FOR_TESTS); //Act
            }, "Make cannot be null or empty!");
        }

        [Test]
        public void ModelShouldSetCorrectly()
        {
            //Arrange
            string expectedModel = MODEL_FOR_TESTS;

            //Act
            string actualModel = this.testCar.Model;

            //Assert
            Assert.AreEqual(expectedModel, actualModel);
        }

        [TestCase("")]
        [TestCase(null)]
        public void ModelShouldThrowAnExceptionWhenIsSetToNullOrEmpty(string model)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.testCar = new Car(MAKE_FOR_TESTS, model, FUEL_CONSUMPTION_FOR_TESTS, FUEL_CAPACITY_FOR_TESTS); //Act
            }, "Model cannot be null or empty!");
        }

        [Test]
        public void FuelConsumptionShouldSetCorrectly()
        {
            //Arrange
            double expectedFuelConsumption = FUEL_CONSUMPTION_FOR_TESTS;

            //Act
            double actualFuelConsumption = this.testCar.FuelConsumption;

            //Assert
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [TestCase(0)]
        [TestCase(-20)]
        public void FuelConsumptionShouldThrowAnExceptionWhenIsSetToZeroOrNegative(double fuelConsumption)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.testCar = new Car(MAKE_FOR_TESTS, MODEL_FOR_TESTS, fuelConsumption, FUEL_CAPACITY_FOR_TESTS); //Act
            }, "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void FuelAmountShouldSetCorrectly()
        {
            //Arrange
            double expectedFuelAmount = this.testCar.FuelAmount;

            //Act
            double actualFuelAmount = this.testCar.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void FuelAmountShouldThrowAnExceptionWhenIsSetToNegative()
        {
            //Assert
            Assert.Throws<System.Reflection.TargetInvocationException>(() =>
            {
                //using Reflection because the setter is private
                this.testCar.GetType().GetProperty("FuelAmount").SetValue(this.testCar, -10); ; //Act
            }, "Fuel amount cannot be negative!");
        }

        [Test]
        public void FuelCapacityShouldSetCorrectly()
        {
            //Arrange
            double expectedFuelCapacity = FUEL_CAPACITY_FOR_TESTS;

            //Act
            double actualFuelCapacity = this.testCar.FuelCapacity;

            //Assert
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [TestCase(0)]
        [TestCase(-100.50)]
        public void FuelCapacityShouldThrowAnExceptionWhenIsSetToZeroOrNegative(double fuelCapacity)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.testCar = new Car(MAKE_FOR_TESTS, MODEL_FOR_TESTS, FUEL_CONSUMPTION_FOR_TESTS, fuelCapacity); //Act
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-5.50)]
        public void RefuelShouldThrowAnExceptionWhenFuelToRefuelIsZeroOrNegative(double fuelToRefuel)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.testCar.Refuel(fuelToRefuel); //Act
            }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(10)]
        [TestCase(14.6)]
        public void RefuelShouldIncreaseTheFuelAmount(double fuelToRefuel)
        {
            //Arrange
            double expectedFuelAmount = this.testCar.FuelAmount + fuelToRefuel;

            //Act
            this.testCar.Refuel(fuelToRefuel);
            double actualFuelAmount = this.testCar.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(FUEL_CAPACITY_FOR_TESTS)]
        [TestCase(FUEL_CAPACITY_FOR_TESTS + 1)]
        public void RefuelShouldSetAmountToFuelCapacityWhenFuelToRefuelIsEqualToOrBiggerThanCapacity(double fuelToRefuel)
        {
            //Arrange
            double expectedFuelAmount = this.testCar.FuelCapacity;

            //Act
            this.testCar.Refuel(fuelToRefuel);
            double actualFuelAmount = this.testCar.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(10)]
        [TestCase(20)]
        public void DriveShouldDecreaseFuelAmount(double distance)
        {
            //Arrange 
            double fuelNeeded = (distance / 100) * this.testCar.FuelConsumption;
            this.testCar.Refuel(20);
            double expectedFuelAmount = this.testCar.FuelAmount - fuelNeeded;

            //Act
            this.testCar.Drive(distance);
            double actualFuelAmount = this.testCar.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(100)]
        [TestCase(240)]
        public void DriveShouldThrowAnExceptionWhenTheFuelAmountIsLessThanFuelNeeded(double distance)
        {
            //Arrange
            double fuelNeeded = (distance / 100) * this.testCar.FuelConsumption;
            this.testCar.Refuel(10);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testCar.Drive(distance); //Act
            }, "You don't have enough fuel to drive!");
        }
    }
}