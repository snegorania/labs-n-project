using System;

namespace lab3
{
    class Tamagoch
    {
        private static string[,] state = { { "helth", "#####" }, { "food", "#####" }, { "sleep", "#####" }, { "mood", "#####" }, { "xp", "" } };
        private static string[] buf = new string[20];
        private static string[][] statistic = new string[7][];
        private static int xp = 0;
        private static int count = 0;
        private static int dayNum = 0;

        private static int Level { get; set; } = 1;

        public static TamagochEventArgs data = new TamagochEventArgs();
        enum locationType
        {
            hospital = -2,
            work = -1,
            kitchen = 0,
            bedroom = 0,
            park = 1,
            shopping = 2
        }

        public static string gg = "";

        enum State
        {
            helth,
            food,
            sleep,
            mood,
            xp
        }


        private static locationType location = locationType.bedroom;

        //public delegate void tamagochHendler();

        public static event EventHandler<TamagochEventArgs> Dead;
        public static event EventHandler<TamagochEventArgs> Hungry;
        public static event EventHandler<TamagochEventArgs> Depression;
        public static event EventHandler<TamagochEventArgs> Exhausted;
        public static event EventHandler<TamagochEventArgs> OverHilled;
        public static event EventHandler<TamagochEventArgs> OverFat;
        public static event EventHandler<TamagochEventArgs> OverHappy;
        public static event EventHandler<TamagochEventArgs> OverEnergetic;

        public static IAsyncResult result;

        public static void Hill()
        {
            location = locationType.hospital;
            ChangeString((int)State.helth, 3);
            ChangeString((int)State.mood, (int)location);
            addAction("Hill");
        }

        public static void Feed()
        {
            location = locationType.kitchen;
            ChangeString((int)State.food, 3);
            ChangeString((int)State.sleep, -1);
            ChangeString((int)State.mood, (int)location);
            addAction("Feed");
        }

        public static void Sleep()
        {
            location = locationType.bedroom;
            ChangeString((int)State.food, -1);
            ChangeString((int)State.sleep, 3);
            ChangeString((int)State.mood, (int)location);
            addAction("Sleep");
        }

        public static void Work()
        {
            location = locationType.work;
            ChangeString((int)State.food, -1);
            ChangeString((int)State.sleep, -1);
            ChangeString((int)State.mood, (int)location);
            ChangeXp();
            addAction("Work");
        }

        public static void goToPark()
        {
            location = locationType.park;
            ChangeString((int)State.food, -1);
            ChangeString((int)State.sleep, -1);
            ChangeString((int)State.mood, (int)location);
        }

        public static void goToShopping()
        {
            location = locationType.shopping;
            ChangeString((int)State.food, -1);
            ChangeString((int)State.sleep, -1);
            ChangeString((int)State.mood, (int)location);
        }

        public static void ChangeString(int index, int n)
        {
            int length = state[index, 1].Length + n;
            if (length < 0) length = 0;
            if (length > 10) length = 10;
            SendEvent(index, length);
            if (n >= 0)
            {
                state[index, 1] = state[index, 1].PadRight(length, '#');
            } else
            {
                state[index, 1] = state[index, 1].Substring(0, length);
            }
        }

        public static void ChangeXp()
        {
            if(++xp > Level)
            {
                xp = 0;
                Level++;
            }
            int n = xp * 10 / Level;
            state[(int)State.xp, 1] = "".PadRight(n, '#');
        }

        public static void addAction(string s)
        {
            buf[count] = s;
            count++;
            if (s == "Sleep")
            {
                statistic[dayNum] = new string[count];
                for(int i = 0; i < count; i++)
                {
                    statistic[dayNum][i] = buf[i]; 
                }
                count = 0;
                dayNum++;
                if (dayNum > 6)
                {
                    dayNum = 0;
                }
            }
        }

        public static void ShowStatus()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(state[i, 0] + " " + state[i, 1]);
            }
            Console.WriteLine("level " + Level);
        }

        public static void SendEvent(int i, int l)
        {
            Dead += EventListener;
            Hungry += EventListener;
            Depression += EventListener;
            Exhausted += EventListener;
            OverEnergetic += EventListener;
            OverFat += EventListener;
            OverHilled += EventListener;
            OverHappy += EventListener;
            if (i == (int)State.helth && l == 0)
            {
                data.isBad = true;
                gg = "hvatet";
                state[(int)State.helth, 1] = "*****";
                data.massage = "deth";
                Dead?.Invoke(data, data);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.food && l == 0)
            {
                ChangeString((int)State.helth, -1);
                state[(int)State.food, 1] = "#";
                data.isBad = true;
                data.massage = "hunger";
                Hungry?.Invoke(data, data);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.sleep && l == 0)
            {
                data.isBad = true;
                state[(int)State.sleep, 1] = "#";
                data.massage = "tiered";
                Exhausted?.Invoke(data, data);
                ChangeString((int)State.helth, -1);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.mood && l == 0)
            {
                data.isBad = true;
                state[(int)State.mood, 1] = "#";
                data.massage = "sad";
                Depression?.Invoke(data, data);
                ChangeString((int)State.helth, -1);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.helth && l > 9)
            {
                data.isBad = false;
                data.massage = "hilled to kill";
                gg = "hvatet";
                state[(int)State.helth, 1] = "*****";
                OverHilled?.Invoke(data, data);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.food && l > 9)
            {
                data.isBad = true;
                data.massage = "too fat to go";
                OverFat?.Invoke(data, data);
                ChangeString((int)State.helth, -1);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.sleep && l > 9)
            {
                data.isBad = false;
                data.massage = "run so fast";
                OverEnergetic?.Invoke(data, data);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.mood && l > 9)
            {
                data.isBad = false;
                data.massage = "suicied from happiness";
                OverHappy?.Invoke(data, data);
                Console.WriteLine(data.massage);
            }
        }
        public static void EventListener(object sender, TamagochEventArgs e)
        {
            Dead = null;
            Hungry = null;
            Depression = null;
            Exhausted = null;
            OverEnergetic = null;
            OverFat = null;
            OverHilled = null;
            OverHappy = null;
        }
        

    }
}
