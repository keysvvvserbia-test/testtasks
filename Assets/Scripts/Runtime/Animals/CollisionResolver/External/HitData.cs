using ZooWorld.Animals;

namespace ZooWorld.CollisionResolver
{
    public struct HitData
    {
        public IAnimal Killer { get; }
        public IAnimal Victim { get; }

        public HitData(IAnimal killer, IAnimal victim)
        {
            Killer = killer;
            Victim = victim;
        }
    }
}