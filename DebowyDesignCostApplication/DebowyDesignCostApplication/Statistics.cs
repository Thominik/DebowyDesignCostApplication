namespace DebowyDesignCostApplication
{
    public class Statistics
    {
        private static float AverageNationalNetSalary = 5443.84f;
        private const float MinimumNationalNetSalary = 2783.86f;
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public int Count { get; private set; }
        public float Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public bool AverageNetSalary
        {
            get
            {
                if (Average < AverageNationalNetSalary)
                    return false;
                else
                    return true;
            }
        }

        public bool MiminumNetSalary
        {
            get
            {
                if (Average < AverageNationalNetSalary)
                    return false;
                else
                    return true;
            }
        }

        public Statistics()
        {
            Count = 0;
            Sum = 0;
            Min = float.MaxValue;
            Max = float.MinValue;
        }

        public void AddMoney(float money)
        {
            Count++;
            Sum += money;
            Min = Math.Min(Min, money);
            Max = Math.Max(Max, money);
        }
    }
}
