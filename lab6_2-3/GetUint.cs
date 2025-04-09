using System;

namespace lab6_23  
{
    public class GetUint
    {
        static public uint Check (string Message)
        {
            bool Good;
            uint num;

            do
            {
                Console.WriteLine(Message);
                Good = uint.TryParse(Console.ReadLine(), out num);
                if (!Good)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nВведенные данные имеют неверный формат или превышают тип данных uint!");
                    Console.WriteLine("Повторите ввод\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return num;
        }
    }
}