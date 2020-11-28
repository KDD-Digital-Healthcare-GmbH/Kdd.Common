using Kdd.Common.Enums;
using Kdd.Common.Extensions;
using System;

namespace Kdd.Common
{
    public struct DoubleRange : IEquatable<DoubleRange>
    {
        public DoubleRange(double minimum, double maximum)
        {
            if (double.IsNaN(minimum))
            {
                throw new ArgumentException($"{nameof(minimum)} cannot be {double.NaN}");
            }

            if (double.IsNaN(maximum))
            {
                throw new ArgumentException($"{nameof(maximum)} cannot be {double.NaN}");
            }

            if (minimum >= maximum)
            {
                throw new ArgumentException($"{nameof(maximum)} should be more than {nameof(minimum)}");
            }

            Minimum = minimum;
            Maximum = maximum;
        }

        public double Minimum { get; }

        public double Maximum { get; }

        public double Delta => Maximum - Minimum;

        public bool Contains(double value, IntervalType intervalType = IntervalType.Closed)
        {
            return intervalType switch
            {
                IntervalType.Closed => value >= Minimum && value <= Maximum,
                IntervalType.StartClosed => value >= Minimum && value < Maximum,
                IntervalType.EndClosed => value > Minimum && value <= Maximum,
                IntervalType.Open => value > Minimum && value < Maximum,
                _ => throw new NotSupportedException($"Not supported {nameof(intervalType)}: {intervalType}")
            };
        }

        public override bool Equals(object obj)
        {
            return obj is DoubleRange range && Equals(range);
        }

        public bool Equals(DoubleRange other)
        {
            return Minimum.EqualsWithPrecision(other.Minimum) &&
                   Maximum.EqualsWithPrecision(other.Maximum);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Minimum.RoundToInt(), Maximum.RoundToInt());
        }

        public static implicit operator DoubleRange((double, double) tuple)
        {
            return new DoubleRange(tuple.Item1, tuple.Item2);
        }
    }
}