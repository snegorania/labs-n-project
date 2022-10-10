namespace lab4
{
    class Stanki
    {
        public string Name { get; set;  }
        public bool Usage { get; set; }
        public long LifeTime { get; set; }
        public Stanki(string name, bool usage, long lifeTime)
        {
            Name = name;
            Usage = usage;
            LifeTime = lifeTime;
        }

        ~Stanki()
        {
            Console.WriteLine("You have thrown out " + this.Name);
        }

        public static Stanki operator +(Stanki s1, Stanki s2)
        {
            return new Stanki(s1.Name + " " + s2.Name, true, s1.LifeTime < s2.LifeTime ? s1.LifeTime : s2.LifeTime);
        }
    }
}
