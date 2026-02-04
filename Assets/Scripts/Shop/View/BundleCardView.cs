using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class BundleCardView : MonoBehaviour
    {
        private const string WAITING_TEXT = "Обработка...";
        private const string BUY_TEXT = "Купить";
        
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _buyButtonText;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _infoButton;

        private Bundle _bundle;
        private Action<Bundle> _onBuyClicked;
        private Action<Bundle> _onInfoClicked;
        private bool _isProcessing;

        public Bundle Bundle => _bundle;

        public void Initialize(Bundle bundle, bool showInfoButton)
        {
            _bundle = bundle;

            if (_nameText != null && bundle != null)
            {
                _nameText.SetText(bundle.Description);
            }

            if (_infoButton != null)
            {
                _infoButton.gameObject.SetActive(showInfoButton);
                _infoButton.onClick.AddListener(OnInfoClicked);
            }

            if (_buyButton != null)
            {
                _buyButton.onClick.AddListener(OnBuyClicked);
            }

            Refresh();
        }

        public void Refresh()
        {
            if (_bundle == null) return;

            bool canPurchase = !_isProcessing && _bundle.CanPurchase();

            if (_buyButton != null)
            {
                _buyButton.interactable = canPurchase;
            }

            if (_buyButtonText != null)
            {
                _buyButtonText.SetText( _isProcessing ? WAITING_TEXT : BUY_TEXT);
            }
        }

        public void SetProcessing(bool processing)
        {
            _isProcessing = processing;
            Refresh();
        }

        public void SetOnBuyClicked(Action<Bundle> callback)
        {
            _onBuyClicked = callback;
        }

        public void SetOnInfoClicked(Action<Bundle> callback)
        {
            _onInfoClicked = callback;
        }

        private void OnBuyClicked()
        {
            _onBuyClicked?.Invoke(_bundle);
        }

        private void OnInfoClicked()
        {
            _onInfoClicked?.Invoke(_bundle);
        }
    }
}

