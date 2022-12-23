using Join;

Threads.Thread1.Start();
Threads.Thread2.Start();

Threads.Thread2.Join();
Threads.For('.');

Console.ReadKey();
//*****+++++.....
