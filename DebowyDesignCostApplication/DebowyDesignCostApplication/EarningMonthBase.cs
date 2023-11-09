namespace DebowyDesignCostApplication
{
    public abstract class EarningMonthBase : IEarningMonth
    {
        public delegate void MoneyAddedDelegate(object sender, EventArgs args);

        public abstract event MoneyAddedDelegate MoneyAdded;

        public EarningMonthBase(string month)
        {
            Month = month;
        }

        public string Month { get; private set; }

        public abstract void AddMoney(float money);
        public abstract void AddMoney(double money);
        public abstract void AddMoney(int money);
        public abstract void AddMoney(string money);
        public abstract Statistics GetStatistics();
    }
}
