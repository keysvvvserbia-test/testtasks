using UnityEngine;

namespace ZooWorld.Game
{
    [CreateAssetMenu(menuName = "ZooWorld/FieldConfig", fileName = "FieldConfig")]
    public class FieldConfig : ScriptableObject
    {
        [SerializeField] private float _heightPlane;
        [SerializeField][Range(0, .5f)] private float _marginPercent;

        public float HeightPlane => _heightPlane;
        public float MarginPercent => _marginPercent;
    }
}
