using UnityEngine;

[CreateAssetMenu(fileName = "ChunkModel", menuName = "ScriptableObjects/Chunk data", order = 1)]
public class ChunkModel : ScriptableObject
{
    public int BuildingCount;
    public GameObject BuildingPrefab;
    public Coin CoinPrefab;
    public Star StarPrefab;
    public ObstacleController ObstaclePrefab;
    public ObstacleController LongObstaclePrefab;
}