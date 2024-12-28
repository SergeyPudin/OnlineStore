namespace OnlineStore
{
    internal interface IWarehouse
    {
        bool HaveInStock(Good askedGood, int quantity);
        void DeleteGood(Good good, int quantity);
    }
}