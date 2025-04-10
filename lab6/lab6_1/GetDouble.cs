using System;

namespace lab6_1  
{
    public class GetDouble
    {
        static public double Check (string Message)
        {
            bool Good;
            double num;

            do
            {
                Console.WriteLine(Message);
                Good = double.TryParse(Console.ReadLine(), out num);
                if (!Good)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nВведенные данные имеют неверный формат или превышают тип данных Double!");
                    Console.WriteLine("Повторите ввод\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return num;
        }
    }
}