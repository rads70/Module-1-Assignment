using Module_1_Assignment.Custom_Exceptions;
using Module_1_Assignment.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module_1_Assignment.Characters
{
    public class Warrior : Character
    {
        public Warrior()
        {
            Name = "Tom the Warrior";
            PrimaryAttributes.Vitality = 10;
            PrimaryAttributes.Strength = 5;
            PrimaryAttributes.Dexterity = 2;
            PrimaryAttributes.Intelligence = 1;

            CalculateTotalAttributes();
            CalculateWeaponAttributes();
        }

        public override void CalculateWeaponAttributes()
        {
            Weapon weapon = (Weapon)Items.EquipmentItems[Slot.Weapon];


            if (weapon.WeaponDPS() == 0)
                DPS = ((double)TotalPrimaryAttributes.Strength / 100 + 1);
            else
                DPS = (weapon.WeaponDPS() * ((double)TotalPrimaryAttributes.Strength / 100 + 1));
        }

        public override void CalculateElementalResistance()
        {
            SecondaryAttributes.ElementalResistance = TotalPrimaryAttributes.Strength;
        }

        public override void LevelUp(int levels)
        {
            if (levels < 1) throw new ArgumentException("Level must be 1 or higher");

            PrimaryAttributes.Vitality += 5 * levels;
            PrimaryAttributes.Strength += 3 * levels;
            PrimaryAttributes.Dexterity += 2 * levels;
            PrimaryAttributes.Intelligence += 1 * levels;

            Level += levels;

            CalculateTotalAttributes();
        }

        public override string Equip(Weapon weapon)
        {
            CheckRequiredLevel(weapon);

            if (weapon.WeaponType == Weapons.Axe || weapon.WeaponType == Weapons.Hammer || weapon.WeaponType == Weapons.Sword)
            {
                Items.AddItem(weapon);
               CalculateWeaponAttributes(); 
            }
            else throw new InvalidWeaponException("Wrong weapon type for Warrior");

            return "New weapon equipped!";
        }

        public override string Equip(Armour armour)
        {
            CheckRequiredLevel(armour);

            if (armour.ArmourType == Armours.Mail || armour.ArmourType == Armours.Plate)
            {
                Items.AddItem(armour);
                CalculateArmourAttributes();
            }
            else
                throw new InvalidArmourException("Wrong armour type for Warrior");

            return "New armour equipped!";
        }
    }
}
