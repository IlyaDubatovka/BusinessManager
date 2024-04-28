using System;
using System.Collections.Generic;

namespace BusinessManager
{
    public class BusinessPool
    {
        private List<Business> _businessPool = new List<Business>();
        public List<Business> BusinessesPool { get=>_businessPool; }

        public BusinessPool()
        {
            CreateBusinessPool();
        }

        private void CreateBusinessPool()
        {
            Business business1 = new Business(200, "Блинная", 1000);
            BusinessUpgrades businessUpgrades1 = new BusinessUpgrades(20, "Дополнительные столики", 70);
            BusinessUpgrades businessUpgrades2 = new BusinessUpgrades(35, "Расширение штата", 100);
            BusinessUpgrades businessUpgrades3 = new BusinessUpgrades(15, "Качественные продукты", 90);
            business1.AddToUpgradeList(businessUpgrades1, businessUpgrades2, businessUpgrades3);

            Business business2 = new Business(500, "Заправка", 3000);
            BusinessUpgrades businessUpgrades4 = new BusinessUpgrades(200, "Установка зарядного для электрокаров", 700);
            BusinessUpgrades businessUpgrades5 = new BusinessUpgrades(100, "Установка касс самообслуживания", 300);
            BusinessUpgrades businessUpgrades6 = new BusinessUpgrades(70, "Расширенный асортимент товаров", 150);
            business2.AddToUpgradeList(businessUpgrades4, businessUpgrades5, businessUpgrades6);

            Business business3 = new Business(700, "Крокодиловая ферма", 4500);
            BusinessUpgrades businessUpgrades7 = new BusinessUpgrades(180, "Улучшенная водоочистная система", 750);
            BusinessUpgrades businessUpgrades8 = new BusinessUpgrades(130, "Nofrost холодильные камеры", 550);
            BusinessUpgrades businessUpgrades9 = new BusinessUpgrades(150, "Инкубаторы ускоренного развития", 590);
            business3.AddToUpgradeList(businessUpgrades7, businessUpgrades8, businessUpgrades9);

            Business business4 = new Business(550, "Швейная мастерская", 2500);
            BusinessUpgrades businessUpgrades10 = new BusinessUpgrades(100, "Отдел дизайнеров одежды", 450);
            BusinessUpgrades businessUpgrades11 = new BusinessUpgrades(150, "Улучшенные швейные машины", 300);
            BusinessUpgrades businessUpgrades12 = new BusinessUpgrades(80, "Расширенный асортимент тканей", 100);
            business4.AddToUpgradeList(businessUpgrades10, businessUpgrades11, businessUpgrades12);
            _businessPool.Add(business1);
            _businessPool.Add(business2);
            _businessPool.Add(business3);
            _businessPool.Add(business4);
        }

        public void RemoveBusinessFromPool(int index)
        {
            _businessPool.RemoveAt(index);
        }

        public void ShowBusinessPool()
        {
            for (var i = 0; i < _businessPool.Count; i++)
            {
                Console.Write($"{i + 1} - ");
                _businessPool[i].ShowInfo();
            }
        }
    }
}