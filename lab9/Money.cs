using System;

namespace lab9
{
    /// <summary>
    /// Класс, описывающий объект деньги с двумя полями для хранения рублей и копеек
    /// </summary>
    class Money
    {
        private uint Rubles;
        private byte Kopeks;

        public Money() { }

        public Money(uint Rubles, byte Kopeks)
        {   
            this.Rubles = Rubles;
            if (Kopeks >= 100)
            {
                this.Kopeks = (byte)(Kopeks-100);
                this.Rubles++;
            }
            else this.Kopeks = Kopeks;
        }

        public Money(Money Cash)
        {
            Rubles = Cash.Rubles;
            Kopeks = Cash.Kopeks;
        }

        /// <summary>
        /// Метод для вычитания объекта из объекта
        /// </summary>
        /// <param name="Cash1">Вычитаемый объект</param>
        /// <returns>Новый результирующий после вычитания объект</returns>
        public Money Subtraction(Money Cash1)
        {
            Money ResCash = new Money();

            if (Cash1.Rubles > Rubles && Cash1.Kopeks > Kopeks)
            {
                ResCash.Rubles = Cash1.Rubles - Rubles;
                ResCash.Kopeks = (byte)(Cash1.Kopeks - Kopeks);
            }
            else if (Cash1.Rubles > Rubles && Cash1.Kopeks < Kopeks)
            {
                ResCash.Rubles = Cash1.Rubles - Rubles - 1;
                ResCash.Kopeks = (byte)(Cash1.Kopeks - Kopeks + 100);
            }
            else if (Cash1.Rubles < Rubles && Cash1.Kopeks > Kopeks)
            {
                ResCash.Rubles = Rubles - Cash1.Rubles - 1;
                ResCash.Kopeks = (byte)(Kopeks - Cash1.Kopeks + 100);
            }
            else if (Cash1.Rubles < Rubles && Cash1.Kopeks < Kopeks)
            {
                ResCash.Rubles = Rubles - Cash1.Rubles;
                ResCash.Kopeks = (byte)(Kopeks - Cash1.Kopeks);
            }
            else if (Cash1.Rubles > Rubles)
            {
                ResCash.Rubles = Cash1.Rubles - Rubles;
                ResCash.Kopeks = 0;
            }
            else if (Cash1.Rubles < Rubles)
            {
                ResCash.Rubles = Rubles - Cash1.Rubles;
                ResCash.Kopeks = 0;
            }
            else if (Cash1.Kopeks > Kopeks)
            {
                ResCash.Rubles = 0;
                ResCash.Kopeks = (byte)(Cash1.Kopeks - Kopeks);
            }
            else if (Cash1.Kopeks < Kopeks)
            {
                ResCash.Rubles = 0;
                ResCash.Kopeks = (byte)(Kopeks - Cash1.Kopeks);
            }
            else
            {
                ResCash.Rubles = 0;
                ResCash.Kopeks = 0;
            }

            return ResCash;
        }

        /// <summary>
        /// Оператор увеличения на 1 копейку
        /// </summary>
        /// <param name="money">Объект</param>
        /// <returns>Новый измененный объект</returns>
        public static Money operator ++(Money money)
        {
            Money ResCash = new Money(money);

            ResCash.Kopeks++;
            if (ResCash.Kopeks > 99)
            {
                ResCash.Rubles += 1;
                ResCash.Kopeks -= 100;
            }

            return ResCash;
        }

        /// <summary>
        /// Оператор уменьшения на 1 копейку
        /// </summary>
        /// <param name="money">Объект</param>
        /// <returns>Новый измененный объект</returns>
        public static Money operator --(Money money)
        {
            Money ResCash = new Money(money);

            if (ResCash.Kopeks == 0)
            {
                if (ResCash.Rubles != 0)
                {
                    ResCash.Rubles -= 1;
                }
                else { }

                ResCash.Kopeks = 99;
            }
            else
                ResCash.Kopeks--;

            return ResCash;
        }

        /// <summary>
        /// Неявный оператор возврата значения рублей объекта
        /// </summary>
        /// <param name="money"></param>
        public static implicit operator uint(Money money)
        {
            return money.Rubles;
        }

        /// <summary>
        /// Явный оператор возврата значения копеек объекта в формате рублей 
        /// </summary>
        /// <param name="money"></param>
        public static explicit operator double(Money money)
        {
            return (money.Kopeks / 100.0);
        }

        /// <summary>
        /// Оператор вычитания из объекта рублей
        /// </summary>
        /// <param name="m">Объект</param>
        /// <param name="num">Вычитаемые рубли</param>
        /// <returns>Новый измененный объект</returns>
        public static Money operator -(Money m, uint num)
        {
            uint Rubles;
            byte Kopeks;

            if (m.Rubles >= num)
            {
                Rubles = m.Rubles - num;
                Kopeks = m.Kopeks;
            }
            else
            {
                Rubles = 0;
                Kopeks = 0;
            }
            return new Money(Rubles, Kopeks);
        }


        /// <summary>
        /// Оператор вычитания из рублей объекта
        /// </summary>
        /// <param name="num">Вычитаемые рубли</param>
        /// <param name="m">Объект</param>
        /// <returns>Новый измененный объект</returns>
        public static Money operator -(uint num, Money m)
        {
            uint Rubles;
            byte Kopeks;

            if (num > m.Rubles)
            {
                Rubles = num - m.Rubles - 1;
                Kopeks = (byte)(100 - m.Kopeks);
            }
            else
            {
                Rubles = 0;
                Kopeks = 0;
            }
            return new Money(Rubles, Kopeks);
        }


        /// <summary>
        /// Оператор вычитания из объекта объекта
        /// </summary>
        /// <param name="m">Объект</param>
        /// <param name="m2">Вычитаемый объект</param>
        /// <returns></returns>
        public static Money operator -(Money m, Money m2)
        {
            Money ResCash = new Money();

            if (m.Rubles > m2.Rubles && m.Kopeks > m2.Kopeks)
            {
                ResCash.Rubles = m.Rubles - m2.Rubles;
                ResCash.Kopeks = (byte)(m.Kopeks - m2.Kopeks);
            }
            else if (m.Rubles > m2.Rubles && m.Kopeks < m2.Kopeks)
            {
                ResCash.Rubles = m.Rubles - m2.Rubles - 1;
                ResCash.Kopeks = (byte)(m.Kopeks - m2.Kopeks + 100);
            }
            else if (m.Rubles > m2.Rubles)
            {
                ResCash.Rubles = m.Rubles - m2.Rubles;
                ResCash.Kopeks = 0;
            }
            else if (m.Kopeks > m2.Kopeks)
            {
                ResCash.Rubles = 0;
                ResCash.Kopeks = (byte)(m.Kopeks - m2.Kopeks);
            }
            else
            {
                ResCash.Rubles = 0;
                ResCash.Kopeks = 0;
            }

            return ResCash;
        }

        public override string ToString()
        {
            return $"\nРубли: {Rubles}\nКопейки: {Kopeks}";
        }
    }
}