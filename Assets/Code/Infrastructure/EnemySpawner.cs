using Battle;
using Enemies;
using Misc;

namespace Infrastructure
{
    public class EnemySpawner : Spawner<Entity>
    {
        protected override string ContainerTag => $"[ PROJECTILES | {enemyType.title} ]";

        public EnemyType enemyType;
        
        
        
        public 
    }
}