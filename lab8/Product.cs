using System;
using System.Collections.Generic;

namespace lab8  
{
    public class Product
    {
        private uint _id;
        private string _name;
        private string _maker;
        private decimal _price;
        private DateTime _productionDay;
        private bool _availability;

        internal uint Id => _id;
        internal string Name => _name;
        internal string Maker => _maker;
        internal decimal Price => _price;
        internal DateTime ProductionDay => _productionDay;
        internal bool Availability => _availability;

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