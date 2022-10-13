using Module_1_Assignment.Custom_Exceptions;
using Module_1_Assignment.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment.Characters
{
    public class Ranger : Character
    {
        public Ranger()
        {
            Name = "Ralph the Ranger";
            PrimaryAttributes.Vitality = 8;
            PrimaryAttributes.Strength = 1;
            PrimaryAttributes.Dexterity = 7;
            PrimaryAttributes.Intelligence = 1;

            CalculateTotalAttributes();
        }

        public override void CalculateWeaponAttributes()
        {
            Weapon weapon = (Weapon)Items.GetWeapon();
            if (weapon.WeaponDPS() == 0)
                DPS = ((double)TotalPrimaryAttributes.Dexterity / 100 + 1);
            else
                DPS = (weapon.WeaponDPS() * ((double)TotalPrimaryAttributes.Dexterity / 100 + 1));
        }

        public override void LevelUp(int levels)
        {
            if (levels < 1) throw new ArgumentException("Level must be 1 or higher");

            PrimaryAttributes.Vitality += 2 * levels;
            PrimaryAttributes.Strength += 1 * levels;
            PrimaryAttributes.Dexterity += 5 * levels;
            PrimaryAttributes.Intelligence += 1 * levels;

            Level += levels;

            CalculateTotalAttributes();
        }

        public override string Equip(Weapon weapon)
        {
            RequiredLevel.CheckLevel(weapon, this.Level);

            if (weapon.WeaponType == Weapons.Bow)
                {
                Items.AddItem(weapon);
                CalculateWeaponAttributes();
                }

            else throw new InvalidWeaponException("Wrong weapon type for Ranger");

            return "New weapon equipped!";
        }

        public override string Equip(Armour armour)
        {
            RequiredLevel.CheckLevel(armour, this.Level);

            if (armour.ArmourType == Armours.Mail || armour.ArmourType == Armours.Leather)
                {
                Items.AddItem(armour);
                CalculateTotalAttributes();
                }
            else
                throw new InvalidArmourException("Wrong armour type for Ranger");

            return "New armour equipped!";
        }
    }
}
