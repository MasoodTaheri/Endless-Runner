using PoolingSystem;

namespace Collectables
{
    public interface ICollectable
    {
        public void SetGameEventManager(GameEventManager manager,PoolManager poolManager);
    }
}