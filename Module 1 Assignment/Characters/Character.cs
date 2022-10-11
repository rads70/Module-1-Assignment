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

        public abstract void LevelUp(int levels);

        public abstract string Equip (Armour armour);

        public abstract string Equip (Weapon weapon);

        public abstract void CalculateWeaponAttributes();

        public abstract void CalculateElementalResistance();

        protected void CheckRequiredLevel(Item item)
        {
            if (item.RequiredLevel > this.Level)
            {
                if(typeof(Weapon).IsInstanceOfType(item))
                    throw new InvalidWeaponException("Weapon level is higher than character level");
                else
                    throw new InvalidArmourException("Armour level is higher than character level");
            }
        }

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

        public void CalculateTotalAttributes()
        {
            TotalPrimaryAttributes.Vitality = PrimaryAttributes.Vitality;
            TotalPrimaryAttributes.Strength = PrimaryAttributes.Strength;
            TotalPrimaryAttributes.Dexterity = PrimaryAttributes.Dexterity;
            TotalPrimaryAttributes.Intelligence = PrimaryAttributes.Intelligence;

            CalculateSecondaryAttributes();
            CalculateElementalResistance();

            /// <summary>
            /// Calculates Total attributes from PrimaryAttributes on initialization and level up
            /// </summary>
        }

        public void CalculateSecondaryAttributes()
        {
            SecondaryAttributes.Health = TotalPrimaryAttributes.Vitality * 10;
            SecondaryAttributes.ArmourRating = TotalPrimaryAttributes.Strength + TotalPrimaryAttributes.Dexterity;

            /// <summasy>
            /// 
            /// </summasy>
        }

        public void CalculateArmourAttributes()
        {
            foreach (var item in Items.EquipmentItems.Values)
            {
                if (item.GetType() == typeof(Armour))
                {
                    Armour armour = item as Armour;

                    TotalPrimaryAttributes.Vitality += armour.PrimaryAttributes.Vitality;
                    TotalPrimaryAttributes.Strength += armour.PrimaryAttributes.Strength;
                    TotalPrimaryAttributes.Dexterity += armour.PrimaryAttributes.Dexterity;
                    TotalPrimaryAttributes.Intelligence += armour.PrimaryAttributes.Intelligence;

                    
                }
                
            }
            CalculateSecondaryAttributes();
            CalculateElementalResistance();
            CalculateWeaponAttributes();
        }

         
       

       
        
    }
}
