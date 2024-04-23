using System;

namespace BusinessManager
{
    public class GameManager
    {
        public void StartGame()
        {
            InputController inputController = new();
            BusinessPool businessPool = new();
            Console.WriteLine("Вы предприниматель и вас зовут");
            BusinessMan businessMan = new BusinessMan(Console.ReadLine());
            ShowStartMenu();
            Console.WriteLine("Игра завершена");
        }

        public void ShowStartMenu()
        {
            Console.WriteLine("1 - Улучшить бизнес");
            Console.WriteLine("2 - Приобрести новый бизнес");
            Console.WriteLine("3 - Выйти из игры");
            Console.Write("Сделайте ваш выбор : ");
            int input = Console.Read();
            switch (Convert.ToInt32(((char)input).ToString()))
            {
                case 1:
                    ShowUpgrades();
                    break;
                case 2:
                    ShowFreeBusineses();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Вы сделали неверный выбор");
                    break;
            }
        }

        public void ShowUpgrades()
        {
            Console.WriteLine("Улучшили бизнес");
        }

        public void ShowFreeBusineses()
        {
            Console.WriteLine("Купили новый бизнес");
        }
    }
}