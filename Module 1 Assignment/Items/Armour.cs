using Module_1_Assignment.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment.Items
{
    public class Armour:Item
    {
        public Armours ArmourType { get; set; }

        public PrimaryAttribute PrimaryAttributes = new PrimaryAttribute();
    }
}
