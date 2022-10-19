using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class ZagzMode
    {
        public static void UseMode()
        {
            string input = "";
            int num;

            zagzFunc.HelpUser();

            while (input != "kill")
            {
                Console.Write("Zagz command: ");
                input = Console.ReadLine();

                if (input == "Help")
                {
                    zagzFunc.HelpUser();
                }

                if (input == "Add")
                {
                    Console.Write("Quantity: ");
                    num = TCN();

                    for (int i = 0; i < num; i++)
                    {
                        Console.Write("Name: ");
                        input = Console.ReadLine();
                        try
                        {
                            zagzFunc.Zagz(input);
                        }
                        catch (exeptionZagz)
                        {
                            Console.WriteLine("Incorrect name");
                        }
                    }
                }

                if (input == "All")
                {
                    zagzFunc.ListOfNames();
                }

                if (input == "Delete")
                {
                    int index;
                    Console.Write("Index: ");
                    index = TCN() - 1;
                    try
                    {
                        if (index < 0)
                        {
                            continue;
                        }
                        zagzFunc.DeleteName(index);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Incorrect index");
                    }
                }

                if (input == "Statistic")
                {
                    zagzFunc.GiveStatisticNames();
                }

                if (input == "Rename")
                {
                    Console.Write("Index: ");
                    int index = TCN() - 1;
                    Console.Write("Name: ");
                    input = Console.ReadLine();
                    try
                    {
                        if (index < 0)
                        {
                            continue;
                        }
                        zagzFunc.ChangeName(index, input);
                    }
                    catch (exeptionZagz)
                    {
                        Console.WriteLine("Incorrect name");
                    }
                }
            }
        }

        public static int TCN()
        {
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect format");
            }
            return num;
        }
    }
}
