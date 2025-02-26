using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public GameEventManager gameEventManager;
    public UIPresenter uiPresenter;
    [SerializeField] private List<GameObject> Collectables;
    [SerializeField] private GameObject player;
    public void Start()
    {
        uiPresenter.Initialize(gameEventManager);
        foreach (var collectable in Collectables)
            collectable.GetComponent<ICollectable>().SetGameEventManager(gameEventManager);
    }
}