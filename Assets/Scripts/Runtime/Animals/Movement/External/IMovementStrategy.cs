using UnityEngine;

namespace  ZooWorld.Animals.Movement
{
    public interface IMovementStrategy
    {
        void Move(Transform animal, float deltaTime);
    }
}
