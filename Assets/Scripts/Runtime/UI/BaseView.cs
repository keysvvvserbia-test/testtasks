using System;
using UnityEngine;

namespace ZooWorld.UI
{
    public abstract class BaseView : MonoBehaviour
    {
        private Action<string, BaseView> _hideAction;

        public string Id { get; set; }

        public void Init(Action<string, BaseView> hideAction)
        {
            _hideAction = hideAction;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            ShowInternal();
        }

        public void Hide()
        {
            HideInternal();
            gameObject.SetActive(false);
            _hideAction?.Invoke(Id, this);
        }

        protected virtual void ShowInternal()
        {
        }

        protected virtual void HideInternal()
        {
        }
    }
}
