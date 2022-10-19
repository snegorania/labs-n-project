using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            Console.WriteLine("Welcome to our app");
            Console.WriteLine("factory - using factory mode \nzagz - using zagz mode \nhr - using HR mode \nexplode - closing app \nhelp - command list");
            while(input != "explode")
            {
                Console.Write("Command: ");
                input = Console.ReadLine();
                if(input == "zagz")
                {
                    Console.WriteLine("Welcome to zagz mode");
                    ZagzMode.UseMode();
                }

                if (input == "factory")
                {
                    Console.WriteLine("Welcome to factory mode");
                    FactoryMode.UseMode();
                }

                if (input == "hr")
                {
                    Console.WriteLine("Welcome to HR mode");
                    HRMode.UseMode();
                }

                if(input == "help")
                {
                    Console.WriteLine("factory - using factory mode \nzagz - using zagz mode \nexplode - closing app \nhelp - command list");
                }
            }
        }

    }
    
}
