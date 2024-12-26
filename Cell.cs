using System;

namespace OnlineStore
{
    internal struct Cell
    {
        public Good Good { get; private set; }
        public int Number { get; private set; }

        public Cell(Good good, int number)
        {
            Good = good;
            Number = number;
        }

        public Cell Merge(Good good, int number)
        {
            if (good == null)
                throw new InvalidOperationException($"{good.Name} is null");

            if (number < 0)
                throw new InvalidOperationException("Number is negative");

            return new Cell(good, Number + number);
        }

        public Cell DecreaceGoodNumber(Good good, int number)
        {
            if (Number < number)
                throw new InvalidOperationException("Good number is too small");

            return new Cell(good, Number - number);
        }
    }
}