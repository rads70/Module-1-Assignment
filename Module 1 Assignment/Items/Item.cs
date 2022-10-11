using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment.Items
{
    public class Item
    {
        public string Name { get; set; } 
        public int RequiredLevel { get; set; }
        public Slot Slot { get; set; }

    }
}
