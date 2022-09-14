using System;



namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int num;

            Class1.HelpUser();

            while (input != "kill")
            {
                Console.Write("Command: ");
                input = Console.ReadLine();

                if (input == "Help")
                {
                    Class1.HelpUser();
                }

                if (input == "Add")
                {
                    Console.Write("Quantity: ");
                    num = TCN();

                    for (int i = 0; i < num; i++)
                    {
                        Console.Write("Name: ");
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
                }

                if (input == "All")
                {
                    Class1.ListOfNames();
                }

                if (input == "Delete")
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
                        Class1.DeleteName(index);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Incorrect index");
                    }
                }

                if (input == "Statistic")
                {
                    Class1.GiveStatisticNames();
                }

                if (input == "Rename")
                {
                    Console.Write("Index: ");
                    int index = TCN() - 1;
                    Console.Write("Name: ");
                    input = Console.ReadLine();
                    try
                    {
                        if(index < 0) {
                            continue;
                        }
                        Class1.ChangeName(index, input);
                    }
                    catch (ExeptionZagz)
                    {
                        Console.WriteLine("Incorrect name");
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
