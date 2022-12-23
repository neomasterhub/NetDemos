static void For(char c)
{
    for (int i = 0; i < 1000; i++)
    {
        Thread.Sleep(200);
        Console.Write(c);
    }
}

Thread th1 = new(() => For('1'));
Thread th2 = new(() =>
{
    th1.Join(TimeSpan.FromSeconds(5));
    For('2');
});
Thread th3 = new(() =>
{
    th2.Join(2000);
    For('3');
});

th1.Start();
th2.Start();
th3.Start();
