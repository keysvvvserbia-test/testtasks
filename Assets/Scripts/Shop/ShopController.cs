using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class ShopController
    {
        private const float PURCHASE_DELAY = 3f;

        private readonly List<Bundle> _bundles = new();

        public void AddBundle(Bundle bundle)
        {
            if (bundle != null && !_bundles.Contains(bundle))
            {
                _bundles.Add(bundle);
            }
        }

        public IReadOnlyList<Bundle> GetBundles()
        {
            return _bundles;
        }

        public IEnumerator PurchaseBundle(Bundle bundle, System.Action<bool> onComplete)
        {
            if (bundle == null || !bundle.CanPurchase())
            {
                onComplete?.Invoke(false);
                yield break;
            }

            yield return new WaitForSeconds(PURCHASE_DELAY);

            if (bundle.CanPurchase())
            {
                bundle.Purchase();
                onComplete?.Invoke(true);
            }
            else
            {
                onComplete?.Invoke(false);
            }
        }
    }
}

