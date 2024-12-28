using System;

namespace OnlineStore
{
    internal class Shop
    {
        private Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException($"{nameof(warehouse)} is null");

            _warehouse = warehouse;
        }

        public Cart Cart()
        {
            if (_warehouse == null)
                throw new ArgumentNullException($"{nameof(_warehouse)} is null");

            return new Cart(_warehouse);
        }
    }
}