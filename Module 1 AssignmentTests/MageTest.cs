using Module_1_Assignment.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Module_1_AssignmentTests
{
    public class MageTest
    {
        [Fact]
        public void Constructor_CreateMageCharacter_ShouldHaveLevelAt1()
        {
            // Arrange
            Mage mage = new Mage();
            int expected = 1;

            // Act
            int actual = mage.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_IncreaseCharactherLevel_ShouldReturnCharactherLevelOf2()
        {
            // Arrange
            Mage mage = new Mage();
            mage.LevelUp(1);
            int expected = 2;

            // Act
            int actual = mage.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void LevelUp_UseLevelUpFunctionWithArgument_ShouldThrowArgumentException(int levels)
        {
            // Arrange
            Mage mage = new Mage();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => mage.LevelUp(levels));
           
        }

        [Fact]
        public void Constructor_MageCreatedWithAttributes_ShouldResultInCorrectVitalityAttributeForLevel1()
        {
            // Arrange
            var mage = new Mage();
            var vitality = 5;
            int expected = vitality;

            // Act
            int actual = mage.PrimaryAttributes.Vitality;

            // Assert

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Constructor_MageCreatedWithAttributes_ShouldResultInCorrectStrengthAttributeForLevel1()
        {
            // Arrange
            var mage = new Mage();
            var strength = 1;
            int expected = strength;

            // Act
            int actual = mage.PrimaryAttributes.Strength;

            // Assert

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Constructor_MageCreatedWithAttributes_ShouldResultInCorrectDextreityAttributeForLevel1()
        {
            // Arrange
            var mage = new Mage();
            var dextreity = 1;
            int expected = dextreity;

            // Act
            int actual = mage.PrimaryAttributes.Dexterity;

            // Assert

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Constructor_MageCreatedWithAttributes_ShouldResultInCorrectIntelligenceAttributeForLevel1()
        {
            // Arrange
            var mage = new Mage();
            var intelligence = 8;
            int expected = intelligence;

            // Act
            int actual = mage.PrimaryAttributes.Intelligence;

            // Assert

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void ClassAttributes_LevelUpMage_ShouldReturnIncreasedVitalityAttribute()
        {
            // Arrange
            var mage = new Mage();
            mage.LevelUp(1);
            var vitality = 8;
            int expected = vitality;

            // Act
            int actual = mage.PrimaryAttributes.Vitality;

            // Assert

            Assert.Equal(expected, actual);
        }




        [Fact]
        public void LevelUp_SecondaryAttributesIncreaseOnLevelUp_ShouldReturnIncreasedSecondaryAttributes()
        {
            // Arrange
            var mage = new Mage();
            mage.LevelUp(1);
            var health = 80;
            int expected = health;

            // Act
            int actual = mage.SecondaryAttributes.Health;

            // Assert

            Assert.Equal(expected, actual);
        }
    }
}
