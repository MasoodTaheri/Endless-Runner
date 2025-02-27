using System;
using UnityEngine;

namespace Chunk
{
    public class EndlChunc:MonoBehaviour
    {
        public Action OnEndlChunk;

        public void OnTriggerEnter(Collider other)
        {
            OnEndlChunk?.Invoke();
        }
    }
}