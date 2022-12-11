using System;

namespace ChallengeApp
{
    public class Statistics
    {
        public double High;
        public double Low;
        public double Sum;
        public int Count;

        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case >= 90:
                        return 'A';

                    case >= 80:
                        return 'B';

                    case >= 70:
                        return 'C';

                    case >= 60:
                        return 'D';

                    case >= 50:
                        return 'E';

                    default:
                        return 'F';
                }
            }
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
    }
}