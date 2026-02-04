using Core;

namespace Location
{
    public class LocationController : BaseSingleController<LocationController>
    {
        public LocationToken LocationToken { get; }

        public LocationController()
        {
            LocationToken = new LocationToken(addAction: SetLocation, removeAction: RemoveLocation);
            PlayerData.Instance.RegisterToken<string, LocationToken>(LocationToken);
        }

        public void SetLocation(string location)
        {
            LocationToken.Value = location;
        }

        public void RemoveLocation(string location)
        {
            ResetToDefault();
        }

        public void ResetToDefault()
        {
            SetLocation(null);
        }
    }
}

