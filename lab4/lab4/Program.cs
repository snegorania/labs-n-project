namespace lab4
{
    class Program
    {
        public static List<Stanki> stankis = new List<Stanki>();
        public static void Main(string[] args)
        {
            string input = "";
            string name = "";
            bool usage = true;
            long lt = 5;
            int i = 0;

            Console.WriteLine("exit - Canceling console \nadd - Adding new item \nchange - Editing item " +
                        "\ndelete - Removing item \nall - Showing all items \ninformation - Showing information of item \nconnect - Completing line");
            
            while (input != "exit")
            {
                input = Console.ReadLine(); 
                if (input == "help")
                {
                    Console.WriteLine("exit - Canceling console \nadd - Adding new item \nchange - Editing item "+
                                      "\ndelete - Removing item \nall - Showing all items \ninformation - Showing information of item \nconnect - Completing line");
                }

                if (input == "add")
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    Console.Write("Usage: ");
                    try
                    {
                        usage = bool.Parse(Console.ReadLine());
                    } catch (FormatException)
                    {
                        Console.WriteLine("Default value: true");
                    }
                    Console.Write("Life Time: ");
                    try
                    {
                        lt = long.Parse(Console.ReadLine());
                    } catch (FormatException)
                    {
                        Console.WriteLine("Default value: 5");
                    }
                    stankis.Add(new Stanki(name, usage, lt));
                }

                if (input == "change")
                {
                    Console.Write("Index: ");
                    try
                    {
                        i = int.Parse(Console.ReadLine());
                    } catch (FormatException)
                    {
                        i = 0;
                        Console.WriteLine("Default value: 0");
                    }
                    Console.Write("Parameter: ");
                    input = Console.ReadLine();

                    try 
                    { 
                        OverloadMethods.ChangeItem(i, long.Parse(input));
                    }
                    catch (FormatException)
                    {
                        if (input == "true" || input == "false")
                        {
                            OverloadMethods.ChangeItem(i, bool.Parse(input));
                        } else
                        {
                            OverloadMethods.ChangeItem(i, input);
                        }
                    }
                }

                if (input == "delete")
                {
                    Console.Write("Index: ");
                    try
                    {
                        i = int.Parse(Console.ReadLine());
                    } catch (FormatException)
                    {
                        i = 0;
                        Console.WriteLine("Default value: 0");
                    }
                    stankis.RemoveAt(i);
                }

                if (input == "all")
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
                        i = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        i = 0;
                        Console.WriteLine("Default value: 0");
                    }
                    Console.WriteLine(stankis[i].Name + " " + stankis[i].Usage + " " + stankis[i].LifeTime);
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
    }
}