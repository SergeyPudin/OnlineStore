using System;
using System.Collections.Generic;

namespace OnlineStore
{
    internal class Warehouse : IWarehouse
    {
        private readonly List<Cell> _goods;

        public Warehouse()
        {
            _goods = new List<Cell>();
        }

        public void Delive(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException($"{good} is null");

            if (quantity < 0)
                throw new InvalidOperationException($"{quantity} is negative");

            int cellIndex = _goods.FindIndex(cell => cell.Good == good);

            if (cellIndex == -1)
                _goods.Add(new Cell(good, quantity));
            else
                _goods[cellIndex].Merge(good, quantity);
        }

        public void ShowGoods()
        {
            if (_goods == null)
                throw new ArgumentNullException($"{_goods} is null");

            if (_goods.Count == 0)
                throw new ArgumentOutOfRangeException($"{_goods} is not filled");

            Console.WriteLine("На складе: ");

            foreach (Cell cell in _goods)
            {
                Console.WriteLine($"{cell.Good.Name} - {cell.Quantity}");
            }

            Console.WriteLine();
        }

        public bool HaveInStock(Good askedGood, int quantity)
        {
            if (askedGood == null)
                throw new ArgumentNullException($"{askedGood} is null");

            if (quantity < 0)
                throw new ArgumentOutOfRangeException("Quantity is negative");

            bool isStocked = false;
            int cellIndex = _goods.FindIndex(cell => cell.Good == askedGood);

            if (cellIndex != -1 && _goods[cellIndex].Quantity >= quantity)
                return true;

            return isStocked;
        }

        public void DeleteGood(Good good, int quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException("Quantity is negative");

            int cellIndex = _goods.FindIndex(cell => cell.Good == good);

            if (cellIndex == -1)
                throw new ArgumentOutOfRangeException("There is no good");

            if (_goods[cellIndex].Quantity >= quantity)
                _goods[cellIndex] = _goods[cellIndex].DecreaceGoodNumber(good, quantity);
            else
                throw new ArgumentOutOfRangeException("Quantity is too big");

            if (_goods[cellIndex].Quantity == 0)
                _goods.Remove(_goods[cellIndex]);
        }
    }
}