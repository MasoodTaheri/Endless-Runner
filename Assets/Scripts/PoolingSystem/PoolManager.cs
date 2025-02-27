using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public PoolHandler BuildingPoolManager = new PoolHandler();
    public PoolHandler CoinsPoolManager = new PoolHandler();
    public PoolHandler StarsPoolManager = new PoolHandler();
    public PoolHandler ObstaclePoolManager = new PoolHandler();
    public PoolHandler LargeObstaclePoolManager = new PoolHandler();

    [SerializeField] private GameObject _buildingPrefab;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Star _starPrefab;
    [SerializeField] private ObstacleController _obstaclePrefab;
    [SerializeField] private ObstacleController _LargeobstaclePrefab;
    [SerializeField] private List<LevelChunkController> _levelChunkControllers = new List<LevelChunkController>();

    public void Initialize()
    {
        BuildingPoolManager.Initialize(_buildingPrefab, "Buildings");
        CoinsPoolManager.Initialize(_coinPrefab.gameObject, "Coin");
        StarsPoolManager.Initialize(_starPrefab.gameObject, "Star");
        ObstaclePoolManager.Initialize(_obstaclePrefab.gameObject, "Obstacle");
        LargeObstaclePoolManager.Initialize(_LargeobstaclePrefab.gameObject, "LargeObstacle");
    }
}