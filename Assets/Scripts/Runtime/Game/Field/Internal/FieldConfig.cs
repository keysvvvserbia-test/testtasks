using UnityEngine;

namespace ZooWorld.Game
{
    [CreateAssetMenu(menuName = "ZooWorld/FieldConfig", fileName = "FieldConfig")]
    public class FieldConfig : ScriptableObject
    {
        [SerializeField] private Vector2 _size;

        public Vector2 Size => _size;
    }
}
