static void MyThread()
{
    Thread.Sleep(200);
}

var th = new Thread(MyThread);

Console.WriteLine(th.IsAlive); // False

th.Start();
Thread.Sleep(100);

Console.WriteLine(th.IsAlive); // True

Thread.Sleep(300);

Console.WriteLine(th.IsAlive); // False

Console.ReadKey();
