using System;

namespace lab6_1
{
    class Coordinates : TwoChars
    {
        public double CoordinateFirst { get; set; }
        public double CoordinateSecond { get; set; }

        public Coordinates() : base()
        {
            CoordinateFirst = 0;
            CoordinateSecond = 0;
        }

        public Coordinates(char First, char Second, double CoordinateFirst, double CoordinateSecond) : base(First, Second)
        {
            this.CoordinateFirst = CoordinateFirst;
            this.CoordinateSecond = CoordinateSecond;
        }

        public Coordinates(Coordinates pair) : base(pair)
        {
            CoordinateFirst = pair.CoordinateFirst;
            CoordinateSecond = pair.CoordinateSecond;
        }

        public string Distance()
        {
            double temp1 = Math.Abs(CoordinateFirst);
            double temp2 = Math.Abs(CoordinateSecond);
            double distance;

            if (temp1 > temp2)
                distance = temp1 - temp2;
            else
                distance = temp2 - temp1;
            
            return $"Расстояние между точками: {distance}";
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nКоордината первой точки: {CoordinateFirst}\nКоордината второй точки: {CoordinateSecond}";
        }
    }
}