using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "Bundle", menuName = "Shop/Bundle")]
    public class Bundle : ScriptableObject
    {
        [SerializeField] private string _description;
        [SerializeField] private List<BaseCost> _costs = new();
        [SerializeField] private List<BaseReward> _rewards = new();

        public string Description => _description;

        public bool CanPurchase()
        {
            foreach (var cost in _costs)
            {
                if (cost == null || !cost.CanExecute())
                {
                    return false;
                }
            }

            foreach (var reward in _rewards)
            {
                if (reward == null || !reward.CanExecute())
                {
                    return false;
                }
            }

            return true;
        }

        public void Purchase()
        {
            foreach (var cost in _costs)
            {
                if (cost != null)
                {
                    cost.Execute();
                }
            }

            foreach (var reward in _rewards)
            {
                if (reward != null)
                {
                    reward.Execute();
                }
            }
        }
    }
}