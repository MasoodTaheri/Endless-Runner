using System.Collections;
using System.Collections.Generic;
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

    private ObjectPool<GameObject> BuildingPool;

    void Start()
    {
        CreateBuildingPool();
    }

    #region Building

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
}