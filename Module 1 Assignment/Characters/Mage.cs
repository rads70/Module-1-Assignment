using Module_1_Assignment.Custom_Exceptions;
using Module_1_Assignment.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment.Characters
{
    public class Mage : Character
    {
         public Mage()
        {
            Name = "Fred the Mage";
            PrimaryAttributes.Vitality = 5;
            PrimaryAttributes.Strength = 1;
            PrimaryAttributes.Dexterity = 1;
            PrimaryAttributes.Intelligence = 8;

            CalculateTotalAttributes();
          
        }
        public override void CalculateWeaponAttributes()
        {
            Weapon weapon = (Weapon)Items.GetWeapon();
            if (weapon.WeaponDPS() == 0) 
                DPS = ((double) TotalPrimaryAttributes.Intelligence / 100 + 1);
            else
                DPS = (weapon.WeaponDPS() * (1 + ((double)TotalPrimaryAttributes.Intelligence / 100))); 
        }

        public override void LevelUp(int levels)
        {
            if (levels < 1) throw new ArgumentException("Level must be 1 or higher");

            PrimaryAttributes.Vitality += 3 * levels;
            PrimaryAttributes.Strength += 1 * levels;
            PrimaryAttributes.Dexterity += 1 * levels;
            PrimaryAttributes.Intelligence += 5 * levels;

            Level += levels;

            CalculateTotalAttributes();
            
        }

        public override string Equip(Weapon weapon)
        {
           
            RequiredLevel.CheckLevel(weapon, this.Level);

            if (weapon.WeaponType == Weapons.Staff || weapon.WeaponType == Weapons.Wand)
            {
            Items.AddItem( weapon);
                CalculateWeaponAttributes();
            }
            
            else throw new InvalidWeaponException("Wrong weapon type for Mage");

            return "New weapon equipped!";
        }

        public override string Equip( Armour armour)
        {
            RequiredLevel.CheckLevel(armour, this.Level);

            if (armour.ArmourType != Armours.Cloth) throw new InvalidArmourException("Wrong armour type for Mage");

            Items.AddItem(armour);
            CalculateTotalAttributes();

            return "New armour equipped!";

        }
        
    }
}
