using System;
using System.Collections.Generic;

namespace BusinessManager
{
    public class Business : Purchase
    {
        private int _profit;
        private List<BusinessUpgrades> _posibleUpgrades = new List<BusinessUpgrades>();

        public Business(int profit, string nameOfBusiness, int cost) : base(cost, nameOfBusiness)
        {
            _profit = profit;
        }

        public void UpgradeBusiness(BusinessUpgrades upgrade)
        {
            _profit += upgrade.Cost;
        }

        public void AddToUpgradeList(params BusinessUpgrades[] upgrade)
        {
            for (var i = 0; i < _posibleUpgrades.Count; i++)
            {
                _posibleUpgrades.Add(upgrade[i]);
            }
        }
    }
}