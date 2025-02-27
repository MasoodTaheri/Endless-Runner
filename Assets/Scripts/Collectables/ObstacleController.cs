using UnityEngine;

namespace Collectables
{
    public class ObstacleController : MonoBehaviour
    {
        protected GameEventManager _gameEventManager;

        public void SetGameEventManager(GameEventManager manager)
        {
            _gameEventManager = manager;
        }

        private void OnCollisionEnter(Collision other)
        {
            _gameEventManager.GameFinished();
        }
    }
}