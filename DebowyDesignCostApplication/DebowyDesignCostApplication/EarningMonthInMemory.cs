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
                payment.Add(money);

                if (MoneyAdded != null)
                {
                    MoneyAdded(this, new EventArgs());
                }
            }
            else
                throw new Exception("Incorrect deposit amount.");
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
