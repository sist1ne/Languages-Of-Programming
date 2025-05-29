using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Money wallet1, wallet2;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для изменения поля для ввода при его активации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (temp.Text == "Введите число...")
                temp.Text = "";
        }

        /// <summary>
        /// При нажатии на кнопку меняет значения в полях рублей и копеек между счётами 1 и 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SwapButton(object sender, RoutedEventArgs e)
        {
            int rub1 = GetInt.Check(Rub1.Text);
            int kop1 = GetIntForByte.Check(Kop1.Text);

            int rub2 = GetInt.Check(Rub2.Text);
            int kop2 = GetIntForByte.Check(Kop2.Text);

            if (rub1 != -1 && kop1 != -1 && rub2 != -1 && kop2 != -1) {
                string temp = Rub1.Text;
                Rub1.Text = Rub2.Text;
                Rub2.Text = temp;

                temp = Kop1.Text;
                Kop1.Text = Kop2.Text;
                Kop2.Text = temp;
            }
            else
                MessageBox.Show("Нельзя поменять местами нецифровые значения и числа, не входящие в диапазоны полей.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Метод для вывода ошибок согласно некорректно введенным данным
        /// </summary>
        /// <param name="rub1">Поле ввода рублей счёта 1</param>
        /// <param name="kop1">Поле ввода копеек счёта 1</param>
        /// <param name="rub2">Поле ввода рублей счёта 2</param>
        /// <param name="kop2">Поле ввода копеек счёта 2</param>
        /// <param name="sum">Поле ввода некой суммы</param>
        private void ShowError(int rub1, int kop1, int rub2, int kop2, int sum)
        {
            if (rub1 == -1)
                MessageBox.Show("Некорректно введены рубли счёта №1.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (kop1 == -1)
                MessageBox.Show("Некорректно введены копейки счёта №1.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (rub2 == -1)
                MessageBox.Show("Некорректно введены рубли счёта №2.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (kop2 == -1)
                MessageBox.Show("Некорректно введены копейки счёта №2.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (sum == -1)
                MessageBox.Show("Некорректно введена некая сумма.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("Неизвестная ошибка.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// При нажатии на кнопку вычисляет разницу между счётами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubstractionFunc(object sender, RoutedEventArgs e)
        {
            int rub1 = GetInt.Check(Rub1.Text);
            int kop1 = GetIntForByte.Check(Kop1.Text);

            int rub2 = GetInt.Check(Rub2.Text);
            int kop2 = GetIntForByte.Check(Kop2.Text);

            if (rub1 != -1 && rub2 != -1 && kop1 != -1 && kop2 != -1)
            {
                wallet1 = new Money((uint)rub1, (byte)kop1);
                wallet2 = new Money((uint)rub2, (byte)kop2);

                Money result = wallet1.Subtraction(wallet2);
                MessageBox.Show($"Счёт:{result}", "Результат операции", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                ShowError(rub1, kop1, rub2, kop2, 0);
        }
        
        /// <summary>
        /// При нажатии на кнопку увеличивает счёт 1 на копейку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncreaseFunc(object sender, RoutedEventArgs e)
        {
            int rub1 = GetInt.Check(Rub1.Text);
            int kop1 = GetIntForByte.Check(Kop1.Text);

            if (rub1 != -1 && kop1 != -1)
            {
                wallet1 = new Money((uint)rub1, (byte)kop1);

                Money result = ++wallet1;
                MessageBox.Show($"Счёт:{result}", "Результат операции", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                ShowError(rub1, kop1, 0, 0, 0);
        }

        /// <summary>
        /// При нажатии на кнопку уменьшает счёт 1 на копейку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecreaseFunc(object sender, RoutedEventArgs e)
        {
            int rub1 = GetInt.Check(Rub1.Text);
            int kop1 = GetIntForByte.Check(Kop1.Text);

            if (rub1 != -1 && kop1 != -1)
            {
                wallet1 = new Money((uint)rub1, (byte)kop1);

                Money result = --wallet1;
                MessageBox.Show($"Счёт:{result}", "Результат операции", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                ShowError(rub1, kop1, 0, 0, 0);
        }

        /// <summary>
        /// При нажатии на кнопку вычитает из счёта 1 счёт 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoneyMinusFunc(object sender, RoutedEventArgs e)
        {
            int rub1 = GetInt.Check(Rub1.Text);
            int kop1 = GetIntForByte.Check(Kop1.Text);

            int rub2 = GetInt.Check(Rub2.Text);
            int kop2 = GetIntForByte.Check(Kop2.Text);

            if (rub1 != -1 && rub2 != -1 && kop1 != -1 && kop2 != -1)
            {
                wallet1 = new Money((uint)rub1, (byte)kop1);
                wallet2 = new Money((uint)rub2, (byte)kop2);

                Money result = wallet1 - wallet2;
                MessageBox.Show($"Счёт:{result}", "Результат операции", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                ShowError(rub1, kop1, rub2, kop2, 0);
        }

        /// <summary>
        /// При нажатии на кнопку возвращает значение рублей счёта 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetRublesFunc(object sender, RoutedEventArgs e)
        {
            int rub2 = GetInt.Check(Rub2.Text);
            int kop2 = GetIntForByte.Check(Kop2.Text);

            if (rub2 != -1 && kop2 != -1)
            {
                wallet2 = new Money((uint)rub2, (byte)kop2);

                uint result = wallet2;
                MessageBox.Show($"Рубли для счёта №2:\n{result}", "Результат операции", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                ShowError(0, 0, rub2, kop2, 0);
        }

        /// <summary>
        /// При нажатии на кнопку возвращает значение копейки счёта 2 в формате рубля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetKopeksFunc(object sender, RoutedEventArgs e)
        {
            int rub2 = GetInt.Check(Rub2.Text);
            int kop2 = GetIntForByte.Check(Kop2.Text);

            if (rub2 != -1 && kop2 != -1)
            {
                wallet2 = new Money((uint)rub2, (byte)kop2);

                double result = (double)wallet2;
                MessageBox.Show($"Копейки в формате рублей для счёта №2:\n{result}", "Результат операции", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                ShowError(0, 0, rub2, kop2, 0);
        }

        /// <summary>
        /// При нажатии на кнопку вычитает из заданной суммы счёт 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AmountMinusFunc(object sender, RoutedEventArgs e)
        {
            int sum = GetInt.Check(Sum.Text);
            int rub2 = GetInt.Check(Rub2.Text);
            int kop2 = GetIntForByte.Check(Kop2.Text);

            if (rub2 != -1 && kop2 != -1 && sum != -1)
            {
                wallet2 = new Money((uint)rub2, (byte)kop2);

                Money result = (uint)sum - wallet2;
                MessageBox.Show($"Остаток от суммы:{result}", "Результат операции", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                ShowError(0, 0, rub2, kop2, sum);
        }

        /// <summary>
        /// При нажатии на кнопку вычитает из счёта 2 заданную сумму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinusAmountFunc(object sender, RoutedEventArgs e)
        {
            int sum = GetInt.Check(Sum.Text);
            int rub2 = GetInt.Check(Rub2.Text);
            int kop2 = GetIntForByte.Check(Kop2.Text);

            if (rub2 != -1 && kop2 != -1 && sum != -1)
            {
                wallet2 = new Money((uint)rub2, (byte)kop2);

                Money result = wallet2 - (uint)sum;
                MessageBox.Show($"Остаточный счёт:{result}", "Результат операции", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                ShowError(0, 0, rub2, kop2, sum);
        }
    }
}