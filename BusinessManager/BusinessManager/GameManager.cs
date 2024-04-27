using System;
using System.Runtime.CompilerServices;

namespace BusinessManager
{
    public class GameManager
    {
        private BusinessPool _businessPool;
        private BusinessMan _businessMan;

        public GameManager()
        {
            _businessPool = new();
            Console.Write("Вы предприниматель и вас зовут ");
            _businessMan = new BusinessMan(Console.ReadLine());
            Console.WriteLine();
        }

        public void StartGame()
        {
            ShowStartMenu();
        }

        public void ShowStartMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("1 - Посмотреть информацию о себе");
                Console.WriteLine("2 - Улучшить бизнес");
                Console.WriteLine("3 - Приобрести новый бизнес");
                Console.WriteLine("4 - Выйти из игры");
                Console.WriteLine();
                Console.Write("Сделайте ваш выбор : ");
                var inputStr = Console.ReadLine();
                Console.WriteLine();
                if (!int.TryParse(inputStr, out int input))
                {
                    Console.WriteLine("Вы ввели некорректное значение, выберите число от 1 до 4");
                    continue;
                }

                switch (input)
                {
                    case 1:
                        _businessMan.ShowInfo();
                        break;
                    case 2:
                        ShowUpgradesMenu();
                        break;
                    case 3:
                        ShowBusinessPurchaseMenu();
                        break;
                    case 4:
                        Console.WriteLine("Игра завершена");
                        running = false;
                        return;
                    default:
                        Console.WriteLine("Вы сделали неверный выбор");
                        break;
                }
            }
        }

        public void ShowUpgradesMenu()
        {
            if (_businessMan.OwnedBusiness.Count==0)
            {
                Console.WriteLine("Вы ещё ничего не приобрели. Купите сначала какой-то бизнес");
                Console.WriteLine();
            }
            else
            {
                _businessMan.ShowOwnedBusiness();
                Console.Write("Выберите улучшаемый бизнес ");
                int inputBusinessIndex = int.Parse(Console.ReadLine());
                _businessMan.OwnedBusiness[inputBusinessIndex-1].ShowPossibleUpgrades();
                Console.Write("Что именно вы хотите улучшить? ");
                int inputUpgradeIndex = int.Parse(Console.ReadLine());
                _businessMan.OwnedBusiness[inputBusinessIndex-1].UpgradeBusiness(inputUpgradeIndex-1);
            }
        }

        public void ShowBusinessPurchaseMenu()
        {
            Console.WriteLine("Вы можете купить");
            _businessPool.ShowBusinessPool();
            Console.Write("Вас что-то заинтересовало?\t");
            var input = int.Parse(Console.ReadLine());
            _businessMan.Buy(_businessPool.BusinessesPool[input - 1]);
            _businessPool.RemoveBusinessFromPool(input - 1);
        }
        //TODO выполнить проверку на валидность вводимых данных
    }
}