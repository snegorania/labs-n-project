using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab4
{
    class Stanki
    {
        public string Name { get; }
        public int Productivity { get; }
        public int Size { get; }
        public int LifeTime { get; }
        public Stanki(string name, int productivity, int size, int lifeTime)
        {
            Name = name;
            Productivity = productivity;
            Size = size;
            LifeTime = lifeTime;
            Console.WriteLine("You have bought " + name);
        }

        ~Stanki()
        {
            Console.WriteLine("You have thrown out " + this.Name);
        }
    }
}
