using System;

namespace Kdd.Common.Extensions
{
    public static class DoubleExtensions
    {
        private const double DoubleEpsilon = 1e-12d;

        public static bool EqualsWithPrecision(this double value, double other, double precisionEpsilon = DoubleEpsilon)
        {
            return Math.Abs(value - other) < precisionEpsilon;
        }

        public static int RoundToInt(this double value)
        {
            return (int)Math.Round(value);
        }

        public static double Clamp(this double value, double minValue, double maxValue)
        {
            if (value < minValue)
            {
                return minValue;
            }

            if (value > maxValue)
            {
                return maxValue;
            }

            return value;
        }

        public static double Clamp(this double value, DoubleRange valueRange)
        {
            return Clamp(value, valueRange.Minimum, valueRange.Maximum);
        }
    }
}