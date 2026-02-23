using UnityEngine;

namespace ZooWorld.Animals.Movement
{
    public static class MovementStrategyExtension
    {
        public static void MoveTowards(this IMovementStrategy _,
            Transform transform,
            Vector3 move,
            Vector2 fieldSize)
        {
            var position = transform.position;
            var resultPos = position + move;
            if (!IsInRange(resultPos, fieldSize, out var inversionVector))
            {
                resultPos = position + Vector3.Scale(move, inversionVector);
            }

            transform.position = resultPos;
        }

        public static Vector3 GetRandomDirectionXZ(this IMovementStrategy _)
        {
            var x = Random.Range(-1f, 1f);
            var z = Random.Range(-1f, 1f);
            return new Vector3(x, 0f, z);
        }

        private static bool IsInRange(Vector3 position, Vector2 fieldSize, out Vector3 inversionVector)
        {
            inversionVector = Vector3.one;
            var result = true;
            var halfFieldSize = fieldSize / 2f;
            if (position.x >= halfFieldSize.x || position.x <= -halfFieldSize.x)
            {
                inversionVector.x = -1f;
                result = false;
            }

            if (position.z >= halfFieldSize.y || position.z <= -halfFieldSize.y)
            {
                inversionVector.z = -1f;
                result = false;
            }

            return result;
        }
    }
}
