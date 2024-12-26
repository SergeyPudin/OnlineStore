using System;
using System.Collections.Generic;

namespace OnlineStore
{
    internal class Warehouse
    {
        private readonly List<Cell> _goods;

        public Warehouse()
        {
            _goods = new List<Cell>();
        }

        public void Delive(Good good, int number)
        {
            int cellIndex = _goods.FindIndex(cell => cell.Good == good);

            if (good == null)
                throw new InvalidOperationException($"{good} is null");

            if (number < 0)
                throw new InvalidOperationException($"{number} is negative");

            if (cellIndex == -1)
                _goods.Add(new Cell(good, number));
            else
                _goods[cellIndex].Merge(good, number);
        }

        public void ShowGoods()
        {
            if (_goods == null)
                throw new InvalidOperationException($"{_goods} is null");

            if (_goods.Count == 0)
                throw new InvalidOperationException($"{_goods} is not filled");

            Console.WriteLine("На складе: ");

            foreach (Cell cell in _goods)
            {
                Console.WriteLine($"{cell.Good.Name} - {cell.Number}");
            }

            Console.WriteLine();
        }

        public bool IsStock(Good askedGood, int number)
        {
            bool isStocked = false;
            int cellIndex = _goods.FindIndex(cell => cell.Good == askedGood);

            if (askedGood == null)
                throw new InvalidOperationException($"{askedGood} is null");

            if (number < 0)
                throw new InvalidOperationException("Number is negative");

            if (cellIndex != -1 && _goods[cellIndex].Number >= number)
                return true;

            return isStocked;
        }

        public void DeleteGood(Good good, int number)
        {
            int cellIndex = _goods.FindIndex(cell => cell.Good == good);

            if (number < 0)
                throw new InvalidOperationException("Number is negative");

            if (cellIndex == -1)
                throw new InvalidOperationException("There is no good");

            if (_goods[cellIndex].Number >= number)
                _goods[cellIndex] = _goods[cellIndex].DecreaceGoodNumber(good, number);
            else
                throw new InvalidOperationException("Number is too big");

            if (_goods[cellIndex].Number == 0)
                _goods.Remove(_goods[cellIndex]);
        }
    }
}