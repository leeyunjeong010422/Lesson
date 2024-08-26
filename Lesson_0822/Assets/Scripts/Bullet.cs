using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    private void Start()
    {
        //삭제에서 사용하지 않음!
        //Destroy(gameObject, 5f);

        //반납으로 사용하지 않음을 적용해야 함
        //PooledObject에 만듦
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
