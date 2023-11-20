using static DebowyDesignCostApplication.EarningMonthBase;

namespace DebowyDesignCostApplication
{
    public interface IEarningMonth
    {
        string Month { get; }

        void AddMoney(float money);

        void AddMoney(double money);

        void AddMoney(int money);

        void AddMoney(string money);


        event MoneyAddedDelegate MoneyAdded;

        Statistics GetStatistics();
    }
}
