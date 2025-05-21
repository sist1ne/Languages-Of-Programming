using System;
using System.Collections.Generic;

namespace lab8  
{
    /// <summary>
    /// Класс, описывающий объект продукции
    /// </summary>
    public class Product
    {
        private uint _id;
        private string _name ;
        private string _maker;
        private decimal _price;
        private DateTime _productionDay;
        private bool _availability;

        
        public uint Id
        {
            get { return _id; }
            set 
            {
                if (value >= 0)
                    _id = value;
                else
                    _id = (uint)Math.Abs(_id);
            }
        }
        public string Name
        {
            get { return _name; }
            set 
            {
                if ((value != null) && (value != " "))
                    _name = value;
                else
                    _name = "Наименование";
            }
        }
        public string Maker
        {
            get { return _maker; }
            set 
            {
                if ((value != null) && (value != " "))
                    _maker = value;
                else
                    _maker = "Производитель";
            }
        }
        public decimal Price
        {
            get { return _price; }
            set 
            { 
                if (value >= 0)
                    _price = value;
                else
                    _price = 0;
            }
        }
        public DateTime ProductionDay
        {
            get { return _productionDay; }
            set 
            {
                DateTime earlyDate = DateTime.Parse("01.01.1947");
                if (DateTime.Compare(value, earlyDate) >= 0)
                    _productionDay = value;
                else
                    _productionDay = earlyDate;
            }
        }
        public bool Availability
        {
            get { return _availability; }
            set { _availability = value; }
        }
        

        /// <summary>
        /// Конструктор для объекта
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Наименование</param>
        /// <param name="maker">Производитель</param>
        /// <param name="price">Цена</param>
        /// <param name="productionDay">Дата производства</param>
        /// <param name="availability">В наличии ли позиция</param>
        public Product(uint id, string name, string maker, decimal price, string productionDay, bool availability)
        {
            Id = id;
            Name = name;
            Maker = maker;
            Price = price;

            DateTime temp;
            if (!DateTime.TryParse(productionDay, out temp))
            {
                ProductionDay = DateTime.Parse("01.01.1947");
            }
            else ProductionDay = temp;

            Availability = availability;
        }

        public override string ToString()
        {
            DateOnly date = DateOnly.FromDateTime(_productionDay);
            return $"ID: {_id}\nНаименование: {_name}\nПроизводитель: {_maker}\n" +
                $"Цена: {_price}\nДата производства: {date}\nВ наличии: {(_availability ? "Да" : "Нет")}\n";
        }
    }
}