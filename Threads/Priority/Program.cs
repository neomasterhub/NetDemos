using System;
using System.Threading;

namespace Priority
{
    internal class Program
    {
        private static readonly Thread highest = new Thread(Highest);
        private static readonly Thread lowest = new Thread(Lowest);
        private static readonly int limit = int.MaxValue;
        private static int highestCount = 0;
        private static int lowestCount = 0;

        private static void Main()
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

            //highestCount: 2147483647
            //lowestCount:  1411503389         
        }

        private static void Highest()
        {
            while (++highestCount != limit) ;
            lowest.Abort();
        }

        private static void Lowest()
        {
            while (++lowestCount != limit) ;
            highest.Abort();
        }
    }
}
