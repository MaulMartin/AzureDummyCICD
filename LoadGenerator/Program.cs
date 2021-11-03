using System;

namespace LoadGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int lowerTOlimit = 0;
            int upperTOlimit = 0;
            int TOSpan = 0;

            Console.Write("Attempts cnt: ");
            int attemptsCnt = Convert.ToInt32(Console.ReadLine());

            Console.Write("Random timeouts between requests (y/*): ");
            string randTimeouts = Console.ReadLine();

            if (randTimeouts == "y")
            {
                Console.Write("Set lower timeout limit (>0): ");
                lowerTOlimit = Convert.ToInt32(Console.ReadLine());

                Console.Write("Set upper timeout limit (>0): ");
                upperTOlimit = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.Write("Set upper timeout limit (>0): ");
                TOSpan = Convert.ToInt32(Console.ReadLine());
            }

            if (lowerTOlimit < 0 || upperTOlimit < 0 || upperTOlimit < lowerTOlimit || TOSpan < 0 || attemptsCnt <= 0)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("--------------Wrong Input--------------");
                Console.WriteLine("---------------------------------------");
            }
            else
            {
                LoadGen.AttemptsCount = attemptsCnt;
                LoadGen.RandomTimeouts = randTimeouts == "y";
                LoadGen.BottomLimitRandTimeout = lowerTOlimit;
                LoadGen.TopLimitRandTimeout = upperTOlimit;
                LoadGen.TimeoutSpanSec = TOSpan;

                LoadGen.GenereateLoad();
            }
            Console.ReadKey();
        }
    }
}
