using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_1_Assignment.Characters;
using Module_1_Assignment.Items;
using Module_1_Assignment.Custom_Exceptions;
using Xunit;
using Xunit.Sdk;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Module_1_AssignmentTests
{
    public class EquipmentTests
    {
        #region Equip

        [Fact]
        public void Equip_EquipHigherLevelWeaponToCharacter_ShouldReturnInvalidException()
        {
            // Arrange
            Warrior warrior = new Warrior();
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                RequiredLevel = 2,
                Slot = Slot.Weapon,
                WeaponType = Weapons.Axe,
                WeaponAttributes = new WeaponAttributes() { AttackSpeed = 1.1, Damage = 7 }
            };

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.Equip(testAxe));
        }

        [Fact] 
        public void Equip_EquipCharacterWithHigherLevelArmour_ShouldReturnInvalidArmourException()
        {
            var warrior = new Warrior();
            Armour testPlateBody = new Armour()
            {
                Name = "Common plate body armour",
                RequiredLevel = 2,
                Slot = Slot.Body,
                ArmourType = Armours.Plate,
                PrimaryAttributes = new PrimaryAttribute() { Vitality = 2, Strength = 1 }
            };

            // Act and Assert
            Assert.Throws<InvalidArmourException>(() => warrior.Equip(testPlateBody));
        }

        [Fact]
        public void Equip_EquipCharacterWithWrongWeaponType_ShouldReturnInvalidWeaponException()
        {
            // Arrange
            Warrior warrior = new Warrior();
            Weapon testBow = new Weapon()
            {
                Name = "Common bow",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                WeaponType = Weapons.Bow,
                WeaponAttributes = new WeaponAttributes() { AttackSpeed = 0.8, Damage = 12 }
            };

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.Equip(testBow));
        }

        [Fact]
        public void Equip_EquipCharacterWithWrongArmourType_ShouldReturnInvalidArmourException()
        {
            var warrior = new Warrior();
            Armour testClothHead = new Armour()
            {
                Name = "Common cloth head armour",
                RequiredLevel = 1,
                Slot = Slot.Head,
                ArmourType = Armours.Cloth,
                PrimaryAttributes = new PrimaryAttribute() { Vitality = 1, Intelligence = 5 }
            };

            // Act and Assert
            Assert.Throws<InvalidArmourException>(() => warrior.Equip(testClothHead));
        }

        [Fact]
        public void Equip_EquipAValidWeaponToCharacter_ShouldReturnASuccessMessageNewWeaponEquipped()
        {
            // Arrange
            Warrior warrior = new Warrior();
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                WeaponType = Weapons.Axe,
                WeaponAttributes = new WeaponAttributes() { AttackSpeed = 1.1, Damage = 7 }
            };
            string expected = "New weapon equipped!";

            // Act
            string actual = warrior.Equip(testAxe);

            // Assert
            Assert.Equal(expected, actual); 
        }

        [Fact]
        public void Equip_EquipAValidArmourToCharacter_ShouldReturnASuccessMessageNewArmourEquipped()
        {
            // Arrange
            var warrior = new Warrior();
            Armour testPlateBody = new Armour()
            {
                Name = "Common plate body armour",
                RequiredLevel = 1,
                Slot = Slot.Body,
                ArmourType = Armours.Plate,
                PrimaryAttributes = new PrimaryAttribute() { Vitality = 2, Strength = 1 }
            };
            string expected = "New armour equipped!";

            // Act
            string actual = warrior.Equip(testPlateBody);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equip_EquipWarriorWithArmour_ShouldReturnIncreasedTotalPrimaryAttributeVitality()
        {
            // Arrange

            Warrior warrior = new Warrior();
            Armour testPlateBody = new Armour()
            {
                Name = "Common plate body armour",
                RequiredLevel = 1,
                Slot = Slot.Body,
                ArmourType = Armours.Plate,
                PrimaryAttributes = new PrimaryAttribute() { Vitality = 2, Strength = 1 }
            };

            int initialValue = 10;
            int addedValue = 2;
            int expected = initialValue + addedValue;

            // Act
            warrior.Equip(testPlateBody);
            int actual = warrior.TotalPrimaryAttributes.Vitality;

            // Assert
            Assert.Equal(expected, actual);
        }

       

        #endregion

        #region Calculate DPS

        [Fact]
        public void CalculateTotalAttributes_CalculateDPSIfNoWeaponIsEquipped_ShouldReturnWeaponDPSas1()
        {
            // Arrange
            Warrior warrior = new Warrior();
            double expected = 1 * 1.05;

            // Act
            double actual = warrior.DPS;

            // Assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void CalculateTotalAttributes_CalculateDPSWithWeaponEquipped_ShouldReturnDPS()
        {
            // Arrange
            Warrior warrior = new Warrior();
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                WeaponType = Weapons.Axe,
                WeaponAttributes = new WeaponAttributes() { AttackSpeed = 1.1, Damage = 7 }
            };
            double expected = 7*1.1*1.05;

            // Act
            warrior.Equip(testAxe);
            double actual = warrior.DPS;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateTotalAttributes_CalculateDPSWIthWeaponAndArmourEquipped_ShouldReturnValidDPS()
        {
            // Arrange
            Warrior warrior = new Warrior();
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                WeaponType = Weapons.Axe,
                WeaponAttributes = new WeaponAttributes() { AttackSpeed = 1.1, Damage = 7 }
            };
            Armour testPlateBody = new Armour()
            {
                Name = "Common plate body armour",
                RequiredLevel = 1,
                Slot = Slot.Body,
                ArmourType = Armours.Plate,
                PrimaryAttributes = new PrimaryAttribute() { Vitality = 2, Strength = 1 }
            };

            double expected = 7.7 * 1.06;

            // Act
            warrior.Equip(testAxe);
            warrior.Equip(testPlateBody);
            double actual = warrior.DPS;

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Equip_EquipWarriorWithWeapon_ShouldReturnIncreasedCharacterDPS()
        {
            // Arrange
            double attackSpeed = 1.1;
            double damage = 7;
            Warrior warrior = new Warrior();
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                WeaponType = Weapons.Axe,
                WeaponAttributes = new WeaponAttributes() { AttackSpeed = attackSpeed, Damage = damage }
            };
            double strength = 5;
            double weaponDPS = attackSpeed * damage;
            double expected = weaponDPS * (1 + strength / 100);

            // Act
            warrior.Equip(testAxe);
            var actual = warrior.DPS;
            // Assert
            Assert.Equal(expected, actual);
        }

        #endregion

        [Fact]
        public void AddItem_AddItemToWarriorWithWeapon_ShouldReturnWeaponFromWeaponSlot()
        {
            // Arrange
            Warrior warrior = new Warrior();
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                WeaponType = Weapons.Axe,
                WeaponAttributes = new WeaponAttributes() { AttackSpeed = 1.1, Damage = 7 }
            };
            Weapon expected = testAxe;

            // Act
            warrior.Items.AddItem(expected);
            var actual = warrior.Items.GetWeapon();
            // Assert
            Assert.Equal(expected, actual);
        }

       

        [Fact]
        public void WeaponDPS_CreateNewNewWeapon_ShouldReturnWeaponDPSAttackSpeedMultipliedByDamage()
        {
            // Arrange
            double attackSpeed = 1.1;
            double damage = 7;
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                WeaponType = Weapons.Axe,
                WeaponAttributes = new WeaponAttributes() { AttackSpeed = attackSpeed, Damage = damage }
            };
            
            double expected = attackSpeed * damage;

            // Act

            var actual = testAxe.WeaponDPS();
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddItem_EquipWarriorWithBodyArmour_ShouldReturnBodyArmourInBodySlot()
        {
            var warrior = new Warrior();
            Armour testPlateBody = new Armour()
            {
                Name = "Common plate body armour",
                RequiredLevel = 1,
                Slot = Slot.Body,
                ArmourType = Armours.Plate,
                PrimaryAttributes = new PrimaryAttribute() { Vitality = 2, Strength = 1 }
            };
            Armour expected = testPlateBody;


            // Act
            warrior.Items.AddItem(expected);
            var actual = warrior.Items.GetArmour(Slot.Body);

            // Assert
            Assert.Equal(expected, actual);
        }

       
    }
}
