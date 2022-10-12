using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        public static List<Stanki> stankis = new List<Stanki>();
        static void Main(string[] args)
        {
            string input = "";
            int num;
            //----------------------
            //string input = "";
            string name = "";
            bool usage = true;
            long lt = 5;
            int k = 0;

            zagzFunc.HelpUser();

            while (input != "explode")
            {
                Console.Write("Command: ");
                input = Console.ReadLine();

                if (input == "help")
                {
                    zagzFunc.HelpUser();
                }

                if (input == "add person")
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

                if (input == "all people")
                {
                    zagzFunc.ListOfNames();
                }

                if (input == "delete person")
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

                if (input == "statistic")
                {
                    zagzFunc.GiveStatisticNames();
                }

                if (input == "rename person")
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

                //-----------------------------------------------

                if (input == "add item")
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    Console.Write("Usage: ");
                    try
                    {
                        usage = bool.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Default value: true");
                    }
                    Console.Write("Life Time: ");
                    try
                    {
                        lt = long.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Default value: 5");
                    }
                    stankis.Add(new Stanki(name, usage, lt));
                }

                if (input == "change item")
                {
                    Console.Write("Index: ");
                    try
                    {
                        k = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        k = 0;
                        Console.WriteLine("Default value: 0");
                    }
                    Console.Write("Parameter: ");
                    input = Console.ReadLine();

                    try
                    {
                        OverloadMethods.ChangeItem(k, long.Parse(input));
                    }
                    catch (FormatException)
                    {
                        if (input == "true" || input == "false")
                        {
                            OverloadMethods.ChangeItem(k, bool.Parse(input));
                        }
                        else
                        {
                            OverloadMethods.ChangeItem(k, input);
                        }
                    }
                }

                if (input == "delete item")
                {
                    Console.Write("Index: ");
                    try
                    {
                        k = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        k = 0;
                        Console.WriteLine("Default value: 0");
                    }
                    stankis.RemoveAt(k);
                }

                if (input == "all items")
                {
                    for (int j = 0; j < stankis.Count; j++)
                    {
                        Console.WriteLine(j + " " + stankis[j].Name);
                    }
                }

                if (input == "information")
                {
                    Console.Write("Index: ");
                    try
                    {
                        k = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        k = 0;
                        Console.WriteLine("Default value: 0");
                    }
                    Console.WriteLine(stankis[k].Name + " " + stankis[k].Usage + " " + stankis[k].LifeTime);
                }

                if (input == "connect")
                {
                    usage = false;
                    Stanki lineItems = new Stanki("Line:", true, 9223372036854775807);
                    for (int j = 0; j < stankis.Count; j++)
                    {
                        if (stankis[j].Usage)
                        {
                            lineItems = lineItems + stankis[j];
                            usage = true;
                        }
                    }
                    if (usage)
                    {
                        Console.WriteLine(lineItems.Name + " " + lineItems.LifeTime);
                    }
                    else
                    {
                        Console.WriteLine("Noting in line");
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
