using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    //충돌을 시작했을 때
    private void OnCollisionEnter(Collision collision)
    {
        //tag가 아니라 name으로 해도 됨 (tag가 더 빠름)
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("부딪히면 데미지를 줄게용~~!!");
        }
        
        //어떤 거랑 부딪혔는지 이름 출력
        //Debug.Log($"Enter: {collision.gameObject.name}");
    }

    //충돌 중일 때
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log($"Stay: {collision.gameObject.name}");
    }

    //충돌이 끝났을 때
    private void OnCollisionExit(Collision collision)
    {
       //Debug.Log($"Exit: {collision.gameObject.name}");
    }
}
