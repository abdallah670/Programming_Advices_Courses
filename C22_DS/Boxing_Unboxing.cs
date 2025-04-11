using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C22_DS
{
    public class Boxing_Unboxing
    {
        // Boxing
        public  static void Boxing()
        {
            int i = 123;
            object o = i; // Boxing
            Console.WriteLine(o);
        }
        // Unboxing
        public static void Unboxing()
        {
            object o = 123;
            int i = (int)o; // Unboxing
            Console.WriteLine(i);
        }
    }
}
