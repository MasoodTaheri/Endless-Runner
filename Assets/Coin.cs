using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : Collectable
{
    public override void CollideHappening(Collider other)
    {
        _gameEventManager.AddScore(score);
        _poolManager.CoinsPoolManager.ReturnToPool(this.gameObject);
    }
}