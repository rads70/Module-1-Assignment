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
        /// </summary>
        /// <param name="armour"></param>
        /// <returns>Message if equipped</returns>
        /// <exception cref="InvalidArmourException">When armour is not valid for character</exception>
        public abstract string Equip (Armour armour);

        /// <summary>
        /// Equips character with weapon replacing any weapon in weapon slot
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Message if equipped</returns>
        /// <exception cref="InvalidWeaponException">When weapon is invalid for character</exception>
        public abstract string Equip (Weapon weapon);

        /// <summary>
        /// Calculates Character DPS based on Characters main attribute and Weapon
        /// </summary>
        public abstract void CalculateWeaponAttributes();

        /// <summary>
        /// Prints out character stats to console.
        /// </summary>
        public void PrintStats()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}\r\n");
            sb.Append($"Level: {Level}\r\n");
            sb.Append($"Vitality: {TotalPrimaryAttributes.Vitality}\r\n");
            sb.Append($"Strength: {TotalPrimaryAttributes.Strength}\r\n");
            sb.Append($"Dexterity: {TotalPrimaryAttributes.Dexterity}\r\n");
            sb.Append($"Intelligence: {TotalPrimaryAttributes.Intelligence}\r\n");
            sb.Append($"Health: {SecondaryAttributes.Health}\r\n");
            sb.Append($"Elemental Resistance: {SecondaryAttributes.ElementalResistance}\r\n");
            sb.Append($"Character DPS: {Math.Round(this.DPS, 2)}");
            
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Calculates Total attributes for character
        /// Primary, Secondary and Character DPS
        /// </summary>
        public void CalculateTotalAttributes()
        {

            // Add all primary atttributes from armour
             
            TotalPrimaryAttributes =  PrimaryAttributes + Items.GetArmour(Slot.Head).PrimaryAttributes + Items.GetArmour(Slot.Legs).PrimaryAttributes + Items.GetArmour(Slot.Body).PrimaryAttributes;

            // Set secondary attributes from Total attributes
            SecondaryAttributes.Health = TotalPrimaryAttributes.Vitality * 10;
            SecondaryAttributes.ArmourRating = TotalPrimaryAttributes.Strength + TotalPrimaryAttributes.Dexterity;
            SecondaryAttributes.ElementalResistance = TotalPrimaryAttributes.Intelligence;

            CalculateWeaponAttributes();

        }
    }
}
