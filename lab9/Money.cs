using System;

namespace lab9
{
    /// <summary>
    /// �����, ����������� ������ ������ � ����� ������ ��� �������� ������ � ������
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
        /// ����� ��� ��������� ������� �� �������
        /// </summary>
        /// <param name="Cash1">���������� ������</param>
        /// <returns>����� �������������� ����� ��������� ������</returns>
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
        /// �������� ���������� �� 1 �������
        /// </summary>
        /// <param name="money">������</param>
        /// <returns>����� ���������� ������</returns>
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
        /// �������� ���������� �� 1 �������
        /// </summary>
        /// <param name="money">������</param>
        /// <returns>����� ���������� ������</returns>
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
        /// ������� �������� �������� �������� ������ �������
        /// </summary>
        /// <param name="money"></param>
        public static implicit operator uint(Money money)
        {
            return money.Rubles;
        }

        /// <summary>
        /// ����� �������� �������� �������� ������ ������� � ������� ������ 
        /// </summary>
        /// <param name="money"></param>
        public static explicit operator double(Money money)
        {
            return (money.Kopeks / 100.0);
        }

        /// <summary>
        /// �������� ��������� �� ������� ������
        /// </summary>
        /// <param name="m">������</param>
        /// <param name="num">���������� �����</param>
        /// <returns>����� ���������� ������</returns>
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
        /// �������� ��������� �� ������ �������
        /// </summary>
        /// <param name="num">���������� �����</param>
        /// <param name="m">������</param>
        /// <returns>����� ���������� ������</returns>
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
        /// �������� ��������� �� ������� �������
        /// </summary>
        /// <param name="m">������</param>
        /// <param name="m2">���������� ������</param>
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
            return $"\n�����: {Rubles}\n�������: {Kopeks}";
        }
    }
}