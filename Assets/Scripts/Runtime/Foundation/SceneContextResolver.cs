using UnityEngine;
using Zenject;

namespace ZooWorld.Foundation
{
    public static class SceneContextResolver
    {
        private static DiContainer _container;

        public static GameObject ContextInstance { get; set; }

        public static DiContainer Container
        {
            get => _container;
            set
            {
                if (_container != null && value != null)
                {
                    Debug.LogWarning("Reset DiContainer!!!");
                }

                _container = value;
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init()
        {
            _container = null;
        }
    }
}

