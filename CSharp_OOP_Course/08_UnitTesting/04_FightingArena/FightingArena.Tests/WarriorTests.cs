using System;
using NUnit.Framework;

using FightingArena;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            //Arrange
            string expectedName = "Pesho";
            int expectedDamage = 30;
            int expectedHP = 80;

            //Act
            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHP = warrior.HP;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHP, actualHP);
        }

        [TestCase("")]
        [TestCase("      ")]
        [TestCase(null)]
        public void NameShouldThrowAnExpectionWhenIsNullOrEmptyOrWhiteSpace(string name)
        {
            //Arrange
            int warriorDamage = 20;
            int warriorHP = 100;

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, warriorDamage, warriorHP); //Act
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(-20)]
        [TestCase(0)]
        public void DamageShouldThrowAnExpectionWhenIsNegativeOrZero(int warriorDamage)
        {
            //Arrange
            string warriorName = "Gosho";
            int warriorHP = 100;

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(warriorName, warriorDamage, warriorHP); //Act
            }, "Damage value should be positive!");
        }

        [Test]
        public void HPShouldThrowsAnExpectionWhenIsNegative()
        {
            //Arrange
            string warriorName = "Gosho";
            int warriorDamage = 30;
            int warriorHP = -10;

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(warriorName, warriorDamage, warriorHP); //Act
            }, "HP should not be negative!");
        }

        [Test]
        public void AttackingWithLowerHPThanTheRequiredShouldTHrowAnExcpetion()
        {
            //Arrange
            Warrior atacker = new Warrior("Gosho", 20, 25);
            Warrior defender = new Warrior("Pesho", 30, 30);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                atacker.Attack(defender); //Act
            }, "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void AttackingEnemyWithLowerHPThanTheMinimumRequiredShouwlThrowAnExcpetion()
        {
            //Arrange
            Warrior atacker = new Warrior("Gosho", 20, 31);
            Warrior defender = new Warrior("Pesho", 30, 10);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                atacker.Attack(defender); //Act
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void AtackingStrongerEnemiesShouldThrowAnExpetion()
        {
            //Arrange
            Warrior atacker = new Warrior("Gosho", 20, 31);
            Warrior defender = new Warrior("Pesho", 50, 10);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                atacker.Attack(defender); //Act
            }, "You are trying to attack too strong enemy");
        }

        [Test]
        public void AttackShouldDecreaseTheHPOfTheTwoWarriors()
        {
            //Arrange
            Warrior atacker = new Warrior("Gosho", 20, 65);
            Warrior defender = new Warrior("Pesho", 15, 40);

            int expectedAHP = atacker.HP - defender.Damage;
            int expectedDHP = defender.HP - atacker.Damage;

            //Act
            atacker.Attack(defender);

            int actualAHP = atacker.HP;
            int actualDHP = defender.HP;

            //Assert
            Assert.AreEqual(expectedAHP, actualAHP);
            Assert.AreEqual(expectedDHP, actualDHP);
        }

        [Test]
        public void TestKillingEnemyWithAttack()
        {
            //Arrange
            Warrior atacker = new Warrior("Gosho", 50, 65);
            Warrior defender = new Warrior("Pesho", 15, 40);

            int expectedDHP = 0;

            //Act
            atacker.Attack(defender);

            int actualDHP = defender.HP;

            //Assert
            Assert.AreEqual(expectedDHP, actualDHP);
        }
    }
}