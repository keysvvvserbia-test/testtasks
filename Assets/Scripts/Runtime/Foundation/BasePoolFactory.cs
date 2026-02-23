using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ZooWorld.Foundation
{
    public abstract class BasePoolFactory<T> where T : MonoBehaviour
    {
        private readonly Dictionary<string, Queue<T>> _buffer = new();
        private readonly Transform _root;

        protected BasePoolFactory(Transform root = null)
        {
            _root = root;
        }

        public T Spawn(string id, T original, Transform targetRoot = null)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception($"original is empty");
            }

            var resultName = id;
            var rootForInstance = targetRoot != null ? targetRoot : _root;
            if (TryGetInstanceFromBuffer(resultName, rootForInstance, out var instance))
            {
                return instance;
            }

            if (original == null)
            {
                throw new Exception($"original [{typeof(T)}] is null") ;
            }

            var newInstanceGo = rootForInstance != null
                ? Object.Instantiate(original, rootForInstance, false)
                : Object.Instantiate(original);

            newInstanceGo.gameObject.SetActive(false);
            return newInstanceGo.GetComponent<T>();
        }

        public void Retrieve(T instance, string originalId)
        {
            if (instance is not { gameObject: {} gOjb })
            {
                Debug.LogWarning($"#POOL# NULL {originalId}");
                return;
            }

            gOjb.transform.position = Vector3.zero;
            gOjb.SetActive(false);

            if (_root != null && instance.transform.root != _root)
                instance.transform.SetParent(_root, false);

            _buffer[originalId].Enqueue(instance);
        }

        public void Clear()
        {
            _buffer.Clear();
        }
        
        private bool TryGetInstanceFromBuffer(string id, Transform targetRoot, out T instance)
        {
            if (!_buffer.TryGetValue(id, out var instances))
            {
                instances = new Queue<T>();
                _buffer.Add(id, instances);
            }
            
            while (instances.TryDequeue(out instance) && instance == null) {}

            if (instance == null)
            {
                return false;
            }

            if (targetRoot != null && instance.transform.root != targetRoot)
            {
                instance.transform.SetParent(targetRoot, false);
            }
            
            return true;
        }
    }
}