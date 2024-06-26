using System;
using System.Collections.Generic;

namespace BusinessManager
{
    public class BusinessMan
    {
        private string _name;
        private int _wallet;
        public bool OnNotifications = false;
        private List<Business> _ownedBusinesses = new();

        public List<Business> OwnedBusiness
        {
            get => _ownedBusinesses;
        }

        public BusinessMan(string name, int money = 10000)
        {
            _name = name;
            _wallet += money;
        }

        public void Buy(Purchase newPurchase)
        {
            if (_wallet > newPurchase.Cost)
            {
                if (newPurchase is Business curentBusiness)
                {
                    _ownedBusinesses.Add((Business)newPurchase);
                    curentBusiness.StartWorking(this);
                }

                _wallet -= newPurchase.Cost;
                Console.WriteLine("У вас новое приобретение - " + newPurchase.NameOfPurchase);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Не хватает деньжат");
                Console.WriteLine();
            }
        }

        public void GetProfit(Business business)
        {
            _wallet += business.Profit;
            if (OnNotifications)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Вы заработали с помощью {business.NameOfPurchase} {business.Profit}$");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Предприниматель : {_name}, текущий счёт на карте {_wallet}");
            if (_ownedBusinesses.Count == 0)
            {
                Console.WriteLine("Ничего не куплено");
            }
            else
            {
                Console.WriteLine("Владеет предприятиями : ");
                for (var i = 0; i < _ownedBusinesses.Count; i++)
                {
                    Console.Write(
                        $"{_ownedBusinesses[i].NameOfPurchase} приносит {_ownedBusinesses[i].Profit}$ каждые {_ownedBusinesses[i].TimeRevenue} секунд");
                    if (i == _ownedBusinesses.Count - 1)
                    {
                        Console.WriteLine(".");
                    }
                    else
                    {
                        Console.WriteLine("; ");
                    }
                }
            }

            Console.WriteLine();
        }

        public void ShowOwnedBusiness()
        {
            for (var i = 0; i < _ownedBusinesses.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {_ownedBusinesses[i].NameOfPurchase}");
            }
        }
    }
}