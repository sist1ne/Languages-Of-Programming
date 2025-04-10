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
                    Console.WriteLine($"\n��������� ������ ����� �������� ������ ��� ��������� ��� ������ Double!");
                    Console.WriteLine("��������� ����\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return num;
        }
    }
}