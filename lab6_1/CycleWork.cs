using System;

namespace lab6_1
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
            Console.WriteLine("==========================================================");
            string answer = Console.ReadLine();
            if (answer == "exit")
            {
                Working = false;
            }
        }

        public void ObjectsSummon()
        {
            TwoChars pair1 = new TwoChars();
            Console.WriteLine("������� ����: " + pair1 + "\n");

            TwoChars pair2 = new TwoChars(GetChar.Check("������� ������ �����: "), GetChar.Check("������� ������ �����: "));
            Console.WriteLine("���������������� ����: " + pair2 + "\n");

            TwoChars pair3 = new TwoChars(pair2);
            Console.WriteLine("������������� ���������������� ����: " + pair3 + "\n");

            Console.WriteLine("������ �� ���������������� ����: " + pair2.FieldToString() + "\n");

            Console.WriteLine("----------------------------------------------------------------------------");

            Coordinates daughterPair1 = new Coordinates();
            Console.WriteLine("������� �������� ����: " + daughterPair1 + "\n");

            Coordinates daughterPair2 = new Coordinates(GetChar.Check("������� ������ �����: "), GetChar.Check("������� ������ �����: "), 
                GetDouble.Check("������� ���������� ������ �����: "), GetDouble.Check("������� ���������� ������ �����: "));
            Console.WriteLine("���������������� �������� ����: " + daughterPair2 + "\n");

            Coordinates daughterPair3 = new Coordinates(daughterPair2);
            Console.WriteLine("������������� ���������������� �������� ����: " + daughterPair3 + "\n");

            Console.WriteLine(daughterPair2.Distance() + "\n");
            
        }
    }
}