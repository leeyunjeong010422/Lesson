using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;

    //����,���� / Ǯ���� �Ѵ� ���
    //[SerializeField] float speed;

    private void Start()
    {
        //����(Ǯ���Ͽ��� ���X)
        Destroy(gameObject, 5f);

        //�ݳ����� ������� ������ �����ؾ� ��
        //PooledObject�� ����
    }
    //private void Update()
    //{
    //    //�����̴� �� ��ġ�̵� �����ְ� �ִµ� rigid�� ������ �ӵ��� ������ �ִ� �� �� ������ (�ӵ��� ������)
          //rigidbody�� ����ϴ� �� ����
    //    transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

    //}

    //����,���� / Ǯ���� �Ѵ� ���
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
        //�÷��̾�� �ε������� �÷��̾ ��������
        //name, tag ����ϸ��
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�÷��̾� ����");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("�ٸ� ��ü�� �浹");
            Destroy(gameObject);
        }
    }
}
