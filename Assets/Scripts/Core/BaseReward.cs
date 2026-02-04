using UnityEngine;

namespace Core
{
    public abstract class BaseReward : ScriptableObject, IAction
    {
        public abstract bool CanExecute();
        public abstract void Execute();
    }
}

