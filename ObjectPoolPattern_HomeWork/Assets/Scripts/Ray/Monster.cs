using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //몬스터 리스폰 구현 X
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] Transform target;

    private void Start()
    {
        transform.LookAt(target.position);

        rb.velocity = transform.forward * speed;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Tank")
        {
            RayMover rayMover = collision.gameObject.GetComponent<RayMover>();
            Destroy(gameObject);
        }
    }
}
