namespace BusinessManager
{
    public class BusinessUpgrades: Purchase

    {
        private int _profit;
        public int Profit
        {
            get => _profit;
        }

        public BusinessUpgrades(int profit, string nameOfBusiness, int cost) : base(cost, nameOfBusiness)
        {
            _profit = profit;
        }
        
    }
}