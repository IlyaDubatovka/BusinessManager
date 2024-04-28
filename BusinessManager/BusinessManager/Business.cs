using System;
using System.Collections.Generic;

namespace BusinessManager
{
    public class Business : Purchase
    {
        private int _profit;
        private List<BusinessUpgrades> _possibleUpgrades = new List<BusinessUpgrades>();
        private int _timeRevenue;
        public int Profit
        {
            get => _profit;
        }
        public int TimeRevenue
        {
            get => _timeRevenue;
        }

        public List<BusinessUpgrades> PossibleUpgrades
        {
            get => _possibleUpgrades;
        }
        public Business(int profit, string nameOfBusiness, int cost) : base(cost, nameOfBusiness)
        {
            _profit = profit;
            _timeRevenue = 10;
        }

        public void UpgradeBusiness(int index)
        {
            _profit += _possibleUpgrades[index].Profit;
            _possibleUpgrades.RemoveAt(index);
            Console.WriteLine("Улучшение успешно выполнено!");
            Console.WriteLine();
        }

        public void ShowPossibleUpgrades()
        {
            for (var i = 0; i < _possibleUpgrades.Count; i++)
            {
                Console.Write(i+1+". ");
                _possibleUpgrades[i].ShowInfo();
           
            }

            Console.WriteLine();
        }

        public void AddToUpgradeList(params BusinessUpgrades[] upgrade)
        {
            for (var i = 0; i < upgrade.Length; i++)
            {
                _possibleUpgrades.Add(upgrade[i]);
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"{_nameOfPurchase} | стоимость {_cost}$ | приносит {_profit}$ каждые {_timeRevenue} секунд.");
        }
    }
}