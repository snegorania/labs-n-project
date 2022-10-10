namespace lab4
{
    class OverloadMethods
    {
        public static void ChangeItem(int i, string name)
        {
            Program.stankis[i].Name = name;
        }

        public static void ChangeItem(int i, bool usage)
        {
            Program.stankis[i].Usage = usage;
        }

        public static void ChangeItem(int i, long lt)
        {
            Program.stankis[i].LifeTime = lt;
        }
    }
}
