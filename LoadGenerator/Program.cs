using System;
using System.Threading.Tasks;

namespace LoadGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadGen.AttemptsCount = 500;
            LoadGen.TimeoutSpanSec = 3;

            LoadGen.GenereateLoad();
            Console.ReadKey();
        }
    }
}
