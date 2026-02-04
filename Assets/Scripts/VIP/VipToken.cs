using System;
using Core;

namespace VIP
{
    public class VipToken : BaseToken<TimeSpan>
    {
        public override string Id => "Vip";

        public override string ValueAsString => $"{Value.TotalSeconds} sec";

        public override void Add(TimeSpan value)
        {
            Value += value;
        }

        public override void AddUnit()
        {
            AddSeconds(1);
        }

        public override void Remove(TimeSpan value)
        {
            var current = Value;
            var newDuration = current.Subtract(value);
            if (newDuration.TotalSeconds < 0)
            {
                newDuration = TimeSpan.Zero;
            }
            Value = newDuration;
        }

        public void AddSeconds(int value)
        {
            Add(TimeSpan.FromSeconds(value));
        }

        public void RemoveSeconds(int value)
        {
            Remove(TimeSpan.FromSeconds(value));
        }
    }
}