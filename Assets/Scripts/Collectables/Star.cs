using UnityEngine;

namespace Collectables
{
    public class Star : Collectable
    {
        public GameObject uiprefab;

        public override void CollideHappening(Collider other)
        {
            _gameEventManager.AddStar(score);
            _poolManager.StarsPoolManager.ReturnToPool(this.gameObject);
        }
    }
}