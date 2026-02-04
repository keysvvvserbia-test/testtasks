using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "HealthRewardPercentage", menuName = "Health/Reward Percentage")]
    public class HealthRewardPercentage : BaseReward
    {
        [SerializeField][Min(0)] private float _part;

        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {
            HealthController.Instance.AddPercent(_part);
        }
    }
}

