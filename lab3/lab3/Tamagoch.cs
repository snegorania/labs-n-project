using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class Tamagoch
    {
        private static string[,] state = { { "helth", "#####" }, { "food", "#####" }, { "sleep", "#####" }, { "mood", "#####" }, { "xp", "" } };
        private static string[] locations = { "hospital", "work", "kitchen", "bedroom", "park", "shopping" };
        private static string[][] statistic = new string[7][];

        private static int level = 1;
        private static int xp = 0;

        public static int Level {
                get { return level; }
                set { level = value; }
        }

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

        public static void Hill()
        {
            location = locationType.hospital;
            ChangeString((int)State.helth, 3);
            ChangeString((int)State.mood, (int)location);
        }

        public static void Feed()
        {
            location = locationType.kitchen;
            ChangeString((int)State.food, 3);
            ChangeString((int)State.sleep, -1);
            ChangeString((int)State.mood, (int)location);
        }

        public static void Sleep()
        {
            location = locationType.bedroom;
            ChangeString((int)State.food, -1);
            ChangeString((int)State.sleep, 3);
            ChangeString((int)State.mood, (int)location);
        }

        public static void Work()
        {
            location = locationType.work;
            ChangeString((int)State.food, -1);
            ChangeString((int)State.sleep, -1);
            ChangeString((int)State.mood, (int)location);
            ChangeXp();
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
            if(++xp > level)
            {
                xp = 0;
                level++;
            }
            int n = xp * 10 / level;
            state[(int)State.xp, 1] = "".PadRight(n, '#');
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
            if (i == (int)State.helth && l <= 0)
            {
                data.isBad = true;
                data.massage = "deth";
                Dead?.Invoke(data, data);
            }
            if (i == (int)State.food && l <= 0)
            {
                data.isBad = true;
                data.massage = "hunger";
                Hungry?.Invoke(data, data);
            }
            if (i == (int)State.sleep && l <= 0)
            {
                data.isBad = true;
                data.massage = "tiered";
                Exhausted?.Invoke(data, data);
            }
            if (i == (int)State.mood && l <= 0)
            {
                data.isBad = true;
                data.massage = "sad";
                Depression?.Invoke(data, data);
            }
            if (i == (int)State.helth && l > 9)
            {
                data.isBad = false;
                data.massage = "hilled to kill";
                OverHilled?.Invoke(data, data);
            }
            if (i == (int)State.food && l > 9)
            {
                data.isBad = true;
                data.massage = "too fat to go";
                OverFat?.Invoke(data, data);
            }
            if (i == (int)State.sleep && l > 9)
            {
                data.isBad = false;
                data.massage = "run so fast";
                OverEnergetic?.Invoke(data, data);
            }
            if (i == (int)State.mood && l > 9)
            {
                data.isBad = false;
                data.massage = "suicied from happiness";
                OverHappy?.Invoke(data, data);
            }
        }
        public static void EventListener(object sender, TamagochEventArgs e)
        {
            Console.WriteLine(e.massage);
            if (e.isBad)
            {
                Console.WriteLine("Bad");
            }
        }
        

    }
}
