using System;

namespace OnlineStore
{
    internal struct Cell
    {
        public Cell(Good good, int quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException("Quantity is negative");

            Good = good ?? throw new ArgumentNullException(nameof(good));
            Quantity = quantity;
        }

        public Good Good { get; private set; }
        public int Quantity { get; private set; }

        public Cell Merge(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException($"{good.Name} is null");

            if (quantity < 0)
                throw new ArgumentOutOfRangeException("Quantity is negative");

            return new Cell(good, Quantity + quantity);
        }

        public Cell DecreaceGoodNumber(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException($"{nameof(good)} is null");

            if (Quantity < quantity)
                throw new ArgumentOutOfRangeException("Good quantity is too small");

            return new Cell(good, Quantity - quantity);
        }
    }
}