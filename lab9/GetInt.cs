using System.Windows;

namespace lab9
{
    /// <summary>
    /// ����� ��� �������� ����� ��� ���� ������ int
    /// </summary>
    public class GetInt
    {
        /// <summary>
        /// �����, ����������� ��������� ������������� �������� �� ����������� ���� int
        /// </summary>
        /// <param name="data">��������� ������������� ������</param>
        /// <returns>�������� ���� int</returns>
        static public int Check (string data)
        {
            int res;

            bool isGood = int.TryParse(data, out res);
            if (!isGood || res < 0) res = -1;

            return res;
        }
    }
}