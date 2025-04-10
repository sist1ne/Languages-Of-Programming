using System;

namespace lab6_1
{
    class TwoChars
    {
        private char First { get; }
        private char Second { get; }

        public TwoChars()
        {
            First = 'A';
            Second = 'B';
        }

        public TwoChars(char First, char Second)
        {
            this.First = First;
            this.Second = Second;
        }

        public TwoChars(TwoChars pair)
        {
            First = pair.First;
            Second = pair.Second;
        }

        public string FieldToString()
        {
            return string.Concat("\n������ �����: ", First, "\n������ �����: ", Second);
        }

        public override string ToString()
        {
            return $"\n������ �����: {First}\n������ �����: {Second}";
        }
    }
}