using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("exit - Killing your tamagotchi \nStatus - Tamagotchi parameters\n Hill - Visiting hospital \nFeed - Feeding tamagotchi \nSleep - Going to bed \nWork - Working \nParking - Going to Park \nShopping - Going to slaughterhouse");
            Tamagoch.ShowStatus();
            Console.WriteLine("Enter command: ");
            string input = Console.ReadLine();
            while (input != "exit")
            {
                if (Tamagoch.gg != "hvatet")
                {
                    if (input == "help")
                    {
                        Console.WriteLine("exit - Killing your tamagotchi \nStatus - Tamagotchi " +
                            " parameters \nHill - Visiting hospital " +
                            " \nFeed - Feeding tamagotchi \nSleep - Going to bed" +
                            " \nWork - Working \nParking - Going to Park \nShopping - Going to slaughterhouse");
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
                    }

                    if (input == "Parking")
                    {
                        Tamagoch.goToPark();
                    }

                    if (input == "Shopping")
                    {
                        Tamagoch.goToShopping();
                    }
                    input = Console.ReadLine();
                }
                else
                {
                    input = "exit";
                    continue;
                }
                
            }
        }
    }
}
