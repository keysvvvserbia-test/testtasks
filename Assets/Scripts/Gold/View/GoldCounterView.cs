using Core;

namespace Gold.View
{
    public class GoldCounterView: BaseTokenCounterView<int, GoldToken>
    {
        private void Start()
        {
            SetToken(GoldController.Instance.GoldToken);
        }
    }
}