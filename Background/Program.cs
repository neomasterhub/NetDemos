Thread background = new(() =>
{
    while (true)
    {
        Console.Write("b ");
        Thread.Sleep(200);
    }
});
background.IsBackground = true;
background.Start();

int i = 10;
while (i-- > 0)
{
    Console.Write("m ");
    Thread.Sleep(200);
}
