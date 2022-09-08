using System;
using System.Collections;
using System.Text;



namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string stopWord = "kill";
            string input = "";
            while (input != stopWord)
            {
                input = Console.ReadLine();
                try
                {
                    Class1.zagz(input);
                }
                catch (exeptionZagz)
                {
                    Console.WriteLine("Incorrect name. Try again...");
                }
            }
        }
    }
}
