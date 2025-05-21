using System;

namespace lab8
{
    /// <summary>
    /// Класс работы с каталогом продукции
    /// </summary>
    public class Catalog
    {
        private List<Product> catalog;
        private readonly string pathToDataBase;

        public Catalog(string path)
        {
            catalog = new List<Product>();
            pathToDataBase = path;
        }

        /// <summary>
        /// Метод для загрузки каталога из файла в список
        /// </summary>
        public void LoadFromDataBase(){
            try
            {
                using (BinaryReader dataBase = new BinaryReader(File.Open(pathToDataBase, FileMode.Open)))
                {
                    uint amount = dataBase.ReadUInt32();
                    for (int i = 0; i < amount; i++)
                    {
                        uint id = dataBase.ReadUInt32();
                        string name = dataBase.ReadString();
                        string maker = dataBase.ReadString();
                        decimal price = dataBase.ReadDecimal();
                        DateTime productionDay = DateTime.FromBinary(dataBase.ReadInt64());
                        bool availability = dataBase.ReadBoolean();

                        //Product item = new Product(id, name, maker, price, productionDay, availability);

                        //catalog.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message} \n");
            }
        }

        /// <summary>
        /// Метод для выгрузки списка
        /// </summary>
        public void SaveCatalog()
        {
            try
            {
                using (BinaryWriter dataBase = new BinaryWriter(File.Open(pathToDataBase, FileMode.Create)))
                {
                    dataBase.Write(catalog.Count);
                    foreach (Product item in catalog)
                    {
                        dataBase.Write(item.Id);
                        dataBase.Write(item.Name);
                        dataBase.Write(item.Maker);
                        dataBase.Write(item.Price);
                        dataBase.Write(item.ProductionDay.ToBinary());
                        dataBase.Write(item.Availability);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод, добавляющий продукт в список, а после сохранаяющий список в файл
        /// </summary>
        /// <param name="item">Объект, описывающий продукт</param>
        public void AddProduct(Product item)
        {
            if (!catalog.Any(position => position.Id == item.Id))
            {
                catalog.Add(item);
                Console.WriteLine("Позиция успешно добавлена.\n");
            }
            else
            {
                Console.WriteLine("В каталоге уже есть позиция с заданным id.\n");
            }
            SaveCatalog();
        }

        /// <summary>
        /// Метод, удаляющий из списка продукт по заданному идентификатору, а после сохраняющий список в файл
        /// </summary>
        /// <param name="id">Идентификатор продукта</param>
        public void DeleteProduct(uint id)
        {
            var itemDelete = catalog.FirstOrDefault(position => position.Id == id);
            if (itemDelete != null)
            {
                catalog.Remove(itemDelete);
                Console.WriteLine("Позиция успешно удалена.\n");
            }
            else
            {
                Console.WriteLine("Позиции с заданным id нет в базе.\n");
            }
            SaveCatalog();
        }

        /// <summary>
        /// Метод для просмотра содержимого католога
        /// </summary>
        public void LookCatalog()
        {
            if (catalog.Any())
            {
                foreach (Product item in catalog)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("В каталоге нет позиций.\n");
            }
        }

        /// <summary>
        /// Метод для нахождения списка из продукции в заданном диапазоне цен
        /// </summary>
        /// <param name="priceMin">Минимальное значение диапазона</param>
        /// <param name="priceMax">Максимальное значение диапазона</param>
        /// <returns>Список из объектов, находящихся в заданном ценовом диапазоне</returns>
        public List<Product> ItemsBetweenPrices(decimal priceMin, decimal priceMax)
        {
            List<Product> resultItems = catalog.FindAll(item => (item.Price >= priceMin && item.Price <= priceMax));
            return resultItems;
        }

        /// <summary>
        /// Метод для нахождения списка из продукции, схожей с заданным именем
        /// </summary>
        /// <param name="nameSort">Заданное пользователем имя для поиска схожих по имени позиций в каталоге</param>
        /// <returns>Список из объектов с одинаковым наименованием</returns>
        public List<Product> ItemsByName(string nameSort)
        {
            List<Product> resultItems = catalog.FindAll(item => item.Name == nameSort);
            return resultItems;
        }

        /// <summary>
        /// Метод для нахождения количества позиций, которые были выпущены в заданный год
        /// </summary>
        /// <param name="year">Год, заданный пользователем для поиска схожих позиций по дате выпуска в каталоге</param>
        /// <returns>Количество продукций по заданному году</returns>
        public int AmountOfItemsByYear(int year)
        {
            return catalog.Count(item => item.ProductionDay.Year == year);
        }

        /// <summary>
        /// Метод для нахождения количества позиций, которые были изданы одним производителем
        /// </summary>
        /// <param name="maker">Издатель, заданный пользователем для поиска количества выпущенных им позиций в каталоге</param>
        /// <returns>Количество продукций по заданному издателю</returns>
        public int AmountOfItemsByMaker(string maker)
        {
            return catalog.Count(item => item.Maker == maker);
        }
    }
}