using System;
using System.Collections.Generic;

namespace lab2
{
    class Class1
    {
        public static List<string> names = new List<string>();

        public static void HelpUser()
        {
            Console.WriteLine("kill - exit \nAdd - Creating of new item \nAll - Giving list output \nRename - Changing name on index \nDelete - Removing from the listn \nStatistic - Giving number of common items \nHelp - Command list");
        }

        public static void CheckName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if ((int)name[i] < 65 || ((int)name[i] > 90 && (int)name[i] < 97) || (int)name[i] > 122)
                {
                    throw new ExeptionZagz("Name error");
                }
            }
        }
        public static void Zagz(string name) {
            CheckName(name);
            names.Add(name);
            names.Sort();
            Console.WriteLine("Success");
        }

        public static void ListOfNames()
        {
            int i = 1;

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

        public static void GiveStatisticNames()
        {
            string temp = names[0];
            int num = 1;
            for (int i = 1; i < names.Count; i++) {
                if(temp == names[i])
                {
                    num++;
                }
                else
                {
                    Console.WriteLine(temp + " " + num);
                    num = 1;
                    temp = names[i];
                }
            }
            Console.WriteLine(temp + " " + num);
        }

        public static void ChangeName(int index, string name)
        {
            CheckName(name);
            names[index] = name;
        }
    }
}
