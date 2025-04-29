using System;

namespace lab8
{
    public class GetBool
    {
        static public bool Check(string Message)
        {
            bool Good;
            bool result = false;
            string text;

            do
            {
                Console.WriteLine(Message);

                Good = true;
                text = Console.ReadLine();

                if (text == "Да")
                {
                    result = true;
                }
                else if (text == "Нет")
                {
                    result = false;
                }
                else
                {
                    Good = false;
                }

                if (!Good)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ввод.");
                    Console.WriteLine("Повторите ввод.\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return result;
        }
    }
}