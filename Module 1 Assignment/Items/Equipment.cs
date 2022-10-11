using Module_1_Assignment.Custom_Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Module_1_Assignment.Items
{
    public class Equipment
    {
        public Dictionary <Slot, Item> EquipmentItems   { get; set; }

       public Equipment()
        {
            EquipmentItems = new Dictionary <Slot, Item>();
            EquipmentItems.Add(Slot.Head, new Armour());
            EquipmentItems.Add(Slot.Body, new Armour());
            EquipmentItems.Add(Slot.Legs, new Armour());
            EquipmentItems.Add(Slot.Weapon, new Weapon());

        }

        public void ShowItems()
        {
            foreach (var key in EquipmentItems.Keys)
            {
                    if(EquipmentItems[key].Name != null)
                    Console.WriteLine($"{key}: {EquipmentItems[key].Name}");
                    else
                    Console.WriteLine($"{key}: Empty slot");
            }
               
        }

        public void AddItem ( Item item)
        {
            EquipmentItems[item.Slot] = item;      
        }

        public void RemoveItem (Item item)
        {
            this.EquipmentItems[item.Slot]= new Item();
        }

    }
}
