using UnityEngine;
using Zenject;

namespace ZooWorld.Game
{
    public class FieldManager : IFieldManager
    {
        private readonly FieldConfig _config;

        public Vector2 Size => _config.Size;

        [Inject]
        public FieldManager(FieldConfig config)
        {
            _config = config;
        }
    }
}
