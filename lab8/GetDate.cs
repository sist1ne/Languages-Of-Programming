using System;

namespace lab8  
{
    public class GetDate
    {
        static public DateTime Check (string Message)
        {
            bool Good;
            DateTime date;

            do
            {
                Console.WriteLine(Message);

                Good = DateTime.TryParse(Console.ReadLine(), out date);

                if (date > DateTime.Now || date.Year == 1947)
                {
                    Good = false;
                    Console.WriteLine("Дата не может быть раньше 1947 и позже текущей даты.");
                }

                if (!Good)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат даты.");
                    Console.WriteLine("Повторите ввод\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return date;
        }
    }
}