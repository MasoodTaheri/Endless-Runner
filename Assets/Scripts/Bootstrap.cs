using System.Collections.Generic;
using PoolingSystem;
using UI;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public GameEventManager gameEventManager;
    public UIPresenter uiPresenter;
    public LevelController levelController;
    [SerializeField] private PlayerCharacterController player;
    [SerializeField] private PoolManager poolManager;
    
    public void Start()
    {
        poolManager.Initialize();
        uiPresenter.Initialize(gameEventManager);
        levelController.Initialize(gameEventManager,poolManager);
        player.Initialize(gameEventManager);
        player.gameObject.SetActive(true);
    }
}