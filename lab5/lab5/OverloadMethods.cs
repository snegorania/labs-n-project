using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class OverloadMethods
    {
        public static void ChangeItem(int i, string name)
        {
            FactoryMode.stankis[i].Name = name;
        }

        public static void ChangeItem(int i, bool usage)
        {
            FactoryMode.stankis[i].Usage = usage;
        }

        public static void ChangeItem(int i, long lt)
        {
            FactoryMode.stankis[i].LifeTime = lt;
        }
    }
}
