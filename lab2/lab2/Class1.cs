using System;
using System.Collections.Generic;

namespace lab2
{
    class Class1
    {
        public static List<string> names = new List<string>();

        public static void HelpUser()
        {
            Console.WriteLine("kill - exit \nAdd - Creating of new item \nAll - List output \nDelete - Removing from the list \nHelp - Command list");
        }

        public static void Zagz(string name) {
            for (int i = 0; i < name.Length; i++)
            {
                if ((int)name[i] < 65 || ((int)name[i] > 90 && (int)name[i] < 97) || (int)name[i] > 122)
                {
                    throw new ExeptionZagz("Name error");
                }
            }

            names.Add(name);
            Console.WriteLine("Success");
        }

        public static void ListOfNames()
        {
            int i = 0;

            foreach (string item in names)
            {
                Console.WriteLine(i++ + " " + item);
            }
        }

        public static void DeleteName(int i)
        {
            names.RemoveAt(i);
            Console.WriteLine("Success");
        }
    }
}
