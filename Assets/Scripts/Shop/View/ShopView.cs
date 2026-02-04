using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private Transform _bundlesContainer;
        [SerializeField] private BundleCardView _bundleCardPrefab;

        private readonly List<BundleCardView> _cardViews = new();

        public void Initialize(IEnumerable<Bundle> bundles)
        {
            ClearBundles();

            foreach (var bundle in bundles)
            {
                var cardView = Instantiate(_bundleCardPrefab, _bundlesContainer);
                if (cardView != null)
                {
                    cardView.Initialize(bundle, true);
                    _cardViews.Add(cardView);
                }
            }
        }

        public void RefreshBundles()
        {
            foreach (var cardView in _cardViews)
            {
                cardView?.Refresh();
            }
        }

        public void SetOnBuyClicked(System.Action<Bundle> callback)
        {
            foreach (var cardView in _cardViews)
            {
                cardView?.SetOnBuyClicked(callback);
            }
        }

        public void SetOnInfoClicked(System.Action<Bundle> callback)
        {
            foreach (var cardView in _cardViews)
            {
                cardView?.SetOnInfoClicked(callback);
            }
        }

        public BundleCardView GetCardView(Bundle bundle)
        {
            foreach (var cardView in _cardViews)
            {
                if (cardView != null && ReferenceEquals(cardView.Bundle, bundle))
                {
                    return cardView;
                }
            }
            return null;
        }

        private void ClearBundles()
        {
            foreach (var cardView in _cardViews)
            {
                if (cardView != null)
                {
                    Destroy(cardView.gameObject);
                }
            }
            _cardViews.Clear();
        }
    }
}

