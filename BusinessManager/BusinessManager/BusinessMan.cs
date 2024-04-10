using System;
using System.Collections.Generic;

namespace BusinessManager
{
    public class BusinessMan
    {
        private string _name;
        private int _wallet;

        private List<Business> _ownedBusinesses=new ();

        public BusinessMan(string name, int money=10000)
        {
            _name = name;
            AddMoney(money);
        }

        public void OwnNewBusiness(Business newBusiness)
        {
            _ownedBusinesses.Add(newBusiness);
        }

        public void AddMoney(int money)
        {
            _wallet += money;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Предприниматель - {_name} \t текущий счёт на карте {_wallet}");
            if (_ownedBusinesses.Count==0)
            {
                Console.WriteLine("Ничего не куплено");
            }
            else
            {
                Console.WriteLine("Владеет предприятиями - ");
                for (var i = 0; i < _ownedBusinesses.Count; i++)
                {
                    
                }
            }
            
            
        }
    }
}