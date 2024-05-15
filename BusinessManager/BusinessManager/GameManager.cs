using System;
using System.Collections.Generic;

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
                if (_businessMan.OnNotifications)
                {
                    Console.WriteLine("4 - Выключить оповещения доходов");
                }
                else
                {
                    Console.WriteLine("4 - Включить оповещения доходов");
                }
                Console.WriteLine("5 - Выйти из игры");
                Console.WriteLine();
                Console.Write("Сделайте ваш выбор : ");
                var inputStr = Console.ReadLine();
                Console.WriteLine();
                if (!int.TryParse(inputStr, out int input))
                {
                    Console.WriteLine("Вы ввели некорректное значение, выберите число от 1 до 5");
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
                        if (_businessMan.OnNotifications)
                        {
                            _businessMan.OnNotifications = false;
                            Console.WriteLine("Оповещения выключены");
                            Console.WriteLine();
                        }
                        else
                        {
                            _businessMan.OnNotifications = true;
                            Console.WriteLine("Оповещения включены");
                            Console.WriteLine();
                        }
                        break;
                    case 5:
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
            if (_businessMan.OwnedBusiness.Count == 0)
            {
                Console.WriteLine("Вы ещё ничего не приобрели. Купите сначала какой-то бизнес.");
                Console.WriteLine();
            }
            else
            {
                _businessMan.ShowOwnedBusiness();
                Console.WriteLine($"{_businessMan.OwnedBusiness.Count+1} - Назад.");
                Console.WriteLine();
                Console.Write("Выберите улучшаемый бизнес ");
                int inputBusinessIndex = Input(_businessMan.OwnedBusiness);
                if (inputBusinessIndex==_businessMan.OwnedBusiness.Count+1)
                {
                    return;
                }

                Business currentBusiness = _businessMan.OwnedBusiness[inputBusinessIndex - 1];
                currentBusiness.ShowPossibleUpgrades();
                Console.WriteLine($"{currentBusiness.PossibleUpgrades.Count+1} - Назад.");
                Console.WriteLine();
                if (currentBusiness.PossibleUpgrades.Count == 0)
                {
                    Console.WriteLine("Все улучшения уже выполнены!");
                    Console.WriteLine();
                    return;
                }

                Console.Write("Что именно вы хотите улучшить? ");
                int inputUpgradeIndex = Input(currentBusiness.PossibleUpgrades);
                if (inputUpgradeIndex==currentBusiness.PossibleUpgrades.Count+1)
                {
                    return;
                }
                _businessMan.OwnedBusiness[inputBusinessIndex - 1].UpgradeBusiness(inputUpgradeIndex - 1);
            }
        }

        public void ShowBusinessPurchaseMenu()
        {
            if (_businessPool.BusinessesPool.Count == 0)
            {
                Console.WriteLine("Вы уже всё приобрели!");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Вы можете купить");
            _businessPool.ShowBusinessPool();
            Console.WriteLine($"{_businessPool.BusinessesPool.Count + 1} - Назад.");
            Console.WriteLine();
            Console.Write("Вас что-то заинтересовало?\t");
            int input = Input(_businessPool.BusinessesPool);
            Console.WriteLine();
            if (input == _businessPool.BusinessesPool.Count + 1)
            {
                return;
            }

            _businessMan.Buy(_businessPool.BusinessesPool[input - 1]);
            _businessPool.RemoveBusinessFromPool(input - 1);
        }

        private int Input<T>(List<T> list) where T : Purchase
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result > list.Count + 1 || result < 0)
                {
                    Console.WriteLine("Введено не корректное значение");
                    return Input(list);
                }

                return result;
            }

            Console.WriteLine("В качестве вводимых значений принимаются только цифры!");
            return Input(list);
        }
    }
}