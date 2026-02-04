using Core;

namespace Gold
{
    public class GoldController : BaseSingleController<GoldController>
    {
        public GoldToken GoldToken { get; }

        public GoldController()
        {
            GoldToken = new GoldToken();
            PlayerData.Instance.RegisterToken<int, GoldToken>(GoldToken);
        }

        public void AddGold(int amount)
        {
            GoldToken.Add(amount);
        }

        public bool HasEnough(int amount)
        {
            return GoldToken.Value >= amount;
        }
    }
}

