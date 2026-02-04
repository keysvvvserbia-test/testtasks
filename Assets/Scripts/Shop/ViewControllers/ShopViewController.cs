using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shop
{
    public class ShopViewController : MonoBehaviour
    {
        [SerializeField] private ShopView _shopView;
        [SerializeField] private BundleRegistry _bundleRegistry;

        private ShopController _shopController;

        private void Start()
        {
            InitializeControllers();
            InitializeShop();
            PlayerData.Instance.OnChangeValue += RefreshDisplay;
        }

        private void OnDestroy()
        {
            PlayerData.Instance.OnChangeValue -= RefreshDisplay;
        }

        private void InitializeControllers()
        {
            _shopController = new ShopController();

            foreach (var bundle in _bundleRegistry.Bundles)
            {
                _shopController.AddBundle(bundle);
            }
        }

        private void InitializeShop()
        {
            if (_shopView == null) 
                return;
            
            _shopView.Initialize(_shopController.GetBundles());
            _shopView.SetOnBuyClicked(OnBundleBuyClicked);
            _shopView.SetOnInfoClicked(OnBundleInfoClicked);
        }

        private void OnBundleBuyClicked(Bundle bundle)
        {
            if (bundle == null) 
                return;

            var cardView = FindCardView(bundle);
            if (cardView != null)
            {
                cardView.SetProcessing(true);
            }

            void OnComplete(bool _)
            {
                if (cardView != null)
                {
                    cardView.SetProcessing(false);
                }

                RefreshDisplay();
            }

            StartCoroutine(_shopController.PurchaseBundle(bundle, onComplete: OnComplete));
        }

        private void OnBundleInfoClicked(Bundle bundle)
        {
            BundleDetailData.CurrentBundle = bundle;
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }

        private BundleCardView FindCardView(Bundle bundle)
        {
            return _shopView?.GetCardView(bundle);
        }

        private void RefreshDisplay()
        {
            if (_shopView != null)
            {
                _shopView.RefreshBundles();
            }
        }
    }
}

