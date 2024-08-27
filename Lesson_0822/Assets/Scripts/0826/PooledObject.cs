using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPool returnPool;

    //���� �ڿ� �ݳ��� �� ����
    [SerializeField] float returnTime;

    private float curTime;

    //Ȱ��ȭ�Ǿ��� ��
    private void OnEnable()
    {
        //���� �ð� = ���ư� �ð�
        curTime = returnTime;
    }

    private void Update()
    {
        //1�ʰ� �帣�� 1�� �����ǰ� 2�ʰ� �帣�� 2�� �����ǵ���
        //������Ʈ���� �ɸ� �ð� ����
        curTime -= Time.deltaTime;
        
        //���� ���� �ð��� �� ������ �Ǿ��ٸ� ReturnPool�� ���ư�
        if (curTime < 0 )
        {
            returnPool.ReturnPool(this);
        }
    }
}
