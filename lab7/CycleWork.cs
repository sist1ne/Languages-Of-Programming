using System;
using System.Xml.Linq;

namespace lab7
{
    class CycleWork
    {
        public string _path = "C:\\Users\\eat_h\\Desktop\\ЯП\\7 лаба\\lab7\\FILES\\";
        public string bookPath = "C:\\Users\\eat_h\\Desktop\\ЯП\\7 лаба\\lab7\\FILES\\books.txt";
        private bool _working = true;

        public void start()
        {
            do
            {
                choice();
            } while (_working);
        }

        public void choice()
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("1. Произведение min и max значений из файла.");
            Console.WriteLine("2. Количество нечетных элементов.");
            Console.WriteLine("3. Создать новый файл, где строка - длина строки старого файла.");
            Console.WriteLine("4. Создать новый файл по условию 4-го задания.");
            Console.WriteLine("5. Игрушки для детей от 4 до 10 лет.");
            Console.WriteLine("6. Добавление в список этого же списка после элемента.");
            Console.WriteLine("7. Добавить в начало и конец списка новый элемент.");
            Console.WriteLine("8. Определение популярности книг.");
            Console.WriteLine("9. Наличие символов в тексте по условию 9-го задания.");
            Console.WriteLine("10. Задание не выполнено.");
            Console.WriteLine("11. Выйти из программы");
            Console.WriteLine("Выберите действие: ");
            string? answer = Console.ReadLine();

            if (answer == "1")
            {
                Console.WriteLine("Введите имя файла: ");
                int result = Files.MultiplyMaxAndMin(_path + Console.ReadLine());
                Console.WriteLine("Результат: " + result);
                Console.WriteLine("------------------------------------------------\n");
            }
            else if (answer == "2")
            {
                Console.WriteLine("Введите имя файла: ");
                int result = Files.AmountOfOddNums(_path + Console.ReadLine());
                Console.WriteLine("Результат: " + result);
                Console.WriteLine("------------------------------------------------\n");
            }
            else if (answer == "3")
            {
                Console.WriteLine("Введите имя файла: ");
                string? temp = _path + Console.ReadLine();
                Console.WriteLine("Введите имя нового файла: ");
                Files.FileWithLenghts(temp, _path + Console.ReadLine());
                Console.WriteLine("Файл создан.");
                Console.WriteLine("------------------------------------------------\n");
            }
            else if (answer == "4")
            {
                Console.WriteLine("Введите имя файла: ");
                string? temp = _path + Console.ReadLine();
                Console.WriteLine("Введите имя нового файла: ");
                Files.FileWithStairs(temp, _path + Console.ReadLine());
                Console.WriteLine("Файл создан.");
                Console.WriteLine("------------------------------------------------\n");
            }
            else if (answer == "5")
            {
                Toy[] toys = new Toy[5];
                toys[0] = new Toy("Мяч", 500, 0, 15);
                toys[1] = new Toy("Меч", 1000, 5, 12);
                toys[2] = new Toy("Щит", 500, 3, 12);
                toys[3] = new Toy("Пистолет", 300, 10, 20);
                toys[4] = new Toy("Солдатик", 50, 3, 10);

                Files.ToysInBinFile(_path+"toys.xml", toys);

                Console.WriteLine("Результат: ");
                Files.ToysForSpecAge(_path + "toys.xml");
                Console.WriteLine("------------------------------------------------\n");

            }
            else if (answer == "6")
            {
                List<string> nums = new List<string>() { 
                    "1", "2", "da", "4", "5"
                };

                Console.WriteLine("Список: ");
                foreach (string str in nums)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine("\n");

                Console.WriteLine("Введите элемент после которого вставить список: ");
                string? element = Console.ReadLine();
                Lists.AddListAfterElem(nums, element);
                Console.WriteLine("Результирующий список: ");
                foreach (string str in nums)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine("\n");
            }
            else if (answer == "7")
            {
                LinkedList<string> nums = new LinkedList<string>();
                nums.AddFirst("5");
                nums.AddFirst("4");
                nums.AddFirst("da");
                nums.AddFirst("2");
                nums.AddFirst("1");

                Console.WriteLine("Список: ");
                foreach (string str in nums)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine("\n");

                Console.WriteLine("Введите элемент который вставить в начало и конец списка: ");
                string? element = Console.ReadLine();
                Lists.AddFrontAndBack(nums, element);
                Console.WriteLine("Результирующий список: ");
                foreach (string str in nums)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine("\n");
            }
            else if (answer == "8")
            {
                string[] allBooks = new string[] { "Книга1", "Книга2", "Книга3", "Книга4", "Книга5", "Книга6" };
                //каждая строка в файле отображает читателя - в строке записаны названия книг, которые он прочитал
                Hash.WhoHaveReadTheBook(
                    bookPath,
                    allBooks,
                    out var allHaveRead,
                    out var someHaveRead,
                    out var noneHaveRead);

                Console.WriteLine("Все читали: ");
                foreach (string str in allHaveRead)
                {
                    Console.Write(str + "; ");
                }
                Console.WriteLine("\n");

                Console.WriteLine("Некоторые читали: ");
                foreach (string str in someHaveRead)
                {
                    Console.Write(str + "; ");
                }
                Console.WriteLine("\n");

                Console.WriteLine("Никто не читал: ");
                foreach (string str in noneHaveRead)
                {
                    Console.Write(str + "; ");
                }
                Console.WriteLine("\n");
            }
            else if (answer == "9")
            {
                Console.WriteLine("Введите имя файла: ");
                HashSet<char> result = Hash.SymbolsFromAllWordsExceptFirst(_path + Console.ReadLine());
                Console.WriteLine("Символы, которые подходят под условие задачи: ");
                foreach(char letter in result)
                {
                    Console.Write(letter + " ");
                }
                Console.WriteLine("\n");
            }
            else if (answer == "10")
            {
                Console.WriteLine("Это задание не выполненно.\n");
            }
            else if (answer == "11")
            {
                _working = false;
            }
            else
            {
                Console.WriteLine("Неверный выбор действия! Выберите действие.");
                choice();
            }
        }
    }
}