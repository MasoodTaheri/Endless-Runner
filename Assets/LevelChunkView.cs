using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LevelChunkView : MonoBehaviour
{
    [SerializeField] private List<GameObject> BuildingPositions;
    [SerializeField] private List<GameObject> StarPositions;
    [SerializeField] private List<GameObject> CoinPositions;
    [SerializeField] private List<GameObject> ObstaclePositions;
    [SerializeField] private List<GameObject> LongObstaclePositions;

    private GameEventManager _gameEventManager;
    private PoolManager _poolManager;
    public List<GameObject> Buildings = new List<GameObject>();
    public List<GameObject> Stars = new List<GameObject>();
    public List<GameObject> Coins = new List<GameObject>();
    public List<GameObject> Obstacles = new List<GameObject>();
    public List<GameObject> LargeObstacles = new List<GameObject>();

    public void Start()
    {
        foreach (var obj in BuildingPositions)
            obj.SetActive(false);
        foreach (var obj in StarPositions)
            obj.SetActive(false);
        foreach (var obj in CoinPositions)
            obj.SetActive(false);
        foreach (var obj in ObstaclePositions)
            obj.SetActive(false);
        foreach (var obj in LongObstaclePositions)
            obj.SetActive(false);
    }

    public void Initialize(GameEventManager gameEventManager, PoolManager poolManager)
    {
        _gameEventManager = gameEventManager;
        _poolManager = poolManager;
    }

    public void ShowBuilding(int count, GameObject building)
    {
        for (int i = 0; i < count; i++)
        {
            var r = Random.Range(0, BuildingPositions.Count);
            var position = BuildingPositions[r].transform.position; //+transform.position;
            var obj = _poolManager.BuildingPoolManager.Getinstance();
            obj.transform.position = position;
            obj.transform.SetParent(_poolManager.transform);
            Buildings.Add(obj);
        }
    }

    public void ShowStars(Star starObject)
    {
        for (int i = 0; i < StarPositions.Count; i++)
        {
           /* var obj = Instantiate(starObject,
                StarPositions[i].transform.position, Quaternion.identity);
            obj.transform.SetParent(this.transform);
            obj.SetGameEventManager(_gameEventManager, _poolManager);*/
            
            
            
            var obj = _poolManager.StarsPoolManager.Getinstance();
            obj.transform.position = StarPositions[i].transform.position;
            obj.transform.SetParent(_poolManager.transform);
            Stars.Add(obj);
            obj.GetComponent<Star>().SetGameEventManager(_gameEventManager, _poolManager);
        }
    }

    public void ShowCoins(Coin coinObject)
    {
        for (int i = 0; i < CoinPositions.Count; i++)
        {
            //var obj = Instantiate(coinObject,
            //CoinPositions[i].transform.position, Quaternion.identity);
            var obj = _poolManager.CoinsPoolManager.Getinstance();
            obj.transform.position = CoinPositions[i].transform.position;
            obj.transform.SetParent(_poolManager.transform);
            Coins.Add(obj);
            obj.GetComponent<Coin>().SetGameEventManager(_gameEventManager, _poolManager);
        }
    }

    public void ShowObstacles(ObstacleController obstacleObject)
    {
        for (int i = 0; i < ObstaclePositions.Count; i++)
        {
        /*    var obj = Instantiate(obstacleObject,
                ObstaclePositions[i].transform.position, Quaternion.identity);
            obj.transform.SetParent(this.transform);
            obj.SetGameEventManager(_gameEventManager);*/
        var obj = _poolManager.ObstaclePoolManager.Getinstance();
        obj.transform.position = ObstaclePositions[i].transform.position;
        obj.transform.SetParent(_poolManager.transform);
        Obstacles.Add(obj);
        obj.GetComponent<ObstacleController>().SetGameEventManager(_gameEventManager);

        }
    }

    public void ShowLongObstacles(ObstacleController obstacleObject)
    {
        for (int i = 0; i < LongObstaclePositions.Count; i++)
        {
           /* var obj = Instantiate(obstacleObject,
                LongObstaclePositions[i].transform.position, Quaternion.identity);
            obj.transform.SetParent(this.transform);
            obj.SetGameEventManager(_gameEventManager);*/
           
           var obj = _poolManager.LargeObstaclePoolManager.Getinstance();
           obj.transform.position = LongObstaclePositions[i].transform.position;
           obj.transform.SetParent(_poolManager.transform);
           LargeObstacles.Add(obj);
           obj.GetComponent<ObstacleController>().SetGameEventManager(_gameEventManager);
        }
    }

    public void Release()
    {
        foreach (GameObject o in Buildings)
            _poolManager.BuildingPoolManager.ReturnToPool(o);
        foreach (GameObject o in Coins)
            if (o.activeInHierarchy)
                _poolManager.CoinsPoolManager.ReturnToPool(o);       
        foreach (GameObject o in Stars)
            if (o.activeInHierarchy)
                _poolManager.StarsPoolManager.ReturnToPool(o); 
        
        foreach (GameObject o in Obstacles)
                _poolManager.ObstaclePoolManager.ReturnToPool(o);
        
        foreach (GameObject o in LargeObstacles)
            _poolManager.LargeObstaclePoolManager.ReturnToPool(o);
    }
}