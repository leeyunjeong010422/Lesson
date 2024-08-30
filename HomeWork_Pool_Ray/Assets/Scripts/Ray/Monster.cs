using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] Transform target;

    private void Start()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    private void Update()
    {
        // 타겟한테 이동
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RayMover rayMover = collision.gameObject.GetComponent<RayMover>();
            Destroy(gameObject);
        }
    }
}
