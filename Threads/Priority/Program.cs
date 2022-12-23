using System;
using System.Threading;

namespace Priority
{
    internal class Program
    {
        private static readonly Thread highest = new Thread(Highest);
        private static readonly Thread lowest = new Thread(Lowest);
        private static readonly int limit = 100_000_000;
        private static int highestCount = 0;
        private static int lowestCount = 0;

        static void Main()
        {
            highest.Priority = ThreadPriority.Highest;
            lowest.Priority = ThreadPriority.Lowest;

            highest.Start();
            lowest.Start();

            highest.Join();
            lowest.Join();

            Console.WriteLine("highestCount: " + highestCount);
            Console.WriteLine("lowestCount:  " + lowestCount);
            Console.ReadKey();

            //highestCount: 100000000
            //lowestCount:  31299252            
        }

        static void Highest()
        {
            while (++highestCount != limit) ;
            lowest.Abort();
        }

        static void Lowest()
        {
            while (++lowestCount != limit) ;
            highest.Abort();
        }
    }
}
