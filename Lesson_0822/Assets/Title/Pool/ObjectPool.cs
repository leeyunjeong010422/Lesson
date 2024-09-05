using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //보관하기 위한 자료구조 (리스트나 배열로)
    [SerializeField] List<PooledObject> pool = new List<PooledObject>();
    
    //어떤 오브젝트를 만들어서 보관할 건지
    [SerializeField] PooledObject prefab;

    //몇 개 만들 건지 사이즈 정하기
    [SerializeField] int size;

    private void Awake()
    {
        for(int i = 0; i < size; i++)
        {
            //사이즈만큼 PooledObject를 만듦
            PooledObject instance = Instantiate(prefab);
            //비활성화를 해서 보관을 해야 함(활성화 되어 있을 경우 예를 들어 총알 10개를 만들면 10개의 총알이 날아가기 때문에)
            instance.gameObject.SetActive(false);
            //만들어지자마자 pool을 가지고 있는 애를 부모로 지정 (보기 편해짐)
            instance.transform.parent = transform;
            //반납은 여기서 하라고 알려줌
            instance.returnPool = this;
            //만들어서 보관함
            pool.Add(instance);
        }
    }

    //PooledObject를 빌려줌
    public PooledObject GetPool(Vector3 position, Quaternion rotation)
    {
        //남은 게 있으면 빌려서주고
        if (pool.Count > 0)
        {
            //내가 가지고 있는 pool에서 하나 꺼내서 줌 (가장 마지막에 있는 걸 꺼내줌(pool.Count - 1))
            PooledObject instance = pool[pool.Count - 1];
            //꺼내줄 때 위치랑 회전도 꺼내서 같이 줌
            instance.transform.position = position;
            instance.transform.rotation = rotation;
            instance.transform.parent = null;
            instance.returnPool = this;

            //사용하기 직전에 활성화시켜 줌
            instance.gameObject.SetActive(true);           

            //꺼내줬으니까 리스트에서 빼줌
            pool.RemoveAt(pool.Count - 1);

            return instance;
        }
        
        //남은 게 없으면 만들어서 줌(없으면 대여해줄 수 없으니까)
        else
        {
            PooledObject instance = Instantiate(prefab, position, rotation);
            instance.returnPool = this;
            return instance;
        }
    }

    //반납하기
    public void ReturnPool(PooledObject instance)
    {
        //사용이 끝났으니 비활성화 시킴
        instance.gameObject.SetActive(false);
        instance.transform.parent = transform;

        //반납하는 거니까 다시 pool에 보관 
        pool.Add(instance);
    }
}
