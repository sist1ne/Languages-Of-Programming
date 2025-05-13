using System;

namespace lab8
{
    public class GetStr
    {
        static public string Check(string Message)
        {
            bool Good;
            string? text;

            do
            {
                Console.WriteLine(Message);

                text = Console.ReadLine();
                if ((text == "") || (text == " "))
                {
                    Good = false;
                }
                else Good = true;

                if (!Good)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("������ ���� �� ����� ���� ������.");
                    Console.WriteLine("��������� ����\n");
                    Console.ForegroundColor = tmp;
                }

            } while (!Good);

            return text;
        }
    }
}