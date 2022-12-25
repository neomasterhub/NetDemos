using System.Diagnostics;
using System.Text;

namespace Lock;

class Program
{
    private static readonly object locked = new();
    private static readonly StringBuilder resource = new();
    private static int index = 1;

    private static void Writer(char c)
    {
        lock (locked)
        {
            resource.Append($"{index++}. ");

            for (int i = 0; i < 10; i++)
            {
                resource.Append(c);
                Thread.Sleep(100);
            }

            resource.Append('\n');
        }
    }

    private static void Main()
    {
        List<Thread> threads = new();

        for (var i = 'A'; i < 'F'; i++)
        {
            char c = i;
            threads.Add(new Thread(() => Writer(c)));
        }

        var sw = new Stopwatch();
        sw.Start();

        threads.ForEach(th =>
        {
            th.Start();
            th.Join();
            Thread.Sleep(10);
        });

        Console.WriteLine(resource.ToString());
        Console.WriteLine(sw.Elapsed.TotalSeconds);

        //1. AAAAAAAAAA
        //2. BBBBBBBBBB
        //3. CCCCCCCCCC
        //4. DDDDDDDDDD
        //5. EEEEEEEEEE
        //
        //5,5210642     (5 * 100 + 5 * 10)
    }
}
