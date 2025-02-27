using UnityEngine;
using UnityEngine.Pool;

namespace PoolingSystem
{
    public class PoolHandler
    {
        private ObjectPool<GameObject> _pool;
        private GameObject _prefab;
        private string _poolName;
        private int itemId = 0;

        public void Initialize(GameObject prefab,string name)
        {
            _prefab = prefab;
            _poolName = name;
            CreatePool();
        }

        private void CreatePool()
        {
            _pool = new ObjectPool<GameObject>(
                createFunc: CreateItem,
                actionOnGet: OnItemGet,
                actionOnRelease: OnItemRelease,
                actionOnDestroy: OnItemDestroy,
                defaultCapacity: 10,
                maxSize: 80
            );
        }

    

        private GameObject CreateItem()
        {
            GameObject obj = GameObject.Instantiate(_prefab);
            obj.name = _poolName + itemId++;
            obj.gameObject.SetActive(false);
            return obj;
        }


        private void OnItemGet(GameObject item)
        {
            item.gameObject.SetActive(true);
        }


        private void OnItemRelease(GameObject item)
        {
            item.SetActive(false);
        }

        private void OnItemDestroy(GameObject item)
        {
            GameObject.Destroy(item.gameObject);
        }


        public GameObject Getinstance()
        {
            GameObject item = _pool.Get();
            return item;
        }


        public void ReturnToPool(GameObject item)
        {
            _pool.Release(item);
        }
    }
}