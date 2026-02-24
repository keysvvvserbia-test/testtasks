using UnityEngine;
using Zenject;

namespace ZooWorld.Game
{
    public class FieldManager : IFieldManager
    {
        private readonly FieldConfig _config;
        private readonly Vector2 _size;

        public Vector2 Size => _size;

        [Inject]
        public FieldManager(FieldConfig config)
        {
            _config = config;
            _size = CalculateSizeFromCamera();
        }

        private Vector2 CalculateSizeFromCamera()
        {
            var camera = Camera.main;
            if (camera == null)
            {
                return new Vector2(100f, 100f);
            }

            var planeY = _config.HeightPlane;
            var center = new Vector3(0f, planeY, 0f);
            var centerViewport = camera.WorldToViewportPoint(center);
            var z = centerViewport.z;

            var p00 = camera.ViewportToWorldPoint(new Vector3(0f, 0f, z));
            var p11 = camera.ViewportToWorldPoint(new Vector3(1f, 1f, z));

            var width = Mathf.Abs(p11.x - p00.x);
            var height = Mathf.Abs(p11.z - p00.z);

            var marginPercent = _config.MarginPercent * 2f;

            width *= 1f - marginPercent;
            height *= 1f - marginPercent;

            return new Vector2(width, height);
        }
    }
}
