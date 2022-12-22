static void WriteInfo(Thread th)
{
    Console.WriteLine("id: " + th.ManagedThreadId);
    Console.WriteLine("name: " + th.Name);
    Console.WriteLine();
}

static void MyThread()
{
    Thread.CurrentThread.Name = "My Thread";
}

Thread.CurrentThread.Name = "Main";
WriteInfo(Thread.CurrentThread);

var th = new Thread(MyThread);
th.Start();
Thread.Sleep(100);

WriteInfo(th);

Console.ReadKey();

//id: 1
//name: Main

//id: 9
//name: My Thread
