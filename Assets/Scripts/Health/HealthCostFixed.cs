using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "HealthCostFixed", menuName = "Health/Cost Fixed")]
    public class HealthCostFixed : BaseCost
    {
        [SerializeField] private int _amount;

        public override bool CanExecute()
        {
            return HealthController.Instance.HasEnough(_amount);
        }

        public override void Execute()
        {
            HealthController.Instance.AddHealth(-_amount);
        }
    }
}

