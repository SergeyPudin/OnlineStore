using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore
{
    internal class Cart
    {
        private readonly List<Cell> _goods;
        private readonly IWarehouse _warehouse;

        public Cart(IWarehouse warehouse)
        {
            _goods = new List<Cell>();
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse)); 
        }

        public void Add(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException($"{good} is null");

            if (quantity < 0)
                throw new ArgumentOutOfRangeException("Quantity is negative");

                Cell currentCell = _goods.FirstOrDefault(cell => cell.Good == good);

            if (_warehouse.HaveInStock(good, quantity + currentCell.Quantity))
            {
                if (_goods.Contains(currentCell))
                {
                    currentCell.Merge(good, quantity);
                }
                else
                {
                    _goods.Add(new Cell(good, quantity));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException($"There is no asked quantity of {good.Name}");
            }
        }

        public void ShowGoods()
        {
            if (_goods == null)
                throw new ArgumentNullException($"{_goods} is null");

            if (_goods.Count < 0)
                throw new ArgumentOutOfRangeException($"{_goods} quantity is negative");

            Console.WriteLine("В корзине: ");

            foreach (Cell cell in _goods)
            {
                Console.WriteLine($"{cell.Good.Name} - {cell.Quantity}");
            }

            Console.WriteLine();
        }

        public Order Order()
        {
            foreach (Cell cell in _goods)
            {
                if (_warehouse.HaveInStock(cell.Good, cell.Quantity) == false)
                    throw new ArgumentOutOfRangeException("Not enough goods");
            }

            foreach (Cell cell in _goods)
            {
                _warehouse.DeleteGood(cell.Good, cell.Quantity);
            }

            _goods.Clear();

            return new Order();
        }
    }
}