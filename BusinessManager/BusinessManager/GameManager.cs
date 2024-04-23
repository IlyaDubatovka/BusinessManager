using System;

namespace BusinessManager
{
    public class GameManager
    {
        private BusinessPool _businessPool;
        private BusinessMan _businessMan;

        public GameManager()
        {
            _businessPool = new();
            Console.WriteLine("Вы предприниматель и вас зовут");
            _businessMan = new BusinessMan(Console.ReadLine());
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
                Console.WriteLine();
                var inputStr = Console.ReadLine();
                if (!int.TryParse(inputStr,out int input))
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
                        ShowUpgrades();
                        break;
                    case 3:
                        ShowFreeBusineses();
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

        public void ShowUpgrades()
        {
            Console.WriteLine("Выберите улучшаемый бизнес");
            _businessMan.ShowOwnedBusiness();
            //TODO сделать выбор бизнеса и апгрейд
        }

        public void ShowFreeBusineses()
        {
            _businessPool.ShowBusinessPool();
            Console.WriteLine("Купили новый бизнес");
        }
    }
}