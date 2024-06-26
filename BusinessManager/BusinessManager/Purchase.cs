using System;

namespace BusinessManager
{
    public abstract class Purchase
    {
        protected int _cost;
        protected string _nameOfPurchase;
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

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{_nameOfPurchase} | стоимость {_cost}");
        }
    }
}