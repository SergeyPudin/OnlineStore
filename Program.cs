using System;

namespace OnlineStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);

            warehouse.Delive(iPhone12, 10);
            warehouse.Delive(iPhone11, 1);

            warehouse.ShowGoods();

            Cart cart = shop.Cart();

            cart.Add(iPhone12, 4);
            cart.Add(iPhone11, 3);

            cart.ShowGoods();

            Console.WriteLine(cart.Order().Paylink);

            cart.Add(iPhone12, 9);

            Console.ReadKey();
        }
    }
}