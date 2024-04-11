using System;
using System.Collections.Generic;

namespace BusinessManager
{
    public class Business : Purchase
    {
        private int _profit;
private List<>

        public Business(int profit, string nameOfBusiness, int cost) : base(cost, nameOfBusiness)
        {
            _profit = profit;
        }
    }
}