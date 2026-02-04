using System;

namespace Core
{
    public abstract class BaseToken<T> : IToken
    {
        public event Action<T> OnValueChanged;
        
        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(value);
            }
        }

        public abstract string Id { get; }
        public abstract void Add(T value);
        public abstract void AddUnit();
        public abstract void Remove(T value);
        public virtual string ValueAsString => Value.ToString();

        public override bool Equals(object obj)
        {
            if (obj is not BaseToken<T> otherToken) 
                return false;
            
            if (otherToken.Id != Id) 
                return false;

            return otherToken.Value.Equals(Value);
        }

        public override string ToString()
        {
            return $"[{Id}:{Value}]";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}