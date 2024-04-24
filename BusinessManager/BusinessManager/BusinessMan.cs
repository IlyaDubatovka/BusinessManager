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

        public void Buy(Purchase newPurchase)
        {
            if (_wallet>newPurchase.Cost)
            {
                if (newPurchase is Business)
                {
                    _ownedBusinesses.Add((Business)newPurchase);
                }
                else
                {
                    //блок с вызовом улучшения бизнеса
                }
                Console.WriteLine("У вас новое приобретение - "+newPurchase.NameOfPurchase);
                Console.WriteLine();
                //TODO сделать списание средств
            }
            else
            {
                Console.WriteLine("Не хватает деньжат");
                Console.WriteLine();
            }

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
                    Console.Write(_ownedBusinesses[i].NameOfPurchase);
                    if (i==_ownedBusinesses.Count-1)
                    {
                        Console.Write(" .");
                    }
                    else
                    {
                        Console.Write(" ,");
                    }
                }
            }
            
            
        }

        public void ShowOwnedBusiness()
        {
            for (var i = 0; i < _ownedBusinesses.Count; i++)
            {
                Console.WriteLine($"{i+1} - {_ownedBusinesses[i].NameOfPurchase}");
            }
        }
    }
}