using Intro;

System.Threading.Thread thread1 = new(Threads.StarWriter);
System.Threading.Thread thread2 = new(new ParameterizedThreadStart(Threads.Writer));

thread1.Start();
thread2.Start('@');

int i = 30;
while (i-- > 0)
{
    Console.Write('.');
    Thread.Sleep(500);
}

// Output:
// *.@...*....*....*..@..*....*....*....@*..***@***@****@***@***
