using System;
using UnityEngine;
using Zenject;

namespace ZooWorld.Foundation
{
    public abstract class BaseAutoInjectableMonoComponent : MonoBehaviour
    {
        [Inject] private DiContainer Container { get; set; }

        protected virtual void Awake()
        {
            ForceResolve();
        }

        protected void ForceResolve()
        {
            try
            {
                if (Container == null)
                {
                    SceneContextResolver.Container.Inject(this);
                    Container = SceneContextResolver.Container;
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Inject {GetType()} exception {name}", this);
                Debug.LogException(e);
            }
        }
    }

    public abstract class BaseAutoInjectable
    {
        [Inject] private DiContainer Container { get; set; }

        protected BaseAutoInjectable()
        {
            ForceResolve();
        }

        protected void ForceResolve()
        {
            try
            {
                if (Container == null)
                {
                    SceneContextResolver.Container.Inject(this);
                    Container = SceneContextResolver.Container;
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Inject {GetType()} exception {GetType()}");
                Debug.LogException(e);
            }
        }
    }
}
