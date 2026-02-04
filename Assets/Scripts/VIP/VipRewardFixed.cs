using Core;
using UnityEngine;

namespace VIP
{
    [CreateAssetMenu(fileName = "VIPRewardFixed", menuName = "VIP/Reward Fixed")]
    public class VipRewardFixed : BaseReward
    {
        [SerializeField] private int _seconds;

        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {
            VipController.Instance.AddSeconds(_seconds);
        }
    }
}

