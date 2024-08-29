using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<PooledObject> pool = new List<PooledObject>();
    [SerializeField] PooledObject prefab;
    [SerializeField] int size;
    [SerializeField] int capacity;
    [SerializeField] bool createOnEmpty = true;

    private void Awake()
    {
        for (int i = 0; i < size; i++)
        {
            PooledObject instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            instance.transform.parent = transform;
            instance.Pool = this;
            pool.Add(instance);
        }
    }

    public PooledObject GetPool(Vector3 position, Quaternion rotation)
    {
        if (pool.Count > 0)
        {
            PooledObject instance = pool[pool.Count - 1];
            instance.transform.position = position;
            instance.transform.rotation = rotation;
            instance.transform.parent = null;
            instance.Pool = this;
            instance.gameObject.SetActive(true);
            pool.RemoveAt(pool.Count - 1);

            return instance;
        }

        else if (createOnEmpty)
        {
            PooledObject instance = Instantiate(prefab, position, rotation);
            instance.Pool = this;
            return instance;
        }
       
        else
        {
            return null;
        }
    }
    public void ReturnPool(PooledObject instance)
    {

        if (pool.Count < capacity)
        {
            instance.gameObject.SetActive(false);
            instance.transform.parent = transform;
            pool.Add(instance);
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }
}
