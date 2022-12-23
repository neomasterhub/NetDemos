using System;
using System.Threading;

namespace SuspendResume
{
    internal class Program
    {
        static readonly Thread writer1 = new Thread(Writer1);
        static readonly Thread writer2 = new Thread(Writer2);
        static readonly int timeout = 100;
        static readonly int max = 3;
        static int i = 0;

        static void Main()
        {
            writer1.Start();
            writer2.Start();

            while (writer1.ThreadState != ThreadState.Suspended) ;

            writer1.Resume();

            //...---...---...---...---...---...---...
        }

        static void Writer1()
        {
            SuspendResume(writer2, '.', timeout);
        }

        static void Writer2()
        {
            SuspendResume(writer1, '-', timeout);
        }

        static void SuspendResume(Thread resumed, char symbol, int timeout)
        {
            Thread.CurrentThread.Suspend();

            while (true)
            {
                Thread.Sleep(timeout);
                Console.Write(symbol);

                if (++i == max)
                {
                    i = 0;
                    resumed.Resume();
                    Thread.CurrentThread.Suspend();
                }
            }
        }
    }
}
