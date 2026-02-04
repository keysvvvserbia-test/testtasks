using Core;

namespace Health
{
    public class HealthController : BaseSingleController<HealthController>
    {
        public HealthToken HealthToken { get; }

        public HealthController()
        {
            HealthToken = new HealthToken();
            PlayerData.Instance.RegisterToken<(int, int), HealthToken>(HealthToken);
        }

        public void AddHealth(int amount)
        {
            HealthToken.AddCurrent(amount);
        }

        public void RemoveHealth(int amount)
        {
            HealthToken.RemoveCurrent(amount);
        }

        public void AddPercent(float percent)
        {
            HealthToken.Add(percent);
        }

        public void RemovePercent(float percent)
        {
            HealthToken.Add(-percent);
        }

        public bool HasEnough(int amount)
        {
            return HealthToken.Value.Current >= amount;
        }
    }
}

