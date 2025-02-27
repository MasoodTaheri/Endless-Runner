using UnityEngine;

namespace Collectables
{
    public class Coin : Collectable
    {
        public override void CollideHappening(Collider other)
        {
            _gameEventManager.AddScore(score);
            _poolManager.CoinsPoolManager.ReturnToPool(this.gameObject);
        }
    }
}