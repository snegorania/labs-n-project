using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class HRMode
    {
        public static void UseMode()
        {
            string input = "";
            int i = 0;
            int k = 0;

            Console.WriteLine("people - showing people list \nstanki - showing stanki list \ninfo - showing stanok info " +
                "\nhire - adding prtson to stanok \nexit - closing mode \nhelp - command list");

            while(input != "exit")
            {
                Console.Write("HR command: ");
                input = Console.ReadLine();

                if (input == "people")
                {
                    zagzFunc.ListOfNames();
                }

                if (input == "stanki")
                {
                    for (int j = 0; j < FactoryMode.stankis.Count; j++)
                    {
                        Console.WriteLine(j + " " + FactoryMode.stankis[j].Name);
                    }
                }

                if (input == "info")
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
                    Console.WriteLine(FactoryMode.stankis[i].Name + " " + FactoryMode.stankis[i].Usage + " " + FactoryMode.stankis[i].LifeTime + " " + FactoryMode.stankis[i].WorkerName);
                }

                if(input == "hire")
                {
                    Console.Write("Person index: ");
                    try
                    {
                        i = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        i = 0;
                        Console.WriteLine("Default value: 0");
                    }

                    Console.Write("Stanok index: ");
                    try
                    {
                        k = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        k = 0;
                        Console.WriteLine("Default value: 0");
                    }

                    FactoryMode.stankis[k].WorkerName = zagzFunc.names[i];

                    Console.WriteLine(FactoryMode.stankis[k].Name + " " + FactoryMode.stankis[k].Usage + " " + FactoryMode.stankis[k].LifeTime + " " + FactoryMode.stankis[k].WorkerName);
                }

                if (input == "help")
                {
                    Console.WriteLine("people - showing people list \nstanki - showing stanki list \ninfo - showing stanok info " +
                        "\nhire - adding prtson to stanok \nexit - closing mode \nhelp - command list"); 
                }
            }
        }
    }
}
