using System;
using System.Collections;
using System.Collections.Generic;
using Chunk;
using PoolingSystem;
using UnityEngine;

public class LevelModel
{
}

public interface ILevelController
{
    public void LevelChunkFinished(LevelChunkController obj);
}

public class LevelController : MonoBehaviour, ILevelController
{
    //levelcunch pool
    //star pool
    //Coin pool
    public float LevelChuncLength;
    public int ChuncReadyCount;
    public List<LevelChunkController> LevelPrefabs;
    private List<LevelChunkController> Chunks = new List<LevelChunkController>();
    public Transform FirstChuncPos;
    private Vector3 lastChuncPos;
    private int chunckIndex = 0;
    private GameEventManager _gameEventManager;
    private bool _isInitialized;
    private PoolManager _poolManager;

    public void Initialize(GameEventManager gameEventManager
        , PoolManager poolManager)
    {
        _isInitialized = true;
        _gameEventManager = gameEventManager;
        _poolManager = poolManager;
    }

    public void LevelChunkFinished(LevelChunkController obj)
    {
        obj.Release();
        Chunks.Remove(obj);
        Destroy(obj.gameObject, 1);
    }

    private void Update()
    {
        if (!_isInitialized)
            return;
        if (Chunks.Count < ChuncReadyCount)
        {
            var chunk = Instantiate(LevelPrefabs[0]);
            chunk._levelconreController = this;
            chunk.gameObject.name = "chunck" + chunckIndex++;

            if (Chunks.Count == 0)
                lastChuncPos = FirstChuncPos.position;
            else
                lastChuncPos += new Vector3(0, 0, LevelChuncLength);
            chunk.transform.position = lastChuncPos;
            chunk.Initialize(_gameEventManager, _poolManager);
            Chunks.Add(chunk);
        }
    }
}