using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Shop
{
    public class BundleDetailViewController : MonoBehaviour
    {
        [SerializeField] private BundleCardView _bundleCardView;
        [SerializeField] private Button _backButton;

        private ShopController _shopController;

        private void Start()
        {
            InitializeControllers();
            InitializeCard();
            SetupBackButton();
        }

        private void InitializeControllers()
        {
            _shopController = new ShopController();
        }

        private void InitializeCard()
        {
            var bundle = BundleDetailData.CurrentBundle;
            if (_bundleCardView != null && bundle != null)
            {
                _bundleCardView.Initialize(bundle, false);
                _bundleCardView.SetOnBuyClicked(OnBundleBuyClicked);
            }
        }

        private void SetupBackButton()
        {
            if (_backButton != null)
            {
                _backButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(0);
                });
            }
        }

        private void OnBundleBuyClicked(Bundle bundle)
        {
            if (bundle == null) return;

            if (_bundleCardView != null)
            {
                _bundleCardView.SetProcessing(true);
            }

            StartCoroutine(_shopController.PurchaseBundle(bundle, (success) =>
            {
                if (_bundleCardView != null)
                {
                    _bundleCardView.SetProcessing(false);
                }
            }));
        }
    }
}

