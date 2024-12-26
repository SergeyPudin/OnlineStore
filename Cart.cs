using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore
{
    internal class Cart
    {
        private readonly List<Cell> _goods;
        private Warehouse _warehouse;

        public Cart(Warehouse warehouse)
        {
            _goods = new List<Cell>();
            _warehouse = warehouse;
        }

        public void Add(Good good, int number)
        {
            if (good == null)
                throw new InvalidOperationException($"{good} is null");

            if (number < 0)
                throw new InvalidOperationException("Number is negative");

            if (_warehouse.IsStock(good, number))
                AddCell(good, number);
            else
                throw new InvalidOperationException($"There is no asked number of {good.Name}");
        }

        public void ShowGoods()
        {
            if (_goods == null)
                throw new InvalidOperationException($"{_goods} is null");

            if (_goods.Count < 0)
                throw new InvalidOperationException($"{_goods} number is negative");

            Console.WriteLine("В корзине: ");

            foreach (Cell cell in _goods)
            {
                Console.WriteLine($"{cell.Good.Name} - {cell.Number}");
            }

            Console.WriteLine();
        }

        public Order Order()
        {
            return new Order();
        }

        private void AddCell(Good good, int number)
        {
            Cell currentCell = _goods.FirstOrDefault(cell => cell.Good == good);

            if (_goods.Contains(currentCell))
                currentCell.Merge(good, number);
            else
                _goods.Add(new Cell(good, number));

            _warehouse.DeleteGood(good, number);
        }
    }
}