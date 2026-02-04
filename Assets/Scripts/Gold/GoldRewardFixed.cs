using Core;
using UnityEngine;

namespace Gold
{
    [CreateAssetMenu(fileName = "GoldRewardFixed", menuName = "Gold/Reward Fixed")]
    public class GoldRewardFixed : BaseReward
    {
        [SerializeField] private int _amount;

        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {
            GoldController.Instance.AddGold(_amount);
        }
    }
}

