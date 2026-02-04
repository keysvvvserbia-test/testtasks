using Core;
using UnityEngine;

namespace Gold
{
    [CreateAssetMenu(fileName = "GoldCostFixed", menuName = "Gold/Cost Fixed")]
    public class GoldCostFixed : BaseCost
    {
        [SerializeField] private int _amount;

        public override bool CanExecute()
        {
            return GoldController.Instance.HasEnough(_amount);
        }

        public override void Execute()
        {
            GoldController.Instance.AddGold(-_amount);
        }
    }
}

