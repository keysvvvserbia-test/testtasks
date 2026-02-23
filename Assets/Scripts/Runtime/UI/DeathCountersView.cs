using TMPro;
using UniRx;
using UnityEngine;
using Zenject;
using ZooWorld.Game;

namespace ZooWorld.UI
{
    public sealed class DeathCountersView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _preyCountText;
        [SerializeField] private TMP_Text _predatorCountText;

        [Inject] private IAnimalRegistry _registry;

        private void Start()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            if (_preyCountText != null)
                _registry.DeadPreyCount.Subscribe(RefreshPreyCounter).AddTo(this);

            if (_predatorCountText != null)
                _registry.DeadPredatorCount.Subscribe(RefreshPredatorCounter).AddTo(this);
        }

        private void RefreshPreyCounter(int deathCount)
        {
            _preyCountText.SetText(deathCount.ToString());
        }

        private void RefreshPredatorCounter(int predatorCount)
        {
            _predatorCountText.SetText(predatorCount.ToString());
        }
    }
}
