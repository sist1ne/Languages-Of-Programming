using System;

namespace lab8
{
    /// <summary>
    ///  ласс работы с каталогом продукции
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

                        Product item = new Product(id, name, maker, price, productionDay, availability);

                        catalog.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ќшибка: {ex.Message} \n");
            }
        }

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
                Console.WriteLine($"ќшибка: {ex.Message}");
            }
        }

        public void AddProduct(Product item)
        {
            if (!catalog.Any(position => position.Id == item.Id))
            {
                catalog.Add(item);
                Console.WriteLine("ѕозици€ успешно добавлена.\n");
            }
            else
            {
                Console.WriteLine("¬ каталоге уже есть позици€ с заданным id.\n");
            }
            SaveCatalog();
        }

        public void DeleteProduct(uint id)
        {
            var itemDelete = catalog.FirstOrDefault(position => position.Id == id);
            if (itemDelete != null)
            {
                catalog.Remove(itemDelete);
                Console.WriteLine("ѕозици€ успешно удалена.\n");
            }
            else
            {
                Console.WriteLine("ѕозиции с заданным id нет в базе.\n");
            }
            SaveCatalog();
        }

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
                Console.WriteLine("¬ каталоге нет позиций.\n");
            }
        }

        /// <summary>
        /// ћетод дл€ нахождени€ списка из продукции в заданном диапазоне цен
        /// </summary>
        /// <param name="priceMin">ћинимальное значение диапазона</param>
        /// <param name="priceMax">ћаксимальное значение диапазона</param>
        public List<Product> ItemsBetweenPrices(decimal priceMin, decimal priceMax)
        {
            List<Product> resultItems = catalog.FindAll(item => (item.Price >= priceMin && item.Price <= priceMax));
            return resultItems;
        }

        /// <summary>
        /// ћетод дл€ нахождени€ списка из продукции, схожей с заданным именем
        /// </summary>
        /// <param name="nameSort">«аданное пользователем им€ дл€ поиска схожих по имени позиций в каталоге</param>
        public List<Product> ItemsByName(string nameSort)
        {
            List<Product> resultItems = catalog.FindAll(item => item.Name == nameSort);
            return resultItems;
        }

        /// <summary>
        /// ћетод дл€ нахождени€ количества позиций, которые были выпущены в заданный год
        /// </summary>
        /// <param name="year">√од, заданный пользователем дл€ поиска схожих позиций по дате выпуска в каталоге</param>
        public int AmountOfItemsByYear(int year)
        {
            return catalog.Count(item => item.ProductionDay.Year == year);
        }

        /// <summary>
        /// ћетод дл€ нахождени€ количества позиций, которые были изданы одним производителем
        /// </summary>
        /// <param name="maker">»здатель, заданный пользователем дл€ поиска количества выпущенных им позиций в каталоге</param>
        public int AmountOfItemsByMaker(string maker)
        {
            return catalog.Count(item => item.Maker == maker);
        }
    }
}