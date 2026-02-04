using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public abstract class BaseTokenCounterView<T, TToken> : MonoBehaviour
        where TToken : BaseToken<T>
    {
        [SerializeField] private TMP_Text _txtName;
        [SerializeField] private TMP_Text _txtCount;
        [SerializeField] private Button _btnAdd;


        private TToken _token;
        
        protected void SetToken(TToken token)
        {
            _token = token;
            _token.OnValueChanged += OnValueChanged;
            RefreshView();
        }

        private void Awake()
        {
            _btnAdd.onClick.AddListener(OnClickAdd);
        }

        private void OnDestroy()
        {
            _btnAdd.onClick.RemoveListener(OnClickAdd);
            _token.OnValueChanged -= OnValueChanged;
        }

        private void OnClickAdd()
        {
            _token?.AddUnit();
        }

        private void OnValueChanged(T _)
        {
            RefreshView();
        }
        
        private void RefreshView()
        {
            _txtName.SetText(_token?.Id);
            _txtCount.SetText(_token?.ValueAsString);
        }
    }
}