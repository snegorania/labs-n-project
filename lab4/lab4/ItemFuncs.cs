using System;
using System.Collections.Generic;
namespace lab4
{
    class ItemFuncs
    {
        public static void BreakItem(int i)
        {
            if (Program.stankis[i].LifeTime > 0)
            {
                if (Program.stankis[i].Usage)
                {
                    Program.stankis[i].LifeTime--;
                }
            }
            else
            {
                Program.stankis.RemoveAt(i);
            }
        }

        public static void RepairItem(int i)
        {
            if (!Program.stankis[i].Usage)
            {
                Program.stankis[i].LifeTime++;
                Console.WriteLine("Repaired");
            }
            else
            {
                Console.WriteLine("Unable to repair");
            }
        }
    }
}
