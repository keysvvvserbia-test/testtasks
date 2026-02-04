using System;
using System.Collections.Generic;

namespace Core
{
    public class PlayerData : BaseSingleController<PlayerData>
    {
        public event Action OnChangeValue;
        private readonly Dictionary<string, IToken> _map = new();

        public void RegisterToken<T, TToken>(TToken token) where TToken : BaseToken<T>
        {
            if (!_map.TryAdd(token.Id, token))
            {
                throw new Exception($"Token with id [{token.Id}] already exists");
            }
            
            token.OnValueChanged += (_) => OnChangeValue?.Invoke();
        }
        
        public BaseToken<T> GetToken<T>(string key)
        {
            return _map.TryGetValue(key, out var token) ? token as BaseToken<T> : null;
        }
    }
}

