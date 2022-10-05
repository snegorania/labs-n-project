using System;

namespace lab3
{
    class Tamagoch
    {
        private static string[,] state = { { "helth", "#####" }, { " food", "#####" }, { "sleep", "#####" }, { " mood", "#####" }, { "   xp", "" } };
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

        enum WeekDays
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
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
            ShowStatus();
        }

        public static void Feed()
        {
            location = locationType.kitchen;
            ChangeString((int)State.food, 3);
            ChangeString((int)State.sleep, -1);
            ChangeString((int)State.mood, (int)location);
            addAction("Feed");
            ShowStatus();
        }

        public static void Sleep()
        {
            location = locationType.bedroom;
            ChangeString((int)State.food, -1);
            ChangeString((int)State.sleep, 3);
            ChangeString((int)State.mood, (int)location);
            addAction("Sleep");
            ShowStatus();
        }

        public static void Work()
        {
            location = locationType.work;
            ChangeString((int)State.food, -1);
            ChangeString((int)State.sleep, -1);
            ChangeString((int)State.mood, (int)location);
            ChangeXp();
            addAction("Work");
            ShowStatus();
        }

        public static void goToPark()
        {
            location = locationType.park;
            ChangeString((int)State.food, -1);
            ChangeString((int)State.sleep, -1);
            ChangeString((int)State.mood, (int)location);
            addAction("Parking");
            ShowStatus();
        }

        public static void goToShopping()
        {
            location = locationType.shopping;
            ChangeString((int)State.food, -1);
            ChangeString((int)State.sleep, -1);
            ChangeString((int)State.mood, (int)location);
            addAction("Shopping");
            ShowStatus();
        }

        public static void ChangeString(int index, int n)
        {
            int length = state[index, 1].Length + n;
            if (length < 0) length = 0;
            if (length > 10) length = 10;
            if (n >= 0)
            {
                state[index, 1] = state[index, 1].PadRight(length, '#');
            } else
            {
                state[index, 1] = state[index, 1].Substring(0, length);
            }
            SendEvent(index, length);
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

        public static void ShowActions()
        {
            WeekDays weekDays = WeekDays.Monday;
            for (int i = 0; i < 7; i++)
            {
                switch (weekDays)
                {
                    case WeekDays.Monday:
                        Console.Write("   Monday: ");
                        weekDays = WeekDays.Tuesday;
                        break;
                    case WeekDays.Tuesday:
                        Console.Write("  Tuesday: ");
                        weekDays = WeekDays.Wednesday;
                        break;
                    case WeekDays.Wednesday:
                        Console.Write("Wednesdey: ");
                        weekDays = WeekDays.Thursday;
                        break;
                    case WeekDays.Thursday:
                        Console.Write(" Thursday: ");
                        weekDays = WeekDays.Friday;
                        break;
                    case WeekDays.Friday:
                        Console.Write("   Friday: ");
                        weekDays = WeekDays.Saturday;
                        break;
                    case WeekDays.Saturday:
                        Console.Write(" Saturday: ");
                        weekDays = WeekDays.Sunday;
                        break;
                    case WeekDays.Sunday:
                        Console.Write("   Sunday: ");
                        weekDays = WeekDays.Monday;
                        break;
                }
                for (int j = 0; j < statistic[i].Length; j++)
                {
                    Console.Write(statistic[i][j] + " ");
                }
                Console.WriteLine();
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
                data.massage = "Died. Game over...";
                Dead?.Invoke(data, data);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.food && l == 0)
            {
                ChangeString((int)State.helth, -1);
                state[(int)State.food, 1] = "#";
                data.isBad = true;
                data.massage = "Hungry. I'm loosing Helth";
                Hungry?.Invoke(data, data);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.sleep && l == 0)
            {
                data.isBad = true;
                state[(int)State.sleep, 1] = "#";
                data.massage = "Tired. I'm loosing Helth";
                Exhausted?.Invoke(data, data);
                ChangeString((int)State.helth, -1);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.mood && l == 0)
            {
                data.isBad = true;
                state[(int)State.mood, 1] = "#";
                data.massage = "Sad. I'm loosing Helth";
                Depression?.Invoke(data, data);
                ChangeString((int)State.helth, -1);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.helth && l > 9)
            {
                data.isBad = false;
                data.massage = "Immortality. I won't obey you anymore";
                gg = "hvatet";
                state[(int)State.helth, 1] = "*****";
                OverHilled?.Invoke(data, data);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.food && l > 9)
            {
                data.isBad = true;
                data.massage = "Fat. I can't get through the doorway";
                gg = "hvatet";
                state[(int)State.food, 1] = "*****";
                OverFat?.Invoke(data, data);
                ChangeString((int)State.helth, -1);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.sleep && l > 9)
            {
                data.isBad = false;
                data.massage = "Overslept. What year is it now?";
                gg = "hvatet";
                state[(int)State.sleep, 1] = "*****";
                OverEnergetic?.Invoke(data, data);
                Console.WriteLine(data.massage);
            }
            if (i == (int)State.mood && l > 9)
            {
                data.isBad = false;
                data.massage = "Boredom. My life doesn't change";
                gg = "hvatet";
                state[(int)State.sleep, 1] = "*****";
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
