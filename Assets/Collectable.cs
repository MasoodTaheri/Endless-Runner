using UnityEngine;

public abstract class Collectable : MonoBehaviour, ICollectable
{
    public int score;
    public GameObject particlePrefab;
    protected GameEventManager _gameEventManager;

    public void SetGameEventManager(GameEventManager manager)
    {
        _gameEventManager = manager;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        
        //if (other.gameObject.tag == "Player")
        {
            CollideHappening(other);
            //_gameEventManager.AddScore(score);
            //particlePrefab;
            Destroy(gameObject);
        }
    }

    public abstract void CollideHappening(Collider other);
}