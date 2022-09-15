using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class Tamagoch
    {
        private static string[,] state = { { "helth", "#####" }, { "food", "#####" }, { "sleep", "#####" }, { "mood", "#####" }, { "xp", "" } };
        private static string[] locations = { "hospital", "work", "home", "street", "park", "shopping" };
        private static string[][] statistic = new string[7][];

        private static int level = 0;

        public static int Level {
                get { return level; }
                set { level = value; }
        }

        private static string location = "home";

        public static int currentLocation
        {
            get { return currentLocation; }
            set { currentLocation = value; }
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
            state[0, 1] = state[1, 1].PadRight(state[1, 1].Length + 1, '#');
        }

        public static void Feed()
        {
            state[1, 1] = state[1, 1].PadRight(state[1, 1].Length + 1, '#');
        }

        public static void ChangeLocation()
        {

        } 

        public static void Sleep()
        {
            state[2, 1] = state[2, 1].PadRight(state[2,1].Length + 1, '#');
        }

        public static void Work()
        {
            state[1, 1] = state[1, 1].Substring(0, state[1, 1].Length - 1);
            state[2, 1] = state[2, 1].Substring(0, state[2, 1].Length - 1);
        }

        public static void SendEvent()
        {
            Dead += EventListener;
            Hungry += EventListener;
            Depression += EventListener;
            Exhausted += EventListener;
            OverEnergetic += EventListener;
            OverFat += EventListener;
            OverHilled += EventListener;
            OverHappy += EventListener;
            if(state[0,1].Length == 5)
            {
                data.isBad = true;
                data.massage = "deth";
                Dead?.Invoke(data, data);
            }
            if (state[1, 1].Length == 5)
            {
                data.isBad = true;
                data.massage = "hunger";
                Hungry?.Invoke(data, data);
            }
            if (state[2, 1].Length == 5)
            {
                data.isBad = true;
                data.massage = "tiered";
                Exhausted?.Invoke(data, data);
            }
            if (state[3, 1].Length == 5)
            {
                data.isBad = true;
                data.massage = "sad";
                Depression?.Invoke(data, data);
            }
            if (state[0, 1].Length == 5)
            {
                data.isBad = false;
                data.massage = "hilled to kill";
                OverHilled?.Invoke(data, data);
            }
            if (state[1, 1].Length == 5)
            {
                data.isBad = true;
                data.massage = "too fat to go";
                OverFat?.Invoke(data, data);
            }
            if (state[2, 1].Length == 5)
            {
                data.isBad = false;
                data.massage = "run so fast";
                OverEnergetic?.Invoke(data, data);
            }
            if (state[3, 1].Length == 5)
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
