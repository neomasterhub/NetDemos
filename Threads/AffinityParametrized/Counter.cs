using System;

namespace AffinityParametrized
{
    internal class Counter
    {
        private static bool _stop;

        private readonly string _name;

        public Counter(string name)
        {
            _name = name;
        }

        public void Run()
        {
            long i;

            for (i = 0; !_stop && i < 1_000_000_000; i++) ;

            _stop = true;

            Console.WriteLine("Поток {0,12}, i={1}", _name, i);
        }
    }
}
