using Core;

namespace Health.View
{
    public class HealthCounterView : BaseTokenCounterView<(int, int), HealthToken>
    {
        private void Start()
        {
            SetToken(HealthController.Instance.HealthToken);
        }
    }
}