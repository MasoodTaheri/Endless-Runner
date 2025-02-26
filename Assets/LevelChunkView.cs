using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelChunkView : MonoBehaviour
{
    [SerializeField] private List<GameObject> BuildingPositions;
    [SerializeField] private List<GameObject> StarPositions;
    [SerializeField] private List<GameObject> CoinPositions;
    [SerializeField] private List<GameObject> ObstaclePositions;
    [SerializeField] private List<GameObject> LongObstaclePositions;
    private GameEventManager _gameEventManager;

    public void Start()
    {
        foreach (var obj in BuildingPositions)
            obj.SetActive(false);
        foreach (var obj in StarPositions)
            obj.SetActive(false);
        foreach (var obj in CoinPositions)
            obj.SetActive(false);
        // foreach (var obj in ObstaclePositions)
        //     obj.SetActive(false);
        // foreach (var obj in LongObstaclePositions)
        //     obj.SetActive(false);
    }

    public void Initialize(GameEventManager gameEventManager)
    {
        _gameEventManager = gameEventManager;
    }

    public void ShowBuilding(int count, GameObject building)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(building,
                BuildingPositions[Random.Range(0, BuildingPositions.Count)].transform.position, Quaternion.identity);
            obj.transform.SetParent(this.transform);
        }
    }

    public void ShowStars(Star starObject)
    {
        for (int i = 0; i < StarPositions.Count; i++)
        {
            var obj = Instantiate(starObject,
                StarPositions[i].transform.position, Quaternion.identity);
            obj.transform.SetParent(this.transform);
            obj.SetGameEventManager(_gameEventManager);
        }
    }
    
    public void ShowCoins(Coin coinObject)
    {
        for (int i = 0; i < CoinPositions.Count; i++)
        {
            var obj = Instantiate(coinObject,
                CoinPositions[i].transform.position, Quaternion.identity);
            obj.transform.SetParent(this.transform);
            obj.SetGameEventManager(_gameEventManager);
        }
    }
}