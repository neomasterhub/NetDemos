using System;
using System.Diagnostics;
using System.Threading;

namespace AffinityProgrammed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(TimeSpan.FromSeconds(15));

            // CPU3 | CPU2 | CPU1 | CPU0
            // off  | on   | on   | off   <-> 0110 = 6(dec)
            Process.GetCurrentProcess().ProcessorAffinity = (IntPtr)6;

            while (true) ;
        }

    }
}
