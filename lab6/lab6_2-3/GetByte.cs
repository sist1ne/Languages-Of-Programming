using System;

namespace lab6_23
{
    public class GetByte
    {
        static public byte Check (string Message)
        {
            bool Good;
            byte num;

            do
            {
                Console.WriteLine(Message);
                Good = byte.TryParse(Console.ReadLine(), out num);
                if (!Good)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nВведенные данные имеют неверный формат или превышают тип данных byte!");
                    Console.WriteLine("Повторите ввод\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return num;
        }
    }
}