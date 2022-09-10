using System;



namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            Class1.HelpUser();

            while (input != "kill")
            {
                Console.WriteLine("Command:");
                input = Console.ReadLine();

                if (input == "Help")
                {
                    Class1.HelpUser();
                }

                if (input == "Add")
                {
                    Console.WriteLine("Name: ");
                    input = Console.ReadLine();

                    try
                    {
                        Class1.Zagz(input);
                    }
                    catch (ExeptionZagz)
                    {
                        Console.WriteLine("Incorrect name");
                    }
                }

                if (input == "All")
                {
                    Class1.ListOfNames();
                }

                if (input == "Delete")
                {
                    Console.WriteLine("Index: ");
                    input = Console.ReadLine();
                    try
                    {
                        Class1.DeleteName(int.Parse(input));
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Incorrect index");
                    }
                }
            }
        }
    }
}
