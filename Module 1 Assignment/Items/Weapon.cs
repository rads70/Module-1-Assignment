using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment.Items
{
    public class Weapon:Item
    {

        public Weapons WeaponType { get; set; }

        public WeaponAttributes WeaponAttributes =new WeaponAttributes();

        /// <summary>
        /// Calculates the weapon DPS
        /// </summary>
        /// <returns>Weapon DPS</returns>
       public double WeaponDPS()
        {
            return WeaponAttributes.Damage * WeaponAttributes.AttackSpeed;
        }
    }
}
