using UnityEngine;
using ZooWorld.Foundation;

namespace ZooWorld.Animals.Movement
{
    public static class MovementStrategyExtension
    {
        public static void MoveTowards(this IMovementStrategy _, Transform transform, Vector3 move)
        {
            var position = transform.position;
            var resultPos = position + move;
            if (!IsInRange(resultPos, out var inversionVector))
            {
                resultPos = position + Vector3.Scale(move, inversionVector);
            }

            transform.position = resultPos;
        }

        private static bool IsInRange(Vector3 position, out Vector3 inversionVector)
        {
            inversionVector = Vector3.one;
            var result = true;
            for (int i = 0; i < 3; ++i)
            {
                if (position[i] >= 50 || position[i] <= -50)
                {
                    inversionVector[i] = -1;
                    result = false;
                }
            }

            return result;
        }
    }
}