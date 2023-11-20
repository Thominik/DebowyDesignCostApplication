namespace DebowyDesignCostApplication
{
    public class EarningMonthInFile : EarningMonthBase
    {
        private string fileName;

        public override event MoneyAddedDelegate MoneyAdded;

        public EarningMonthInFile(string month) 
            : base(month)
        {
            fileName = $"{month}.txt";
        }

        public override void AddMoney(float money)
        {
            if (money > 0)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(money);
                }

                if (MoneyAdded != null)
                    MoneyAdded(this, new EventArgs());
            }
            else
                throw new Exception("Podano złą wartość kwoty.");
        }

        public override Statistics GetStatistics()
        {
            var moneyFromFile = ReadMoneyFromFile();

            var statistics = new Statistics();

            foreach (var money in moneyFromFile)
            {
                statistics.AddMoney(money);
            }

            return statistics;
        }

        private List<float> ReadMoneyFromFile()
        {
            var money = new List<float>();

            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        var number = float.Parse(line);
                        money.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new Exception("Nie ma takiego miesiąca rozliczeniowego!");
            }

            return money;
        }
    }
}
