using PoolingSystem;
using UnityEngine;

namespace Collectables
{
    public abstract class Collectable : MonoBehaviour, ICollectable
    {
        public int score;
        public GameObject particlePrefab;
        protected GameEventManager _gameEventManager;
        protected PoolManager _poolManager;

        public void SetGameEventManager(GameEventManager manager,PoolManager poolManager)
        {
            _gameEventManager = manager;
            _poolManager = poolManager;
        }

        public virtual void OnTriggerEnter(Collider other)
        {
            //if (other.gameObject.tag == "Player")
            {
                CollideHappening(other);
            }
        }

        public abstract void CollideHappening(Collider other);
    }
}