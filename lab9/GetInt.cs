using System.Windows;

namespace lab9
{
    /// <summary>
    ///  ласс дл€ проверки ввода дл€ типа данных int
    /// </summary>
    public class GetInt
    {
        /// <summary>
        /// ћетод, провер€ющий введенные пользователем значени€ на соответсвие типу int
        /// </summary>
        /// <param name="data">¬веденные пользователем данные</param>
        /// <returns>«начение типа int</returns>
        static public int Check (string data)
        {
            int res;

            bool isGood = int.TryParse(data, out res);
            if (!isGood || res < 0) res = -1;

            return res;
        }
    }
}