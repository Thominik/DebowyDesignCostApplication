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
        public abstract Statistics GetStatistics();

        public void AddMoney(string money)
        {
            if (float.TryParse(money, out float value))
                AddMoney(value);
            else
                throw new Exception("Wprowadzona kwota nie jest zmienną typu string.");
        }

        public void AddMoney(double money)
        {
            var doubleAsFloat = (float)money;
            AddMoney(doubleAsFloat);
        }

        public void AddMoney(int money)
        {
            var intAsFloat = (float)money;
            AddMoney(intAsFloat);
        }
    }
}
