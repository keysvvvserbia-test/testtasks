using System;
using Core;

namespace Health
{
    public class HealthToken : BaseToken<(int Current, int Max)>
    {
        public override string Id => "Health";

        public override string ValueAsString => Value.Current.ToString();

        public HealthToken()
        {
            Value = (0, int.MaxValue);
        }

        public override void Add((int, int) value)
        {
            Add(value.Item1 * 1f / value.Item2);
        }

        public override void AddUnit()
        {
            AddCurrent(1);
        }

        public override void Remove((int, int) value)
        {
            Add(-value.Item1 * 1f / value.Item2);
        }

        public void Add(float part)
        {
            var currentValue = Value.Current;
            var additive = (int)Math.Round(part * currentValue);
            currentValue = Math.Clamp(currentValue + additive, 0, Value.Max);
            Value = (currentValue, Value.Max);
        }

        public void AddCurrent(int value)
        {
            var currentValue = Value.Current;
            currentValue = Math.Min(value + currentValue, Value.Max);
            Value = (currentValue, Value.Max);
        }

        public void RemoveCurrent(int value)
        {
            var currentValue = Value.Current;
            currentValue = Math.Max(currentValue - value, 0);
            Value = (currentValue, Value.Max);
        }
    }
}