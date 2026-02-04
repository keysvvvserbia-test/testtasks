using System;

namespace Core
{
    public abstract class BaseSingleController<T> where T: class, new()
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

        public static T Instance => _instance.Value;

        protected BaseSingleController()
        {
            if (_instance.IsValueCreated)
                throw new InvalidOperationException($"{typeof(T).Name} is a singleton and already created.");
            
        }
    }
}