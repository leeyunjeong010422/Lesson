using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<PooledObject> pool = new List<PooledObject>();
    [SerializeField] PooledObject prefeb;
    [SerializeField] int size;

    private void Awake()
    {
        for(int i = 0; i < size; i++)
        {
            PooledObject instance = Instantiate(prefeb);
            instance.gameObject.SetActive(false);
            instance.transform.parent = transform;
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
            instance.gameObject.SetActive(true);
            instance.returnPool = this;

            pool.RemoveAt(pool.Count - 1);

            return instance;
        }
        else
        {
            PooledObject instance = Instantiate(prefeb, position, rotation);
            instance.returnPool = this;
            return instance;
        }
    }

    public void ReturnPool(PooledObject instance)
    {
        instance.gameObject.SetActive(false);
        instance.transform.parent = transform;
        pool.Add(instance);
    }
}
