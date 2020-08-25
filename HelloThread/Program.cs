using System;
using System.Threading;

namespace HelloThread
{
    class Program
    {
        public static int Counter = 0;
        public static int CounterMamas = 0;
        public static int CounterEmpire = 0;

        public static void Main(string[] args)
        {
            Thread threadMamas = new Thread(() => Print1("Mamas"));
            // threadMamas.IsBackground = true;
            threadMamas.Start();

            Thread threadEmpire = new Thread(() => Print2("Empire"));
            // threadEmpire.IsBackground = true;
            threadEmpire.Start();

            threadEmpire.Join();
            threadMamas.Join();
            Console.WriteLine($"mamas: {CounterMamas}");
            Console.WriteLine($"empire: {CounterEmpire}");
        }
        public static void Print(string word)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(word);
            }
        }
        public static void Print1(string word)
        {

            while (Counter<100)
            {
                if (Counter % 2 == 0)
                {
                    Console.WriteLine(word);
                    Counter++;
                    Interlocked.Increment(ref CounterMamas);
                }
            }
        }
        public static void Print2(string word)
        {
            while (Counter < 100)
            {
                if (Counter % 2 != 0)
                {
                    Console.WriteLine(word);
                    Counter++;
                    Interlocked.Increment(ref CounterEmpire);
                }
            }
        }
    }
}
