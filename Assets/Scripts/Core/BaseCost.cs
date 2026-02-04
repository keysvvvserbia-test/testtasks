using UnityEngine;

namespace Core
{
    public abstract class BaseCost : ScriptableObject, IAction
    {
        public abstract bool CanExecute();
        public abstract void Execute();
    }
}

