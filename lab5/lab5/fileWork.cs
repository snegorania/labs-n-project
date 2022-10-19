using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab5
{
    class fileWork
    {

        public static void WritePeople()
        {
            if (File.Exists("D:\\ПОЭС\\labs-n-project\\lab5\\slaves.txt"))
            {
                File.Delete("D:\\ПОЭС\\labs-n-project\\lab5\\slaves.txt");
            }

            using (StreamWriter sw = new StreamWriter("D:\\ПОЭС\\labs-n-project\\lab5\\slaves.txt"))
            {
                int i = 0;
                foreach (string item in zagzFunc.names)
                {
                    sw.WriteLine(i++ + " " + item);
                }
            }
        }

        public static void ReadPeople()
        {
            if (!File.Exists("D:\\ПОЭС\\labs-n-project\\lab5\\slaves.txt"))
            {
                Console.WriteLine("Error: No data");
            }
            else
            {
                using (StreamReader sr = new StreamReader("D:\\ПОЭС\\labs-n-project\\lab5\\slaves.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }

        public static void WriteStanki()
        {
            if (File.Exists("D:\\ПОЭС\\labs-n-project\\lab5\\stanki.txt"))
            {
                File.Delete("D:\\ПОЭС\\labs-n-project\\lab5\\sranki.txt");
            }

            using (StreamWriter sw = new StreamWriter("D:\\ПОЭС\\labs-n-project\\lab5\\stanki.txt"))
            {
                int i = 0;
                foreach (Stanki item in FactoryMode.stankis)
                {
                    sw.WriteLine(i++ +" " + item.Name);
                }
            }
        }

        public static void ReadStanki()
        {
            if (!File.Exists("D:\\ПОЭС\\labs-n-project\\lab5\\stanki.txt"))
            {
                Console.WriteLine("Error: No data");
            }
            else
            {
                using (StreamReader sr = new StreamReader("D:\\ПОЭС\\labs-n-project\\lab5\\stanki.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }

        public static void WriteHRW()
        {
            if (File.Exists("D:\\ПОЭС\\labs-n-project\\lab5\\workers.txt"))
            {
                File.Delete("D:\\ПОЭС\\labs-n-project\\lab5\\workers.txt");
            }

            using (StreamWriter sw = new StreamWriter("D:\\ПОЭС\\labs-n-project\\lab5\\workers.txt"))
            {
                foreach (Stanki item in FactoryMode.stankis)
                {
                    int i = 0;
                    if (item.WorkerName != "empty")
                    {
                        sw.WriteLine(i++ + " " + item.Name + " " + item.WorkerName);
                    }
                }
            }
        }

        public static void ReadHRW()
        {
            if (!File.Exists("D:\\ПОЭС\\labs-n-project\\lab5\\workers.txt"))
            {
                Console.WriteLine("Error: No data");
            }
            else
            {
                using (StreamReader sr = new StreamReader("D:\\ПОЭС\\labs-n-project\\lab5\\workers.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
