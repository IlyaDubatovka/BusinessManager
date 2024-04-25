using System;
using System.Collections.Generic;

namespace BusinessManager
{
    public class Business : Purchase
    {
        private int _profit;
        private List<BusinessUpgrades> _possibleUpgrades = new List<BusinessUpgrades>();

        public Business(int profit, string nameOfBusiness, int cost) : base(cost, nameOfBusiness)
        {
            _profit = profit;
        }

        public void UpgradeBusiness(int index)
        {
            _profit += _possibleUpgrades[index].Cost;
            _possibleUpgrades.RemoveAt(index);
            Console.WriteLine("Улучшение успешно выполнено");
            Console.WriteLine();
        }

        public void ShowPossibleUpgrsdes()
        {
            for (var i = 0; i < _possibleUpgrades.Count; i++)
            {
                Console.WriteLine($"{i=1} - {_possibleUpgrades[i].NameOfPurchase}");
                //TODO не верно отображаются улучшения
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
    }
}