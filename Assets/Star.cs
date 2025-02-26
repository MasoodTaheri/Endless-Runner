using UnityEngine;

public class Star : Collectable
{
    public GameObject uiprefab;

    public override void CollideHappening(Collider other)
    {
        _gameEventManager.AddStar(score);
    }
}