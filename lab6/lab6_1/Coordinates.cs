using System;

namespace lab6_1
{
    class Coordinates : TwoChars
    {
        private double CoordinateFirst { get; }
        private double CoordinateSecond { get; }

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
            double distance = Math.Abs(CoordinateFirst - CoordinateSecond);
            
            return $"Расстояние между точками: {distance}";
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nКоордината первой точки: {CoordinateFirst}\nКоордината второй точки: {CoordinateSecond}";
        }
    }
}