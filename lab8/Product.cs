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
                if (value != null)
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
                if (value != null)
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
            set { _productionDay = value; }
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
        public Product(uint id, string name, string maker, decimal price, DateTime productionDay, bool availability)
        {
            _id = id;
            _name = name;
            _maker = maker;
            _price = price;
            _productionDay = productionDay;
            _availability = availability;
        }

        public override string ToString()
        {
            DateOnly date = DateOnly.FromDateTime(_productionDay);
            return $"ID: {_id}\nНаименование: {_name}\nПроизводитель: {_maker}\n" +
                $"Цена: {_price}\nДата производства: {date}\nВ наличии: {(_availability ? "Да" : "Нет")}\n";
        }
    }
}