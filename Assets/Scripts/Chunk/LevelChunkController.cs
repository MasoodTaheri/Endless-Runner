using PoolingSystem;
using UnityEngine;

namespace Chunk
{
    public class LevelChunkController : MonoBehaviour
    {
        public ILevelController _levelconreController;
        [SerializeField] private ChunkModel _model;
        [SerializeField] private LevelChunkView levelChunkView;
        [SerializeField] private EndlChunc EndlevelDetector;
        private GameEventManager _gameEventManager;
        private PoolManager _poolManager;

        private void ReachedToEndChunk()
        {
            _levelconreController.LevelChunkFinished(this);
        }

        public void Initialize(GameEventManager gameEventManager
            ,PoolManager poolManager)
        {
            _gameEventManager = gameEventManager;
            _poolManager = poolManager;
            EndlevelDetector.OnEndlChunk += ReachedToEndChunk;
            levelChunkView.Initialize(_gameEventManager,_poolManager);
            levelChunkView.ShowBuilding(_model.BuildingCount);
            levelChunkView.ShowCoins( );
            levelChunkView.ShowStars();
            levelChunkView.ShowObstacles();
            levelChunkView.ShowLongObstacles();
        }

        public void Release()
        {
            levelChunkView.Release();
        }
    }
}