using System;

namespace BusinessManager
{
    public abstract class Purchase
    {
        private int _cost;
        private string _nameOfPurchase;
        public int Cost
        {
            get => _cost;
        }
        public string NameOfPurchase
        {
            get => _nameOfPurchase;
        }

        public Purchase(int cost, string nameOfPurchase)
        {
            _cost = cost;
            _nameOfPurchase = nameOfPurchase;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"\t{_nameOfPurchase}  - стоимость {_cost}");
        }
    }
}