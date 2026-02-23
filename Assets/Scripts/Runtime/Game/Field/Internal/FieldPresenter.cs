using UnityEngine;
using Zenject;
using ZooWorld.Foundation;

namespace ZooWorld.Game
{
    public class FieldPresenter : BaseAutoInjectableMonoComponent
    {
        private IFieldManager _fieldManager;

        [Inject]
        private void Resolve(IFieldManager fieldManager)
        {
            _fieldManager = fieldManager;
        }

        private void Start()
        {
            var fieldSize = _fieldManager.Size;
            transform.localScale = new Vector3(fieldSize.x, 2f, fieldSize.y);
            transform.localPosition = new Vector3(0, -1f, 0);
        }
    }
}
