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
            Console.WriteLine("Для выхода из программы напишите exit...");
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
            Console.WriteLine("Базовый объект: " + test1 + "\n");

            Money test2 = new Money(GetUint.Check("Введите неотрицательное количество рублей: "), GetByte.Check("Введите неотрицательное количество копеек не более " + byte.MaxValue + ": ")); 
            Console.WriteLine("1-ый пользовательский объект: " + test2 + "\n");

            Money test3 = new Money(GetUint.Check("Введите неотрицательное количество рублей: "), GetByte.Check("Введите неотрицательное количество копеек не более " + byte.MaxValue + ": ")); //
            Console.WriteLine("2-ой пользовательский объект: " + test3 + "\n");

            Money test4 = new Money(test2);
            Console.WriteLine("Скопированный 1-ый пользовательский объект: " + test4 + "\n");

            Money diff = test2.Subtraction(test3);
            Console.WriteLine("Вычитание 2-го пользовательского из 1-го пользовательского объекта: " + diff + "\n");

            test2++;
            Console.WriteLine("Добавление копейки к 1-му пользовательскому объекту: " + test2 + "\n");

            test3--;
            Console.WriteLine("Вычитание копейки из 2-го пользовательского объекта: " + test3 + "\n");

            uint Rubles = test2;
            Console.WriteLine("Только рубли 1-го пользовательского объекта: " + Rubles + "\n");

            double rubleFromKopek = (double)test3;
            Console.WriteLine("Дробная часть рубля от копеек 2-го пользовательского объекта: " + rubleFromKopek + "\n");

            Money res1 = test2 - 10;
            Console.WriteLine("Вычитание из 1-го пользовательского объекта 10 рублей: " + res1 + "\n");

            Money res2 = 1000 - test3;
            Console.WriteLine("Вычитание из 1000 рублей 2-го пользовательского объекта: " + res2 + "\n");

            Money res3 = test2 - test3;
            Console.WriteLine("Вычитание 2-го пользовательского из 1-го пользовательского объекта: " + res3 + "\n");

        }
    }
}