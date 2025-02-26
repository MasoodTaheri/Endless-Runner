using System;
using UnityEngine;

public class EndlChunc:MonoBehaviour
{
    public Action OnEndlChunk;

    public void OnTriggerEnter(Collider other)
    {
        OnEndlChunk?.Invoke();
    }
}