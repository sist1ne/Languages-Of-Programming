using System;

namespace lab6_23
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Здравствуйте! Данная программа работает с денежными мерами: рубль и копейка.");

            CycleWork work = new CycleWork();

            work.Start();
        }
    }
}