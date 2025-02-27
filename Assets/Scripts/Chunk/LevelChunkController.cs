using UnityEngine;
using UnityEngine.Serialization;


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
        levelChunkView.ShowBuilding(_model.BuildingCount, _model.BuildingPrefab);
        levelChunkView.ShowCoins( _model.CoinPrefab);
        levelChunkView.ShowStars(_model.StarPrefab);
        levelChunkView.ShowObstacles(_model.ObstaclePrefab);
        levelChunkView.ShowLongObstacles(_model.LongObstaclePrefab);
    }

    public void Release()
    {
        levelChunkView.Release();
    }
}