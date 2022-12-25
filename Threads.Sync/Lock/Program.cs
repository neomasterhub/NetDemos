using System.Text;

namespace Lock;

class Program
{
    private static readonly object locked = new();
    private static readonly StringBuilder resource = new();

    private static void Writer(char c)
    {
        lock (locked)
        {
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

        threads.ForEach(th =>
        {
            th.Start();
            th.Join();
            Thread.Sleep(10);
        });

        Console.WriteLine(resource.ToString());

        //AAAAAAAAAA
        //BBBBBBBBBB
        //CCCCCCCCCC
        //DDDDDDDDDD
        //EEEEEEEEEE
    }
}
