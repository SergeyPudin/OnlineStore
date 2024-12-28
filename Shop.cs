using System;

namespace OnlineStore
{
    internal class Shop
    {
        private IWarehouse _warehouse;

        public Shop(IWarehouse warehouse)
        {
            _warehouse = warehouse ?? throw new ArgumentNullException($"{nameof(warehouse)} is null"); 
        }

        public Cart Cart()
        {
            if (_warehouse == null)
                throw new ArgumentNullException($"{nameof(_warehouse)} is null");

            return new Cart(_warehouse);
        }
    }
}