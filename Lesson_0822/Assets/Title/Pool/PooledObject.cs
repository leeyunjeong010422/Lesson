using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPool returnPool;

    //몇초 뒤에 반납이 될 건지
    [SerializeField] float returnTime;

    private float curTime;

    //활성화되었을 때
    private void OnEnable()
    {
        //현재 시간 = 돌아갈 시간
        curTime = returnTime;
    }

    private void Update()
    {
        //1초가 흐르면 1이 차감되고 2초가 흐르면 2가 차감되도록
        //업데이트마다 걸린 시간 차감
        curTime -= Time.deltaTime;
        
        //만약 현재 시간이 다 차감이 되었다면 ReturnPool로 돌아감
        if (curTime < 0 )
        {
            returnPool.ReturnPool(this);
        }
    }
}
