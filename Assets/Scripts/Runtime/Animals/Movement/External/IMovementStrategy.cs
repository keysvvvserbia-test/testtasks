namespace  ZooWorld.Animals.Movement
{
    public interface IMovementStrategy
    {
        void Tick(IAnimal animal, float deltaTime);
    }
}
