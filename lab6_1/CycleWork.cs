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
            Console.WriteLine("Для выхода из программы напишите exit...");
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
            Console.WriteLine("Базовая пара: " + pair1 + "\n");

            TwoChars pair2 = new TwoChars(GetChar.Check("Введите первую букву: "), GetChar.Check("Введите вторую букву: "));
            Console.WriteLine("Пользовательская пара: " + pair2 + "\n");

            TwoChars pair3 = new TwoChars(pair2);
            Console.WriteLine("Скопированная пользовательская пара: " + pair3 + "\n");

            Console.WriteLine("Строка из пользовательской пары: " + pair2.FieldToString() + "\n");

            Console.WriteLine("----------------------------------------------------------------------------");

            Coordinates daughterPair1 = new Coordinates();
            Console.WriteLine("Базовая дочерняя пара: " + daughterPair1 + "\n");

            Coordinates daughterPair2 = new Coordinates(GetChar.Check("Введите первую точку: "), GetChar.Check("Введите вторую точку: "), 
                GetDouble.Check("Введите координату первой точки: "), GetDouble.Check("Введите координату второй точки: "));
            Console.WriteLine("Пользовательская дочерняя пара: " + daughterPair2 + "\n");

            Coordinates daughterPair3 = new Coordinates(daughterPair2);
            Console.WriteLine("Скопированная пользовательская дочерняя пара: " + daughterPair3 + "\n");

            Console.WriteLine(daughterPair2.Distance() + "\n");
            
        }
    }
}