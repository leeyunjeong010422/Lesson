using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPool returnPool;

    //���� �ڿ� �ݳ��� �� ����
    [SerializeField] float returnTime;

    private float curTime;

    private void OnEnable()
    {
        curTime = returnTime;
    }

    private void Update()
    {
        curTime -= Time.deltaTime;
        if (curTime < 0 )
        {
            returnPool.ReturnPool(this);
        }
    }
}
