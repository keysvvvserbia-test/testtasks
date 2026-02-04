using Core;
using UnityEngine;

namespace VIP
{
    [CreateAssetMenu(fileName = "VIPCostFixed", menuName = "VIP/Cost Fixed")]
    public class VipCostFixed : BaseCost
    {
        [SerializeField] private int _seconds;

        public override bool CanExecute()
        {
            return VipController.Instance.GetDuration().TotalSeconds >= _seconds;
        }

        public override void Execute()
        {
            VipController.Instance.RemoveSeconds(_seconds);
        }
    }
}

