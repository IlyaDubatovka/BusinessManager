using System;
using System.Collections.Generic;
using System.Timers;

namespace BusinessManager
{
    public class Business : Purchase
    {
        private int _profit;
        private List<BusinessUpgrades> _possibleUpgrades = new List<BusinessUpgrades>();
        private int _timeRevenue;
        private BusinessMan _owner;
        private Timer _timer;
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
            _timer = new Timer(_timeRevenue*1000);
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

        public void StartWorking(BusinessMan owner)
        {
            _owner = owner;
            _timer.Start();
            _timer.Elapsed += MakeProfit;
        }

        private void MakeProfit(object sender, ElapsedEventArgs e)
        {
            _owner.GetProfit(this);
        }

    }
}