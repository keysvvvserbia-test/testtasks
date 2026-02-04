using Core;

namespace Location.View
{
    public class LocationCounterView : BaseTokenCounterView<string, LocationToken>
    {
        private void Start()
        {
            SetToken(LocationController.Instance.LocationToken);
        }
    }
}