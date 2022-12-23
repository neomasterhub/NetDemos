using System;
using System.Linq;
using System.Threading;

namespace AffinityParametrized
{
    class Program
    {
        static void Main()
        {
            var threads = Enum.GetValues(typeof(ThreadPriority))
                .Cast<ThreadPriority>()
                .OrderByDescending(tp => tp)
                .Select(tp =>
                {
                    var counter = new Counter(tp.ToString());
                    var thread = new Thread(counter.Run)
                    {
                        Priority = tp
                    };

                    return thread;
                })
                .ToArray();

            foreach (Thread th in threads)
            {
                th.Start();
            }

            // lowest
            threads.Last().Join();
            Console.ReadKey();
        }
    }
}
