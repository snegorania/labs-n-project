using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class zagzFunc
    {
        public static List<string> names = new List<string>();

        public static void HelpUser()
        {
            Console.WriteLine("explode - exit \nadd person - Creating of new item \nall peple - Giving list output \nrename person " +
                "- Changing name on index \ndelete person - Removing from the listn \nstatistic - Giving number of common" +
                " people \nhelp - Command list"+
                "add item - Adding new item \nchange item - Editing item " +
                "\ndelete item - Removing item \nall items - Showing all items \ninformation - Showing information of item" +
                " \nconnect - Completing line");
        }

        public static void CheckName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if ((int)name[i] < 65 || ((int)name[i] > 90 && (int)name[i] < 97) || (int)name[i] > 122)
                {
                    throw new exeptionZagz("Name error");
                }
            }
        }
        public static void Zagz(string name)
        {
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
            for (int i = 1; i < names.Count; i++)
            {
                if (temp == names[i])
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
