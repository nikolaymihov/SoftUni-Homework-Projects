using System;
using NUnit.Framework;

using FightingArena; 

namespace Tests
{
    public class ArenaTests
    {
        private Arena testingArena;
        private Warrior testingWarrior;
        private Warrior testingAttacker;
        private Warrior testingDefender;

        [SetUp]
        public void Setup()
        {
            this.testingArena = new Arena();
            this.testingWarrior = new Warrior("Goshko", 20, 50);
            this.testingAttacker = new Warrior("Arnold", 50, 80);
            this.testingDefender = new Warrior("Johny", 30, 60);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            //Assert
            Assert.IsNotNull(this.testingArena.Warriors);
        }

        [Test]
        public void EnrollShouldAddWarriorToTheArena()
        {
            //Act
            this.testingArena.Enroll(this.testingWarrior);

            //Assert
            Assert.That(this.testingArena.Warriors, Has.Member(this.testingWarrior));
        }

        [Test]
        public void EnrollShouldIncreaseCount()
        {
            //Arrange
            int expectedCount = 2;

            //Act
            this.testingArena.Enroll(this.testingWarrior);
            this.testingArena.Enroll(new Warrior("Pesho", 30, 100));

            int actualCount = this.testingArena.Warriors.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void EnrollAnExistingWarriorShouldThrowAnException()
        {
            //Arrange
            this.testingArena.Enroll(this.testingWarrior);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testingArena.Enroll(this.testingWarrior); //Act
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void EnrollTwoWarriorsWithTheSameNamesShouldThrowAnException()
        {
            //Arrange
            this.testingArena.Enroll(this.testingWarrior);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testingArena.Enroll(new Warrior(this.testingWarrior.Name, 30, 30)); //Act
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void TestFightingWithMissingAttackerShouldThrowAnExcpetion()
        {
            //Arrange
            this.testingArena.Enroll(this.testingDefender);

            //
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testingArena.Fight(this.testingAttacker.Name, this.testingDefender.Name);
            }, $"There is no fighter with name {this.testingAttacker.Name} enrolled for the fights!");
        }

        [Test]
        public void TestFightingWithMissingDefender()
        {
            //Arrange
            this.testingArena.Enroll(this.testingAttacker);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testingArena.Fight(this.testingAttacker.Name, this.testingDefender.Name); //Act

            }, $"There is no fighter with name {this.testingDefender.Name} enrolled for the fights!");
        }

        [Test]
        public void TestFightingBetweenTwoWarriors()
        {
            //Arrange
            int expectedAHP = this.testingAttacker.HP - this.testingDefender.Damage;
            int expectedDHP = this.testingDefender.HP - this.testingAttacker.Damage;

            this.testingArena.Enroll(this.testingAttacker);
            this.testingArena.Enroll(this.testingDefender);

            //Act
            this.testingArena.Fight(this.testingAttacker.Name, this.testingDefender.Name);

            int actualAHP = this.testingAttacker.HP;
            int actualDHP = this.testingDefender.HP;

            //Assert
            Assert.AreEqual(expectedAHP, actualAHP);
            Assert.AreEqual(expectedDHP, actualDHP);
        }
    }
}
