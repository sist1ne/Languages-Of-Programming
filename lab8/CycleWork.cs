using System;
using System.Diagnostics.Metrics;

namespace lab8
{
    /// <summary>
    /// Класс для цикличной работы
    /// </summary>
    class CycleWork
    {
        private bool Working = true;

        /// <summary>
        /// Метод для цикличного запуска других методов
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
        /// Метод для выхода из программы
        /// </summary>
        public void Stop()
        {
            Console.WriteLine("Для выхода из программы напишите exit...");
            Console.WriteLine("==========================================================");
            string? answer = Console.ReadLine();
            if (answer == "exit")
            {
                Working = false;
            }
        }

        /// <summary>
        /// Метод для интерфейса 
        /// </summary>
        public void ObjectsSummon()
        {
            Console.Clear();
            Console.WriteLine(">>>>>>>> Каталог электроники <<<<<<<<");
            Console.WriteLine("1. Посмотреть каталог");
            Console.WriteLine("2. Добавить позицию в католог");
            Console.WriteLine("3. Удалить позицию в катологе по id");
            Console.WriteLine("4. Посмотреть позиции в ценовом диапазоне");
            Console.WriteLine("5. Посмотреть позиции по одному наименованию");
            Console.WriteLine("6. Количество позиций, выпущенных в указанный год");
            Console.WriteLine("7. Количество позиций от указанного производителя");

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
                uint id = GetUint.Check("Введите id: ");
                string name = GetStr.Check("Введите наименование: ");
                string maker = GetStr.Check("Введите производителя: ");
                decimal price = GetDecimal.Check("Введите стоимость: ");
                DateTime productionDay = GetDate.Check("Введите дату производства (дд/мм/год):");
                bool availability = GetBool.Check("Есть в наличии (Да/Нет):");

                //Product item = new Product(id, name, maker, price, productionDay, availability);
                //catalog.AddProduct(item);
            }
            else if (choice == "3")
            {
                uint id = GetUint.Check("Введите id удаляемой позиции: ");
                catalog.DeleteProduct(id);
            }
            else if (choice == "4")
            {
                decimal minPrice = GetDecimal.Check("Введите минимальный порог стоимости: ");
                decimal maxPrice = GetDecimal.Check("Введите максимальный порог стоимости: ");

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
                string name = GetStr.Check("Введите поисковое наименование: ");

                List<Product> result = catalog.ItemsByName(name);
                foreach (Product item in result)
                {
                    Console.WriteLine(item);
                }
            }
            else if (choice == "6")
            {
                int year = GetYear.Check("Введите поисковый год: ");
                int result = catalog.AmountOfItemsByYear(year);

                Console.WriteLine($"Количество позиций, выпущенных в {year}: {result}");
            }
            else if (choice == "7")
            {
                string maker = GetStr.Check("Введите поискового производителя: ");
                int result = catalog.AmountOfItemsByMaker(maker);

                Console.WriteLine($"Количество позиций от производителя {maker}: {result}");
            }
            else
            {
                Console.WriteLine("Неверный выбор действия.\nПовторите ввод.\n");
                ObjectsSummon();
            }

        }
    }
}
