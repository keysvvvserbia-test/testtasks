using System;
using Core;

namespace Location
{
    public class LocationToken : BaseToken<string>
    {
        private const string DEFAULT_LOCATION_NAME = "Default";

        private readonly Action<string> _addAction;
        private readonly Action<string> _removeAction;
        
        public override string Id => "Location";
        
        public override string ValueAsString => string.IsNullOrEmpty(Value) ? DEFAULT_LOCATION_NAME : Value;

        public LocationToken(Action<string> addAction, Action<string> removeAction)
        {
            Value = DEFAULT_LOCATION_NAME;
            _addAction = addAction;
            _removeAction = removeAction;
        }

        public override void Add(string value)
        {
            _addAction?.Invoke(value);
        }

        public override void AddUnit()
        {
            _removeAction?.Invoke(null);
        }

        public override void Remove(string value)
        {
            _removeAction?.Invoke(value);
        }
    }
}