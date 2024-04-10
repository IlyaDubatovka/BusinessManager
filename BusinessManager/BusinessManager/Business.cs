using System;

namespace BusinessManager
{
    public class Business
    {
        private int _profit;
        private string _typeOfBusiness;

        public  Business(int profit, string typeOfBusiness)
        {
            _profit = profit;
            _typeOfBusiness = typeOfBusiness;
        }

        public void PrintBusinessInfo()
        {
            Console.WriteLine($"Название бизнеса - {_typeOfBusiness} прибыль - {_profit}");
        }
    }
}