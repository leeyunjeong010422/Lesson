using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�߰�����
//��ȭ ���� 1. ���� ��� �߰�
//���Ͱ� �ʵ忡 ������ ��, ��ũ �������� �̵��ؾ� �Ѵ�.
//��ũ�� ���Ͱ� �����ؼ� 2�ʰ� ����ִٸ� �÷��̾ �ǰݵ� ������ �����Ѵ�
//2�ʰ� ������ �� ������ ���, �ٽ� ����� ���� ó������ 2�ʸ� ī�����Ѵ�
//��ũ�� 5ȸ �ǰݵ� ���, �ֿܼ� ������ ����Ǿ��ٴ� �ؽ�Ʈ�� �Բ� ��ũ ������Ʈ�� �Ҹ��Ų��
//Tip : �� ���ο� �����ϴ� ������Ʈ�� �������� Ž���ϰ� ���� ��� ��ũ�� �����غ� �� �ֽ��ϴ�
//�� ���� �󿡼��� �������� ���͸� �������� �ʾƵ� �ǹǷ� Find�� ������� �ʾƵ� ó���� �� �ֽ��ϴ�.

//��ȭ ���� 2. ��ũ ��� �߰�
//�⺻ ���� 1 ������� �������� �Ʒ� ����� �߰��ϼ���
//����Ű 3������ ĳ�� ���� �����Ѵ�
//ĳ�� ��� ���Խ� FPS �������� ����Ǹ�, ��ũ�� �̵��� �Ұ���������.
//ĳ�� ��忡���� ���콺�� �����ӿ� ���� ȭ���� ȸ���ؾ� �Ѵ�.
//��, ������ ���� ���� ������ �����ؾ� �Ѵ�.
//ȭ�� �� ����� ���Ͱ� �����ϴ� ��쿡�� ���콺 ��Ŭ������ ĳ���� �߻��� �� �ִ� (���ݷ� 3)
//ĳ���� �߷��� ������� �ʴ´�
//ĳ�� źȯ�� ������ ������ ���, ��ü 4 ���� ���� �ٸ� ���Ϳ� ���÷��� �������� �ο��Ѵ�. (���ݷ� 2)
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
        // Ÿ������ �̵�
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
