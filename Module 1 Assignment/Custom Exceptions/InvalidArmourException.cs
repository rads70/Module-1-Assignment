using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment.Custom_Exceptions
{
    public class InvalidArmourException : Exception
    {
        public InvalidArmourException(string message) : base(message)
        {

        }
    }
}
