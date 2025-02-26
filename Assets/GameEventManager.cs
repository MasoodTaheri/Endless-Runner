using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventManager : MonoBehaviour
{
    public UnityEvent<int> OnScoreUpdated = new UnityEvent<int>();
    public UnityEvent<int> OnStarUpdated = new UnityEvent<int>();

    public void AddScore(int points)
    {
        OnScoreUpdated.Invoke(points);
    }
    public void AddStar(int points)
    {
        OnStarUpdated.Invoke(points);
    }
}