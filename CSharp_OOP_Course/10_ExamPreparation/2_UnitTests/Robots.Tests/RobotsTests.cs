using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace Robots.Tests
{

    [TestFixture]
    public class RobotsTests
    {

        [Test]
        public void TestIfRobotConstructorWorksCorrectly()
        {
            string expName = "Test_Robot123";
            int expMaximumBattery = 100;
            int expBattery = 100;

            Robot robot = new Robot(expName, expMaximumBattery);

            string actName = robot.Name;
            int actMaximumBattery = robot.MaximumBattery;
            int actBattery = robot.Battery;

            Assert.AreEqual(expName, actName);
            Assert.AreEqual(expMaximumBattery, actMaximumBattery);
            Assert.AreEqual(expBattery, actBattery);
        }

        [Test]
        public void RobotManagerConstructorShouldSetCapacityCorreclty()
        {
            int expCapacity = 20;

            RobotManager robotManager = new RobotManager(expCapacity);

            int actCapacity = robotManager.Capacity;

            Assert.AreEqual(expCapacity, actCapacity);
        }

        [Test]
        public void RobotManagerConstructorShouldInitializeTheRobbotsCollection()
        {
            int expCapacity = 20;

            RobotManager robotManager = new RobotManager(expCapacity);


            Assert.That(robotManager.Count == 0);
        }

        [Test]
        public void CapacityThatIsBelowZeroShouldThrowsException()
        {
            int invalidCapacity = -20;

            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(invalidCapacity);
            }, "Invalid capacity!");
        }

        [Test]
        public void AddShouldThrowsExceptionWhenRobbotWithTheSameNameAlreadyExists()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot1 = new Robot("Gosho", 30);

            robotManager.Add(robot1);

            Robot robot2 = new Robot("Gosho", 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot2);
            }, $"There is already a robot with name {robot2.Name}!");
        }

        [Test]
        public void AddWhenTheCapacityIsReachedShouldThrowsException()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot1 = new Robot("Gosho", 30);

            robotManager.Add(robot1);

            Robot robot2 = new Robot("Pesho", 20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot2);
            }, "Not enough capacity!");
        }

        [Test]
        public void AddShouldIncreaseCountWhenAddSuccessfully()
        {
            RobotManager robotManager = new RobotManager(5);

            Robot robot1 = new Robot("Gosho", 30);

            robotManager.Add(robot1);

            Assert.That(robotManager.Count == 1);

            Robot robot2 = new Robot("Pesho", 20);

            robotManager.Add(robot2);

            Assert.That(robotManager.Count == 2);
        }

        [Test]
        public void RemoveShouldThrowsExcpetionWhenSuchRobotDoesntExist()
        {
            RobotManager robotManager = new RobotManager(5);

            Robot testRobot1 = new Robot("Pesho", 50);
            Robot testRobot2 = new Robot("Gosho", 100);

            robotManager.Add(testRobot1);
            robotManager.Add(testRobot2);

            string invalidName = "Stamat";

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove(invalidName);
            }, $"Robot with the name {invalidName} doesn't exist!");
        }

        [Test]
        public void RemoveShouldDecreaseCountWhenRemovedSuccessfully()
        {
            RobotManager robotManager = new RobotManager(5);

            Robot testRobot1 = new Robot("Pesho", 50);
            Robot testRobot2 = new Robot("Gosho", 100);

            robotManager.Add(testRobot1);
            robotManager.Add(testRobot2);

            int expCount = 1;

            robotManager.Remove("Pesho");

            int actCount = robotManager.Count;

            Assert.AreEqual(expCount, actCount);

        }

        [Test]
        public void WorkShouldThrowsExceptionWhenRobbotDoesntExist()
        {
            RobotManager robotManager = new RobotManager(10);

            string invalidName = "Pesho";

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(invalidName, "uselessJob", 20);
            }, $"Robot with the name {invalidName} doesn't exist!");
        }

        [Test]
        public void WorkShouldThrowsExceptionWhenRobbotDoesntHaveEnoughBattery()
        {
            RobotManager robotManager = new RobotManager(10);

            string robotName = "Gosho";
            Robot testRobot1 = new Robot(robotName, 10);

            robotManager.Add(testRobot1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(robotName, "uselessJob", 20);
            }, $"{robotName} doesn't have enough battery!");
        }

        [Test]
        public void WorkShouldDecreaseRobotBattery()
        {
            RobotManager robotManager = new RobotManager(10);

            string robotName = "Gosho";
            Robot testRobot1 = new Robot(robotName, 50);

            robotManager.Add(testRobot1);

            robotManager.Work(robotName, "uselessJob", 20);

            int expBattery = 30;
            int actBattery = testRobot1.Battery;

            Assert.AreEqual(expBattery, actBattery);
        }

        [Test]
        public void ChargeShouldThrowsExceptionWhenRobbotDoesntExist()
        {
            RobotManager robotManager = new RobotManager(10);

            string invalidName = "Pesho";

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge(invalidName);
            }, $"Robot with the name {invalidName} doesn't exist!");
        }

        [Test]
        public void ChargeShouldSetRobotBatteryToMaximum()
        {
            RobotManager robotManager = new RobotManager(10);

            string robotName = "Gosho";
            Robot testRobot1 = new Robot(robotName, 50);

            robotManager.Add(testRobot1);

            robotManager.Work(robotName, "uselessJob", 20);
            robotManager.Charge(robotName);


            int expBattery = 50;
            int actBattery = testRobot1.Battery;

            Assert.AreEqual(expBattery, actBattery);
        }
    }
}
