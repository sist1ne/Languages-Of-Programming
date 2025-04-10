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
                    Console.WriteLine($"\n��������� ������ ����� �������� ������ ��� ��������� ��� ������ byte!");
                    Console.WriteLine("��������� ����\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return num;
        }
    }
}