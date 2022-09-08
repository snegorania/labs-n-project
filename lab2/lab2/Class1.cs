using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Class1
    {
        public static List<string> names = new List<string>();
        public static void zagz(string name) {
            for (int i = 0; i < name.Length; i++)
            {
                if ((int)name[i] < 65 || ((int)name[i] > 90 && (int)name[i] < 97) || (int)name[i] > 122)
                {
                    throw new exeptionZagz("error");
                }
                else
                {
                    names.Add(name); 
                }
            }

        }
    }
}
