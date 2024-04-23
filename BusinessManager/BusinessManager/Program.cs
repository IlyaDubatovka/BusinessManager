using System;

namespace BusinessManager
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new();
            gameManager.StartGame();
        }
    }
}