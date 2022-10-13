using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment.Characters
{
    public class PrimaryAttribute
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Vitality { get; set; }

        public static PrimaryAttribute operator + (PrimaryAttribute lhs, PrimaryAttribute rhs)
        {
            return new PrimaryAttribute 
            { 
                Intelligence = lhs.Intelligence+rhs.Intelligence, 
                Strength = lhs.Strength + rhs.Strength, 
                Dexterity = lhs.Dexterity + rhs.Dexterity,
                Vitality = lhs.Vitality + rhs.Vitality
            };  
        }

    }
}
