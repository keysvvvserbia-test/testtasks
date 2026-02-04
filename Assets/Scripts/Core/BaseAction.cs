using UnityEngine;

namespace Core
{
    public abstract class BaseAction : ScriptableObject
    {
        public abstract bool CanExecute();
        public abstract void Execute();
    }
}

