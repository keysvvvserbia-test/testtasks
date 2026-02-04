using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "HealthRewardFixed", menuName = "Health/Reward Fixed")]
    public class HealthRewardFixed : BaseReward
    {
        [SerializeField] private int _amount;

        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {
            HealthController.Instance.AddHealth(_amount);
        }
    }
}

