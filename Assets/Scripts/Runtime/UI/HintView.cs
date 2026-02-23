using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace ZooWorld.UI
{
    public class HintView : BaseView
    {
        [SerializeField] private TMP_Text _txtHint;
        [SerializeField] private float _showDuration;
        [SerializeField] private Vector2 _screenOffset = new Vector2(0, -30f);
        
        private Transform _worldTarget;
        private Camera _worldCamera;
        private RectTransform _canvasRect;
        private RectTransform _selfRect;

        public void AttachToWorldTarget(Transform worldTarget, Camera worldCamera, RectTransform canvasRect)
        {
            _worldTarget = worldTarget;
            _worldCamera = worldCamera;
            _canvasRect = canvasRect;

            if (_selfRect == null)
                _selfRect = transform as RectTransform;
        }
        
        public void SetHintTxt(string msg)
        {
            if (_txtHint == null)
                return;
                    
            _txtHint.SetText(msg);
        }

        protected override void ShowInternal()
        {
            base.ShowInternal();
            AutoHideAsync().Forget();
        }

        private void LateUpdate()
        {
            if (!gameObject.activeInHierarchy) return;
            if (_worldTarget == null || _canvasRect == null || _selfRect == null) return;

            Camera cam = _worldCamera != null ? _worldCamera : Camera.main;
            if (cam == null) return;

            Vector3 screen = cam.WorldToScreenPoint(_worldTarget.position);
            if (screen.z < 0f) return; // behind camera

            screen.x += _screenOffset.x;
            screen.y += _screenOffset.y;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _canvasRect,
                    screen,
                    null, // overlay canvas
                    out Vector2 local))
            {
                _selfRect.anchoredPosition = local;
            }
        }

        private async UniTaskVoid AutoHideAsync()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_showDuration));
            Hide();
        }
    }
}