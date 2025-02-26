using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public GameEventManager gameEventManager;
    public UIPresenter uiPresenter;
    public LevelController levelController;
    [SerializeField] private PlayerCharacterController player;

    public void Start()
    {
        uiPresenter.Initialize(gameEventManager);
        levelController.Initialize(gameEventManager);
        player.Initialize(gameEventManager);
        player.gameObject.SetActive(true);
    }
}