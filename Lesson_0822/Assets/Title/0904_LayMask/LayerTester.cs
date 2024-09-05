using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerTester : MonoBehaviour
{
    [System.Flags]
    enum MonsterType
    {
        Fire = 1 << 0, 
        Water = 1 << 1, 
        Grass = 1 << 2, 
        Electric = 1 << 3
    }

    [SerializeField] MonsterType monsterType;
    [SerializeField] LayerMask layerMask;

    private void Start()
    {
        //Debug.Log(layerMask.value);

        //1 << n 해주면 n번째 자리수만 체크 해 준 결과
        //layerMask = 1 << 6;

        //1. 특정 레이어 체크 시키기 (기존 거 그대로 남아있음)
        //layerMask |= 1 << n;
        //layerMask : 0000 1110
        //체크레이어 : 0100 0000
        // | 사용
        //결과     :  0100 1110

        //layerMask |= (1 << 6);

        //2. 특정 레이어 해제 시키기 (원하는 것만 해제함 나머지는 남아있음)
        //layerMask &= ~(1 << n);
        //layerMask : 0110 1100
        //체크레이어 : 1011 1111
        // & 사용
        //결과       : 0010 1100

        //layerMask &= ~(1 << 6);

        //3. 특정 레이어 확인하기
        //layerMask : 0110 1100
        //체크레이어 : 0100 0000
        // & 사용
        //결과      : 0100 0000

        //bool isChecked = (layerMask & (1 << 6)) != 0;
        //Debug.Log(isChecked);

        layerMask.Check(6);
        layerMask.UnCheck(3);

        Debug.Log(layerMask.Contain(1));        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (layerMask.Contain(collision.gameObject.layer))
        {
            //이런식으로 사용할 수 있음~!
        }
    }
}
