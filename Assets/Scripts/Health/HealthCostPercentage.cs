using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "HealthCostPercentage", menuName = "Health/Cost Percentage")]
    public class HealthCostPercentage : BaseCost
    {
        [SerializeField][Range(0, 1)] private float _part;

        public override bool CanExecute()
        {
            return _part < 1f;
        }

        public override void Execute()
        {
            HealthController.Instance.RemovePercent(_part);
        }
    }
}

