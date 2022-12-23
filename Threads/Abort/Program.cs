using System;
using System.Threading;

namespace Abort
{
    internal class Program
    {
        private readonly static Thread aborted = new Thread(Aborted);
        private readonly static Thread aborter = new Thread(Aborter);

        static void Main()
        {
            Console.WriteLine($"Main id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Aborter id: {aborter.ManagedThreadId}");

            aborted.Start();
            aborter.Start();

            aborted.Join();
            Console.Write($"Aborted by thread {aborter.ManagedThreadId}");
            Console.ReadKey();

            //Main id: 1
            //Aborter id: 4
            //*********Aborted by thread 4.
        }

        static void Aborted()
        {
            while (true)
            {
                Thread.Sleep(200);
                Console.Write('*');
            }
        }

        static void Aborter()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            aborted.Abort();
        }
    }
}
