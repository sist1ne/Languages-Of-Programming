using System;

namespace lab8
{
    public class GetYear
    {
        static public int Check(string Message)
        {
            bool Good;
            int num;

            do
            {
                Console.WriteLine(Message);
                Good = int.TryParse(Console.ReadLine(), out num);

                if (num <= 1947 || num > DateTime.Now.Year)
                {
                    Good = false;
                }

                if (!Good)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n��������� ��� �� ����� ���� ������ 1947 � ��������� ������� ���");
                    Console.WriteLine("��������� ����\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return num;
        }
    }
}