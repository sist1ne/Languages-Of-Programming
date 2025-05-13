using System;

namespace lab8  
{
    public class GetDecimal
    {
        static public decimal Check (string Message)
        {
            bool Good;
            decimal num;

            do
            {
                Console.WriteLine(Message);
                Good = decimal.TryParse(Console.ReadLine(), out num);
                if (!Good)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введенные данные имеют неверный формат.");
                    Console.WriteLine("Повторите ввод\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return num;
        }
    }
}