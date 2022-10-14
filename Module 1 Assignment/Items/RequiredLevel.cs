using Module_1_Assignment.Custom_Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment.Items
{
    public class RequiredLevel
    {
        /// <summary>
        /// Checks required level of item against character level.
        /// </summary>
        /// <param name="equipment"> Equipment Item</param>
        /// <param name="characterLevel"> Character level property</param>
        /// <exception cref="InvalidWeaponException"></exception>
        /// <exception cref="InvalidArmourException"></exception>
        public static void CheckLevel (Item equipment, int characterLevel)
        {
            if (equipment.RequiredLevel > characterLevel)
            {
                if (typeof(Weapon).IsInstanceOfType(equipment))
                    throw new InvalidWeaponException("Weapon level is higher than character level");
                else
                    throw new InvalidArmourException("Armour level is higher than character level");
            }
        }
    }
}
