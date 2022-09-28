using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "exit")
            {
                if (input == "help")
                {
                    Console.WriteLine("exit - Killing your tamagotchi \nStatus - Tamagotchi parameters\n Hill - Visiting hospital \nFeed - Feeding tamagotchi \nSleep - Going to bed \nWork - Working");
                }
                if (input == "Status")
                {
                    Tamagoch.ShowStatus();
                }
                input = Console.ReadLine();
            }
        }
    }
}
