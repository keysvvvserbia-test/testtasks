using Core;
using UnityEngine;

namespace Location
{
    [CreateAssetMenu(fileName = "LocationReward", menuName = "Location/Reward")]
    public class LocationReward : BaseReward
    {
        [SerializeField] private string _location;

        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {
            LocationController.Instance.SetLocation(_location);
        }
    }
}

