using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "BundleRegistry", menuName = "Shop/BundleRegistry")]
    public class BundleRegistry : ScriptableObject
    {
        [SerializeField] private Bundle[] _bundles;
        
        public IReadOnlyList<Bundle> Bundles => _bundles;
    }
}