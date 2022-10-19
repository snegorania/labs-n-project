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
                "\nhire - adding person to stanok \nexit - closing mode \npeopledoc - Documantation of people \nstankidoc - Documentation of stanki \nworkerdoc - Documentation of workers workers - List of Workers\n \nhelp - command list");

            while(input != "exit")
            {
                Console.Write("HR command: ");
                input = Console.ReadLine();

                if (input == "people")
                {
                    fileWork.ReadPeople();
                }

                if (input == "stanki")
                {
                    fileWork.ReadStanki();
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

                if (input == "peopledoc")
                {
                    fileWork.WritePeople();
                }

                if (input == "stankidoc")
                {
                    fileWork.WriteStanki();
                }

                if (input == "workerdoc")
                {
                    fileWork.WriteHRW();
                }

                if (input == "workers")
                {
                    fileWork.ReadHRW();
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
