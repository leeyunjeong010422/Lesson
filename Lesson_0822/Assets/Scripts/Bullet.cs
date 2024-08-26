using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    private void Start()
    {
        //�������� ������� ����!
        //Destroy(gameObject, 5f);

        //�ݳ����� ������� ������ �����ؾ� ��
        //PooledObject�� ����
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