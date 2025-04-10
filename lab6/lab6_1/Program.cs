using System;

namespace lab6_1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Здравствуйте! Эта программа работает с двумя точками и их координатами\nна одной оси и может вычислить расстояние между ними.");
            CycleWork work = new CycleWork();

            work.Start();
        }
    }
}