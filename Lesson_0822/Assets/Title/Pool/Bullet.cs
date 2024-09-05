using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;

    //생성,삭제 / 풀패턴 둘다 사용
    //[SerializeField] float speed;

    private void Start()
    {
        //삭제(풀패턴에서 사용X)
        Destroy(gameObject, 5f);

        //반납으로 사용하지 않음을 적용해야 함
        //PooledObject에 만듦
    }
    //private void Update()
    //{
    //    //움직이는 게 위치이동 시켜주고 있는데 rigid가 있으면 속도로 움직여 주는 게 더 괜찮음 (속도를 날린다)
          //rigidbody를 사용하는 게 좋음
    //    transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

    //}

    //생성,삭제 / 풀패턴 둘다 사용
    //public void SetSpeed(float speed)
    //{
    //    this.speed = speed;
    //}

    public void SetSpeed(Vector3 speed)
    {
        rigid.velocity = speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //플레이어랑 부딪혔으면 플레이어를 공격하자
        //name, tag 사용하면됨
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("플레이어 공격");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("다른 물체와 충돌");
            Destroy(gameObject);
        }
    }
}
