namespace Join;

internal class Threads
{
    public static Thread Thread1 = new(Th1);
    public static Thread Thread2 = new(Th2);

    public static void For(char symbol)
    {
        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(100);
            Console.Write(symbol);
        }
    }

    private static void Th1()
    {
        For('*');
    }

    private static void Th2()
    {
        Thread1.Join();
        For('+');
    }
}
