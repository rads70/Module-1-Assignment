using Module_1_Assignment.Characters;
using Module_1_Assignment.Custom_Exceptions;
using Module_1_Assignment.Items;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Module_1_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mage mage = new Mage();
            Console.WriteLine("New Mage");
            mage.PrintStats();
            Weapon testWand = new Weapon() 
            { WeaponType = Weapons.Wand, 
                Name = "Common wand", 
                RequiredLevel = 1, 
                Slot = Slot.Weapon, 
                WeaponAttributes = new WeaponAttributes() { AttackSpeed = 1.1, Damage = 7 } };
            mage.Equip(testWand);
            Console.WriteLine("Wand equipped");
            mage.PrintStats();
          
            Armour armour = new Armour() { ArmourType = Armours.Cloth, PrimaryAttributes = new PrimaryAttribute() { Vitality = 2,  Intelligence = 1 }, Name = "Head cloth", RequiredLevel = 1, Slot = Slot.Head };
            
           
            
            mage.Equip( armour);


            Console.WriteLine("");
            mage.PrintStats();

           

        } 
      
    }
}
