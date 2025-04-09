using System;

namespace lab6_1
{
    public class GetChar
    {
        static public char Check(string Message)
        {
            bool Good;
            char letter;

            do
            {
                Console.WriteLine(Message);
                Good = char.TryParse(Console.ReadLine(), out letter);
                if (!Good)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n��������� ������ ����� �������� ������!");
                    Console.WriteLine("��������� ����\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return letter;
        }
    }

}