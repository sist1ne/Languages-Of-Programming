using System;

namespace lab6_23
{
    class CycleWork
    {
        private bool Working = true;
        public void Start()
        {
            do
            {
                ObjectsSummon();
                Stop();
            } while (Working);
        }

        public void Stop()
        {
            Console.WriteLine("��� ������ �� ��������� �������� exit...");
            Console.WriteLine("===============================================");
            string answer = Console.ReadLine();
            if (answer == "exit")
            {
                Working = false;
            }
        }

        public void ObjectsSummon()
        {
            Money test1 = new Money();
            Console.WriteLine("������� ������: " + test1 + "\n");

            Money test2 = new Money(GetUint.Check("������� ��������������� ���������� ������: "), GetByte.Check("������� ��������������� ���������� ������ �� ����� " + byte.MaxValue + ": ")); 
            Console.WriteLine("1-�� ���������������� ������: " + test2 + "\n");

            Money test3 = new Money(GetUint.Check("������� ��������������� ���������� ������: "), GetByte.Check("������� ��������������� ���������� ������ �� ����� " + byte.MaxValue + ": ")); //
            Console.WriteLine("2-�� ���������������� ������: " + test3 + "\n");

            Money test4 = new Money(test2);
            Console.WriteLine("������������� 1-�� ���������������� ������: " + test4 + "\n");

            Money diff = test2.Subtraction(test3);
            Console.WriteLine("��������� 2-�� ����������������� �� 1-�� ����������������� �������: " + diff + "\n");

            test2++;
            Console.WriteLine("���������� ������� � 1-�� ����������������� �������: " + test2 + "\n");

            test3--;
            Console.WriteLine("��������� ������� �� 2-�� ����������������� �������: " + test3 + "\n");

            uint Rubles = test2;
            Console.WriteLine("������ ����� 1-�� ����������������� �������: " + Rubles + "\n");

            double rubleFromKopek = (double)test3;
            Console.WriteLine("������� ����� ����� �� ������ 2-�� ����������������� �������: " + rubleFromKopek + "\n");

            Money res1 = test2 - 10;
            Console.WriteLine("��������� �� 1-�� ����������������� ������� 10 ������: " + res1 + "\n");

            Money res2 = 1000 - test3;
            Console.WriteLine("��������� �� 1000 ������ 2-�� ����������������� �������: " + res2 + "\n");

            Money res3 = test2 - test3;
            Console.WriteLine("��������� 2-�� ����������������� �� 1-�� ����������������� �������: " + res3 + "\n");

        }
    }
}