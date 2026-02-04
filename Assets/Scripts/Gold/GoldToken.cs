using Core;

namespace Gold
{
    public class GoldToken : BaseToken<int>
    {
        public override string Id => "Gold";

        public override void Add(int value)
        {
            Value += value;
        }

        public override void AddUnit()
        {
            Value++;
        }

        public override void Remove(int value)
        {
            Value -= value;
        }
    }
}