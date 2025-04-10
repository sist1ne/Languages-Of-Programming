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
                    Console.WriteLine($"\n��������� ������ ����� �������� ������ ��� ��������� ��� ������ uint!");
                    Console.WriteLine("��������� ����\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return num;
        }
    }
}