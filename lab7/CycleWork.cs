using System;
using System.Xml.Linq;

namespace lab7
{
    class CycleWork
    {
        public string _path = "C:\\Users\\eat_h\\Desktop\\��\\7 ����\\lab7\\FILES\\";
        public string bookPath = "C:\\Users\\eat_h\\Desktop\\��\\7 ����\\lab7\\FILES\\books.txt";
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
            Console.WriteLine("��� �� ������ �������?");
            Console.WriteLine("1. ������������ min � max �������� �� �����.");
            Console.WriteLine("2. ���������� �������� ���������.");
            Console.WriteLine("3. ������� ����� ����, ��� ������ - ����� ������ ������� �����.");
            Console.WriteLine("4. ������� ����� ���� �� ������� 4-�� �������.");
            Console.WriteLine("5. ������� ��� ����� �� 4 �� 10 ���.");
            Console.WriteLine("6. ���������� � ������ ����� �� ������ ����� ��������.");
            Console.WriteLine("7. �������� � ������ � ����� ������ ����� �������.");
            Console.WriteLine("8. ����������� ������������ ����.");
            Console.WriteLine("9. ������� �������� � ������ �� ������� 9-�� �������.");
            Console.WriteLine("10. ������� �� ���������.");
            Console.WriteLine("11. ����� �� ���������");
            Console.WriteLine("�������� ��������: ");
            string? answer = Console.ReadLine();

            if (answer == "1")
            {
                Console.WriteLine("������� ��� �����: ");
                int result = Files.MultiplyMaxAndMin(_path + Console.ReadLine());
                Console.WriteLine("���������: " + result);
                Console.WriteLine("------------------------------------------------\n");
            }
            else if (answer == "2")
            {
                Console.WriteLine("������� ��� �����: ");
                int result = Files.AmountOfOddNums(_path + Console.ReadLine());
                Console.WriteLine("���������: " + result);
                Console.WriteLine("------------------------------------------------\n");
            }
            else if (answer == "3")
            {
                Console.WriteLine("������� ��� �����: ");
                string? temp = _path + Console.ReadLine();
                Console.WriteLine("������� ��� ������ �����: ");
                Files.FileWithLenghts(temp, _path + Console.ReadLine());
                Console.WriteLine("���� ������.");
                Console.WriteLine("------------------------------------------------\n");
            }
            else if (answer == "4")
            {
                Console.WriteLine("������� ��� �����: ");
                string? temp = _path + Console.ReadLine();
                Console.WriteLine("������� ��� ������ �����: ");
                Files.FileWithStairs(temp, _path + Console.ReadLine());
                Console.WriteLine("���� ������.");
                Console.WriteLine("------------------------------------------------\n");
            }
            else if (answer == "5")
            {
                Toy[] toys = new Toy[5];
                toys[0] = new Toy("���", 500, 0, 15);
                toys[1] = new Toy("���", 1000, 5, 12);
                toys[2] = new Toy("���", 500, 3, 12);
                toys[3] = new Toy("��������", 300, 10, 20);
                toys[4] = new Toy("��������", 50, 3, 10);

                Files.ToysInBinFile(_path+"toys.xml", toys);

                Console.WriteLine("���������: ");
                Files.ToysForSpecAge(_path + "toys.xml");
                Console.WriteLine("------------------------------------------------\n");

            }
            else if (answer == "6")
            {
                List<string> nums = new List<string>() { 
                    "1", "2", "da", "4", "5"
                };

                Console.WriteLine("������: ");
                foreach (string str in nums)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine("\n");

                Console.WriteLine("������� ������� ����� �������� �������� ������: ");
                string? element = Console.ReadLine();
                Lists.AddListAfterElem(nums, element);
                Console.WriteLine("�������������� ������: ");
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

                Console.WriteLine("������: ");
                foreach (string str in nums)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine("\n");

                Console.WriteLine("������� ������� ������� �������� � ������ � ����� ������: ");
                string? element = Console.ReadLine();
                Lists.AddFrontAndBack(nums, element);
                Console.WriteLine("�������������� ������: ");
                foreach (string str in nums)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine("\n");
            }
            else if (answer == "8")
            {
                string[] allBooks = new string[] { "�����1", "�����2", "�����3", "�����4", "�����5", "�����6" };
                //������ ������ � ����� ���������� �������� - � ������ �������� �������� ����, ������� �� ��������
                Hash.WhoHaveReadTheBook(
                    bookPath,
                    allBooks,
                    out var allHaveRead,
                    out var someHaveRead,
                    out var noneHaveRead);

                Console.WriteLine("��� ������: ");
                foreach (string str in allHaveRead)
                {
                    Console.Write(str + "; ");
                }
                Console.WriteLine("\n");

                Console.WriteLine("��������� ������: ");
                foreach (string str in someHaveRead)
                {
                    Console.Write(str + "; ");
                }
                Console.WriteLine("\n");

                Console.WriteLine("����� �� �����: ");
                foreach (string str in noneHaveRead)
                {
                    Console.Write(str + "; ");
                }
                Console.WriteLine("\n");
            }
            else if (answer == "9")
            {
                Console.WriteLine("������� ��� �����: ");
                HashSet<char> result = Hash.SymbolsFromAllWordsExceptFirst(_path + Console.ReadLine());
                Console.WriteLine("�������, ������� �������� ��� ������� ������: ");
                foreach(char letter in result)
                {
                    Console.Write(letter + " ");
                }
                Console.WriteLine("\n");
            }
            else if (answer == "10")
            {
                Console.WriteLine("��� ������� �� ����������.\n");
            }
            else if (answer == "11")
            {
                _working = false;
            }
            else
            {
                Console.WriteLine("�������� ����� ��������! �������� ��������.");
                choice();
            }
        }
    }
}