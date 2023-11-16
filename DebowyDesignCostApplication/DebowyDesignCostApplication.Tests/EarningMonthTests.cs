namespace DebowyDesignCostApplication.Tests
{
    public class EarningMonthTests
    {
        [Test]
        public void CountShouldReturnCorrectValue()
        {
            var month = new EarningMonthInMemory("lipiec");

            month.AddMoney(1000);
            month.AddMoney("9000");
            month.AddMoney(5000f);

            var statistics = month.GetStatistics();

            Assert.AreEqual(3, statistics.Count);
        }

        [Test]
        public void MaxShouldReturnCorrectValue()
        {
            var month = new EarningMonthInMemory("lipiec");

            month.AddMoney(1000);
            month.AddMoney("9000");
            month.AddMoney(5000f);

            var statistics = month.GetStatistics();

            Assert.AreEqual(9000, statistics.Max);
        }

        [Test]
        public void MinShouldReturnCorrectValue()
        {
            var month = new EarningMonthInMemory("lipiec");

            month.AddMoney(1000);
            month.AddMoney("9000");
            month.AddMoney(5000f);

            var statistics = month.GetStatistics();

            Assert.AreEqual(1000, statistics.Min);
        }

        [Test]
        public void SumShouldReturnCorrectValue()
        {
            var month = new EarningMonthInMemory("lipiec");

            month.AddMoney(1000);
            month.AddMoney("9000");
            month.AddMoney(5000f);

            var statistics = month.GetStatistics();

            Assert.AreEqual(15000, statistics.Sum);
        }

        [Test]
        public void AverangeShouldReturnCorrectValue()
        {
            var month = new EarningMonthInMemory("lipiec");

            month.AddMoney(1000);
            month.AddMoney("9000");
            month.AddMoney(5000f);

            var statistics = month.GetStatistics();

            Assert.AreEqual(5000, statistics.Average);
        }

        [Test]
        public void AverangeNetSalaryShouldReturnCorrectValue()
        {
            var month = new EarningMonthInMemory("lipiec");

            month.AddMoney(1000);
            month.AddMoney("9000");
            month.AddMoney(5000f);

            var statistics = month.GetStatistics();

            Assert.AreEqual(false, statistics.AverageNetSalary);
        }

        [Test]
        public void MinimumNetSalaryShouldReturnCorrectValue()
        {
            var month = new EarningMonthInMemory("lipiec");

            month.AddMoney(1000);
            month.AddMoney("9000");
            month.AddMoney(5000f);

            var statistics = month.GetStatistics();

            Assert.AreEqual(true, statistics.MiminumNetSalary);
        }
    }
}
