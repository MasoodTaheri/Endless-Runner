using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public GameObject _buildingPrefab;
    public Coin _coinPrefab;
    public Star _starPrefab;
    public ObstacleController _obstaclePrefab;
    public ObstacleController _LargeobstaclePrefab;
    public List<LevelChunkController> _levelChunkControllers = new List<LevelChunkController>();

    //private ObjectPool<GameObject> BuildingPool;
    //private ObjectPool<Coin> _coinPool;

    public PoolHandler BuildingPoolManager=new PoolHandler();
    public PoolHandler CoinsPoolManager=new PoolHandler();
    public PoolHandler StarsPoolManager=new PoolHandler();
    public PoolHandler ObstaclePoolManager=new PoolHandler();
    public PoolHandler LargeObstaclePoolManager=new PoolHandler();

    public void Initialize()
    {
        //CreateBuildingPool();
        BuildingPoolManager.Initialize(_buildingPrefab,"Buildings");
        CoinsPoolManager.Initialize(_coinPrefab.gameObject,"Coin");
        StarsPoolManager.Initialize(_starPrefab.gameObject,"Star");
        ObstaclePoolManager.Initialize(_obstaclePrefab.gameObject,"Obstacle");
        LargeObstaclePoolManager.Initialize(_LargeobstaclePrefab.gameObject,"LargeObstacle");
    }


    /* #region Building

    private void CreateBuildingPool()
    {
        BuildingPool = new ObjectPool<GameObject>(
            createFunc: CreateBuilding,
            actionOnGet: OnBuildingGet,
            actionOnRelease: OnBuildingRelease,
            actionOnDestroy: OnBuildingDestroy,
            defaultCapacity: 10,
            maxSize: 80
        );
    }

    private int buildingId = 0;
    private GameObject CreateBuilding()
    {
        GameObject obj = Instantiate(_buildingPrefab);
        obj.name = "Building"+buildingId++;
        obj.gameObject.SetActive(false);
        return obj;
    }


    private void OnBuildingGet(GameObject building)
    {
        building.gameObject.SetActive(true);
    }


    private void OnBuildingRelease(GameObject building)
    {
        building.gameObject.SetActive(false);
    }

    private void OnBuildingDestroy(GameObject building)
    {
        Destroy(building.gameObject);
    }


    public GameObject GetBuilding()
    {
        GameObject building = BuildingPool.Get();
        return building;
    }


    public void ReturnBuilding(GameObject building)
    {
        BuildingPool.Release(building);
    }

    #endregion
    */
}

public class PoolHandler
{
    private ObjectPool<GameObject> _pool;
    private GameObject _prefab;
    private string _poolName;
    private int itemId = 0;

    public void Initialize(GameObject prefab,string name)
    {
        _prefab = prefab;
        _poolName = name;
        CreatePool();
    }

    private void CreatePool()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: CreateItem,
            actionOnGet: OnItemGet,
            actionOnRelease: OnItemRelease,
            actionOnDestroy: OnItemDestroy,
            defaultCapacity: 10,
            maxSize: 80
        );
    }

    

    private GameObject CreateItem()
    {
        GameObject obj = GameObject.Instantiate(_prefab);
        obj.name = _poolName + itemId++;
        obj.gameObject.SetActive(false);
        return obj;
    }


    private void OnItemGet(GameObject item)
    {
        item.gameObject.SetActive(true);
    }


    private void OnItemRelease(GameObject item)
    {
        item.SetActive(false);
    }

    private void OnItemDestroy(GameObject item)
    {
        GameObject.Destroy(item.gameObject);
    }


    public GameObject Getinstance()
    {
        GameObject item = _pool.Get();
        return item;
    }


    public void ReturnToPool(GameObject item)
    {
        _pool.Release(item);
    }
}