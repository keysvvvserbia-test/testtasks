using UnityEngine;
using Zenject;
using ZooWorld.CollisionResolver;
using ZooWorld.Foundation;

namespace ZooWorld.UI
{
    public class HintController : BaseAutoInjectableMonoComponent
    {
        [SerializeField] private HintView _hintPrefab;
        [SerializeField] private Camera _worldCamera;
            
        private ICollisionResolver _collisionResolver;
        private ViewFactory _viewFactory;
        
        [Inject]
        private void Resolve(ICollisionResolver collisionResolver)
        {
            _collisionResolver = collisionResolver;
            _viewFactory = new ViewFactory(transform);
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _collisionResolver.OnCollision += HandleCollision;
        }

        private void Unsubscribe()
        {
            _collisionResolver.OnCollision -= HandleCollision;
        }

        private void HandleCollision(HitData hitData)
        {
            var hint = (HintView)_viewFactory.Spawn(_hintPrefab.name, _hintPrefab, transform);
            hint.Id = _hintPrefab.name;
            hint.Init(HideHint);
            hint.AttachToWorldTarget(
                hitData.Killer.Transform,
                _worldCamera != null ? _worldCamera : Camera.main,
                transform as RectTransform);
            hint.Show();
        }

        private void HideHint(string instanceId, BaseView hintView)
        {
            _viewFactory.Retrieve(hintView, instanceId);
        }
    }
}