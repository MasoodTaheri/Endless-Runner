using UnityEngine;
using UnityEngine.Serialization;


public class LevelChunkController : MonoBehaviour
{
    public ILevelController _levelconreController;
    [SerializeField] private ChunkModel _model;
    [SerializeField] private LevelChunkView levelChunkView;
    [SerializeField] private EndlChunc EndlevelDetector;
    private GameEventManager _gameEventManager;

    private void ReachedToEndChunk()
    {
        _levelconreController.LevelChunkFinished(this);
    }

    public void Initialize(GameEventManager gameEventManager)
    {
        _gameEventManager = gameEventManager;
        EndlevelDetector.OnEndlChunk += ReachedToEndChunk;
        levelChunkView.Initialize(_gameEventManager);
        levelChunkView.ShowBuilding(_model.BuildingCount, _model.BuildingPrefab);
        levelChunkView.ShowCoins( _model.CoinPrefab);
        levelChunkView.ShowStars(_model.StarPrefab);
    }
}