namespace DebowyDesignCostApplication
{
    public class EarningMonthInMemory : EarningMonthBase
    {
        private List<float> payment = new List<float>();

        public override event MoneyAddedDelegate MoneyAdded;

        public EarningMonthInMemory(string month) : base(month)
        {
        }

        public override void AddMoney(float money)
        {
            if (money > 0)
            {
                payment.Add(money); ;

                if (MoneyAdded != null)
                {
                    MoneyAdded(this, new EventArgs());
                }
            }
            else
                throw new Exception("Incorrect deposit amount.");
        }

        public override void AddMoney(double money)
        {
            var doubleAsFloat = (float)money;
            AddMoney(doubleAsFloat);
        }

        public override void AddMoney(int money)
        {
            var intAsFloat = (float)money;
            AddMoney(intAsFloat);
        }

        public override void AddMoney(string money)
        {
            if (float.TryParse(money, out float value))
                AddMoney(value);
            else
                throw new Exception("Invalid deposit amount entered in the string.");
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var item in payment)
            {
                statistics.AddMoney(item);
            }

            return statistics;
        }
    }
}
