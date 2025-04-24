using System;

namespace lab7
{
    public class GetInt
    {
        static public int check (string line)
        {
            bool good;
            int num;

            do
            {
                good = int.TryParse(line, out num);
                if (!good)
                {
                    num = 0;
                    good = true;
                }

            } while (!good);

            return num;
        }
    }
}