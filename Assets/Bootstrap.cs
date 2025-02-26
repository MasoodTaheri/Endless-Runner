using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public GameEventManager gameEventManager;
    public UIPresenter uiPresenter;
    public LevelController levelController;
    [SerializeField] private GameObject player;

    public void Start()
    {
        uiPresenter.Initialize(gameEventManager);
        levelController.Initialize(gameEventManager);
        player.SetActive(true);
    }
}