using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("exit - Killing your tamagotchi \nStatus - Showing Tamagotchi parameters \nHill - Visiting hospital \nFeed - Feeding tamagotchi \nSleep - Going to bed \nWork - Working for the best company ever \nParking - Going to Park \nShopping - Going to slaughterhouse \nActions - Showing actions for last 7 days");
            Tamagoch.ShowStatus();
            string input = "";
            int count = 0;
            while (input != "exit")
            {
                if (Tamagoch.gg != "hvatet")
                {
                    Console.Write("Enter command: ");
                    input = Console.ReadLine();
                    if (input == "help")
                    {
                        Console.WriteLine("exit - Killing your tamagotchi \nStatus - Showing Tamagotchi " +
                            " parameters \nHill - Visiting hospital " +
                            " \nFeed - Feeding tamagotchi \nSleep - Going to bed" +
                            " \nWork - Working for the best company ever \nParking - Going to Park \nShopping - Going to slaughterhouse \nActions - Showing actions for last 7 days");
                    }

                    if (input == "Status")
                    {
                        Tamagoch.ShowStatus();
                    }

                    if (input == "Work")
                    {
                        Tamagoch.Work();
                    }

                    if (input == "Hill")
                    {
                        Tamagoch.Hill();
                    }

                    if (input == "Feed")
                    {
                        Tamagoch.Feed();
                    }

                    if (input == "Sleep")
                    {
                        Tamagoch.Sleep();
                        count++;
                    }

                    if (input == "Parking")
                    {
                        Tamagoch.goToPark();
                    }

                    if (input == "Shopping")
                    {
                        Tamagoch.goToShopping();
                    }

                    if (input == "Actions")
                    {
                        if (count > 6)
                        {
                            Tamagoch.ShowActions();
                        } else
                        {
                            Console.WriteLine("Report is not ready...");
                        }
                    }
                }
                else
                {
                    Console.Write("Your last words: ");
                    input = Console.ReadLine();
                    input = "exit";
                    continue;
                }
                
            }
        }
    }
}
