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
                    Console.WriteLine("���� �� ����� ���� ������ 1947 � ����� ������� ����.");
                }

                if (!Good)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("�������� ������ ����.");
                    Console.WriteLine("��������� ����\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return date;
        }
    }
}