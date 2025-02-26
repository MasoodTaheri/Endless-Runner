using System;
using System.Collections;
using System.Collections.Generic;
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
    private List<LevelChunkController> Chunks=new List<LevelChunkController>();
    public Transform FirstChuncPos;
    private Vector3 lastChuncPos;
    private int chunckIndex=0;
    private GameEventManager _gameEventManager;
    private bool _isInitialized;

    public void Initialize(GameEventManager gameEventManager)
    {
        _isInitialized=true;
        _gameEventManager = gameEventManager;
    }

    public void LevelChunkFinished(LevelChunkController obj)
    {
        Chunks.Remove(obj);
        Destroy(obj.gameObject,1);
    }

    private void Update()
    {
        if (!_isInitialized)
            return;
        if (Chunks.Count < ChuncReadyCount)
        {
            var chunk = Instantiate(LevelPrefabs[0]);
            chunk._levelconreController = this;
            chunk.gameObject.name="chunck"+chunckIndex++;
            chunk.Initialize(_gameEventManager);
            if (Chunks.Count == 0)
                lastChuncPos = FirstChuncPos.position;
            else
                lastChuncPos += new Vector3(0,0,LevelChuncLength);

            chunk.transform.position = lastChuncPos;
            Chunks.Add(chunk);
        }
    }
    
    
}