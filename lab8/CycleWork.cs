using System;
using System.Diagnostics.Metrics;

namespace lab8
{
    /// <summary>
    /// ����� ��� ��������� ������
    /// </summary>
    class CycleWork
    {
        private bool Working = true;

        /// <summary>
        /// ����� ��� ���������� ������� ������ �������
        /// </summary>
        public void Start()
        {
            do
            {
                ObjectsSummon();
                Stop();
            } while (Working);
        }

        /// <summary>
        /// ����� ��� ������ �� ���������
        /// </summary>
        public void Stop()
        {
            Console.WriteLine("��� ������ �� ��������� �������� exit...");
            Console.WriteLine("==========================================================");
            string? answer = Console.ReadLine();
            if (answer == "exit")
            {
                Working = false;
            }
        }

        /// <summary>
        /// ����� ��� ���������� 
        /// </summary>
        public void ObjectsSummon()
        {
            Console.Clear();
            Console.WriteLine(">>>>>>>> ������� ����������� <<<<<<<<");
            Console.WriteLine("1. ���������� �������");
            Console.WriteLine("2. �������� ������� � �������");
            Console.WriteLine("3. ������� ������� � �������� �� id");
            Console.WriteLine("4. ���������� ������� � ������� ���������");
            Console.WriteLine("5. ���������� ������� �� ������ ������������");
            Console.WriteLine("6. ���������� �������, ���������� � ��������� ���");
            Console.WriteLine("7. ���������� ������� �� ���������� �������������");

            Catalog catalog = new Catalog("database.bin");
            catalog.LoadFromDataBase();

            string? choice = Console.ReadLine();
            Console.WriteLine();
            if (choice == "1")
            {
                catalog.LookCatalog();
            }
            else if (choice == "2")
            {
                uint id = GetUint.Check("������� id: ");
                string name = GetStr.Check("������� ������������: ");
                string maker = GetStr.Check("������� �������������: ");
                decimal price = GetDecimal.Check("������� ���������: ");
                DateTime productionDay = GetDate.Check("������� ���� ������������ (��/��/���):");
                bool availability = GetBool.Check("���� � ������� (��/���):");

                //Product item = new Product(id, name, maker, price, productionDay, availability);
                //catalog.AddProduct(item);
            }
            else if (choice == "3")
            {
                uint id = GetUint.Check("������� id ��������� �������: ");
                catalog.DeleteProduct(id);
            }
            else if (choice == "4")
            {
                decimal minPrice = GetDecimal.Check("������� ����������� ����� ���������: ");
                decimal maxPrice = GetDecimal.Check("������� ������������ ����� ���������: ");

                List<Product> result;
                if (minPrice < maxPrice)
                {
                    result = catalog.ItemsBetweenPrices(minPrice, maxPrice);
                }
                else
                {
                    result = catalog.ItemsBetweenPrices(maxPrice, minPrice);
                }

                foreach (Product item in result)
                {
                    Console.WriteLine(item);
                }
            }
            else if (choice == "5")
            {
                string name = GetStr.Check("������� ��������� ������������: ");

                List<Product> result = catalog.ItemsByName(name);
                foreach (Product item in result)
                {
                    Console.WriteLine(item);
                }
            }
            else if (choice == "6")
            {
                int year = GetYear.Check("������� ��������� ���: ");
                int result = catalog.AmountOfItemsByYear(year);

                Console.WriteLine($"���������� �������, ���������� � {year}: {result}");
            }
            else if (choice == "7")
            {
                string maker = GetStr.Check("������� ���������� �������������: ");
                int result = catalog.AmountOfItemsByMaker(maker);

                Console.WriteLine($"���������� ������� �� ������������� {maker}: {result}");
            }
            else
            {
                Console.WriteLine("�������� ����� ��������.\n��������� ����.\n");
                ObjectsSummon();
            }

        }
    }
}
