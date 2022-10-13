using Module_1_Assignment.Custom_Exceptions;
using Module_1_Assignment.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public double DPS { get; set; }

        public PrimaryAttribute PrimaryAttributes = new();
        public PrimaryAttribute TotalPrimaryAttributes = new();
        public SecondaryAttribute SecondaryAttributes = new();

        public Equipment Items = new Equipment();

        /// <summary>
        /// Levels up character and increases characters primary attributes
        /// </summary>
        /// <param name="levels"></param>
        public abstract void LevelUp(int levels);

        /// <summary>
        /// Equips character with armour replacing any armour in current slot.
        /// Throws InvalidArmourException for invalid armour for character
        /// </summary>
        /// <param name="armour"></param>
        /// <returns>Message if equipped</returns>
        public abstract string Equip (Armour armour);

        /// <summary>
        /// Equips character with weapon replacing any weapon in weapon slot
        /// Throws InvalidWeaponException for invalid weapon for character
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Message if equipped</returns>
        public abstract string Equip (Weapon weapon);

        /// <summary>
        /// Calculates Character DPS based on Class and Weapon
        /// </summary>
        public abstract void CalculateWeaponAttributes();

        public void PrintStats()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}  ");
            sb.Append($"Level: {Level}   ");
            sb.Append($"Vitality: {TotalPrimaryAttributes.Vitality}  ");
            sb.Append($"Strength: {TotalPrimaryAttributes.Strength} ");
            sb.Append($"Dexterity: {TotalPrimaryAttributes.Dexterity}  ");
            sb.Append($"Intelligence: {TotalPrimaryAttributes.Intelligence} ");
            sb.Append($"Health: {SecondaryAttributes.Health} ");
            sb.Append($"Elemental Resistance: {SecondaryAttributes.ElementalResistance} ");
            sb.Append($"Character DPS: {this.DPS} ");
            
            Console.WriteLine(sb);
        }

        /// <summary>
        /// Calculates Total attributes for character
        /// Primary, Secondary and Character DPS
        /// </summary>
        public void CalculateTotalAttributes()
        {

            PrimaryAttribute armourAttributes = new PrimaryAttribute();

            armourAttributes = Items.GetArmour(Slot.Head).PrimaryAttributes + Items.GetArmour(Slot.Legs).PrimaryAttributes + Items.GetArmour(Slot.Body).PrimaryAttributes;

            TotalPrimaryAttributes =  PrimaryAttributes + armourAttributes;

            SecondaryAttributes.Health = TotalPrimaryAttributes.Vitality * 10;
            SecondaryAttributes.ArmourRating = TotalPrimaryAttributes.Strength + TotalPrimaryAttributes.Dexterity;
            SecondaryAttributes.ElementalResistance = TotalPrimaryAttributes.Intelligence;

            CalculateWeaponAttributes();

        }
 
        
    }
}
