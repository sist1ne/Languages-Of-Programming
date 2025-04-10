using System;

namespace lab6_23
{
    class Money
    {
        private uint Rubles;
        private byte Kopeks;

        public Money()
        {
            Rubles = 0;
            Kopeks = 0;
        }

        public Money(uint Rubles, byte Kopeks)
        {
            this.Rubles = Rubles;
            if (Kopeks > 99)
            {
                while(Kopeks > 99)
                {
                    this.Rubles++;
                    Kopeks -= 100;
                } 
                this.Kopeks = Kopeks;
            }
            else 
                this.Kopeks = Kopeks;
        }

        public Money(Money Cash)
        {
            Rubles = Cash.Rubles;
            Kopeks = Cash.Kopeks;
        }

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

        public static Money operator --(Money money)
        {
            Money ResCash = new Money(money);
            if (ResCash.Rubles != 0 || ResCash.Kopeks != 0)
            {
                if (ResCash.Kopeks == 0)
                {
                    ResCash.Rubles -= 1;
                    ResCash.Kopeks = 99;
                }
                else
                    ResCash.Kopeks--;
            }
            else
            {
                ResCash.Rubles = 0;
                ResCash.Kopeks = 0;
            }

            return ResCash;
        }

        public static implicit operator uint(Money money)
        {
            return money.Rubles;
        }

        public static explicit operator double(Money money)
        {
            return (money.Kopeks / 100.0);
        }

        public static Money operator -(Money m, uint num)
        {
            uint Rubles;
            byte Kopeks;

            if (m.Rubles > num)
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
            return $"\nÐóáëåé: {Rubles}\nÊîïååê: {Kopeks}";
        }
    }
}
