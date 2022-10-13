using Module_1_Assignment.Custom_Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Module_1_Assignment.Items
{
   

    public class Equipment
    {

       private Dictionary <Slot, Item> EquipmentItems { get; set; }

        public Equipment()
        {
            EquipmentItems = new Dictionary<Slot, Item>()
            {
                { Slot.Head, new Armour() },
                { Slot.Body, new Armour() },
                { Slot.Legs, new Armour() },
                { Slot.Weapon, new Weapon() }
            };
        }
        /// <summary>
        /// Adds item to slot based on items slot property
        /// </summary>
        /// <param name="item"></param>
        public void AddItem ( Item item)
        {
            EquipmentItems[item.Slot] = item;      
        }

        /// <summary>
        /// Gets armour item from Equipment from slot
        /// </summary>
        /// <param name="itemSlot"></param>
        /// <returns>Armour item</returns>
        public Armour GetArmour ( Slot itemSlot)
        {
               return EquipmentItems[itemSlot] as Armour;
        }

        /// <summary>
        /// Gets weapon from weapon slot
        /// </summary>
        /// <returns>Weapon Item</returns>
        public Weapon GetWeapon()
        {
            return EquipmentItems[Slot.Weapon] as Weapon;
        }
     

    }
}
