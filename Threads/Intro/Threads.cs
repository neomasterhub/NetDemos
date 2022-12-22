namespace Intro;

internal static class Threads
{
    public static void StarWriter()
    {
        while (true)
        {
            Console.Write('*');
            Thread.Sleep(2000);
        }
    }

    public static void Writer(object value)
    {
        while (true)
        {
            Console.Write(value);
            Thread.Sleep(7000);
        }
    }
}
