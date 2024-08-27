using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //�����ϱ� ���� �ڷᱸ�� (����Ʈ�� �迭��)
    [SerializeField] List<PooledObject> pool = new List<PooledObject>();
    
    //� ������Ʈ�� ���� ������ ����
    [SerializeField] PooledObject prefab;

    //�� �� ���� ���� ������ ���ϱ�
    [SerializeField] int size;

    private void Awake()
    {
        for(int i = 0; i < size; i++)
        {
            //�����ŭ PooledObject�� ����
            PooledObject instance = Instantiate(prefab);
            //��Ȱ��ȭ�� �ؼ� ������ �ؾ� ��(Ȱ��ȭ �Ǿ� ���� ��� ���� ��� �Ѿ� 10���� ����� 10���� �Ѿ��� ���ư��� ������)
            instance.gameObject.SetActive(false);
            //��������ڸ��� pool�� ������ �ִ� �ָ� �θ�� ���� (���� ������)
            instance.transform.parent = transform;
            //�ݳ��� ���⼭ �϶�� �˷���
            instance.returnPool = this;
            //���� ������
            pool.Add(instance);
        }
    }

    //PooledObject�� ������
    public PooledObject GetPool(Vector3 position, Quaternion rotation)
    {
        //���� �� ������ �������ְ�
        if (pool.Count > 0)
        {
            //���� ������ �ִ� pool���� �ϳ� ������ �� (���� �������� �ִ� �� ������(pool.Count - 1))
            PooledObject instance = pool[pool.Count - 1];
            //������ �� ��ġ�� ȸ���� ������ ���� ��
            instance.transform.position = position;
            instance.transform.rotation = rotation;
            instance.transform.parent = null;
            instance.returnPool = this;

            //����ϱ� ������ Ȱ��ȭ���� ��
            instance.gameObject.SetActive(true);           

            //���������ϱ� ����Ʈ���� ����
            pool.RemoveAt(pool.Count - 1);

            return instance;
        }
        
        //���� �� ������ ���� ��(������ �뿩���� �� �����ϱ�)
        else
        {
            PooledObject instance = Instantiate(prefab, position, rotation);
            instance.returnPool = this;
            return instance;
        }
    }

    //�ݳ��ϱ�
    public void ReturnPool(PooledObject instance)
    {
        //����� �������� ��Ȱ��ȭ ��Ŵ
        instance.gameObject.SetActive(false);
        instance.transform.parent = transform;

        //�ݳ��ϴ� �Ŵϱ� �ٽ� pool�� ���� 
        pool.Add(instance);
    }
}
