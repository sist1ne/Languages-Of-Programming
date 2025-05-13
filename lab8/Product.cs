using System;
using System.Collections.Generic;

namespace lab8  
{
    /// <summary>
    /// �����, ����������� ������ ���������
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
                    _name = "������������";
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
                    _maker = "�������������";
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
        /// ����������� ��� �������
        /// </summary>
        /// <param name="id">�������������</param>
        /// <param name="name">������������</param>
        /// <param name="maker">�������������</param>
        /// <param name="price">����</param>
        /// <param name="productionDay">���� ������������</param>
        /// <param name="availability">� ������� �� �������</param>
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
            return $"ID: {_id}\n������������: {_name}\n�������������: {_maker}\n" +
                $"����: {_price}\n���� ������������: {date}\n� �������: {(_availability ? "��" : "���")}\n";
        }
    }
}