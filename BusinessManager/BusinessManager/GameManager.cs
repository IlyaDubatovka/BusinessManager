using System;

namespace BusinessManager
{
    public class GameManager
    {
        public void StartGame()
        {
            InputController inputController = new();
            Console.WriteLine("Вы предприниматель и вас зовут" );
            BusinessMan businessMan = new BusinessMan(Console.ReadLine());
        }
    }
}