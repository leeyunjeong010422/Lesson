using System.Collections;
using UnityEngine;

//�߰�����
//��ȭ ���� 3. ����ź �����ϱ�
//�⺻ ���� 2 ����� ȯ�濡�� ����ź�� �߰� �����ϼ���
//����ź�� Capsule�� ����� �����Ѵ�.
//�÷��̾�� ����Ű 1�� ������ �Ϲ� �ѱ�, 2�� ������ ����ź ��ô ���� ����ȴ�
//��尡 ����Ǿ ȭ�鿡 �ѱ�� �״�� ��Ÿ����
//����ź ��ô ����� ��� ���콺 ��Ŭ�� �ð��� ����� ������ ����ź�� ��ô�Ѵ�.
//�� ��, �ִ� ���� ũ��� �����Ӱ� �����ϵ�, �ν����Ϳ��� ������ �� �־�� �Ѵ�.
//����ź�� �ٴڿ� ���� �� 2�� ����� ���� ������ ������ ����Ű��, ���� ���� ���� ���Ͱ� �ִ� ��� �ǰ��������� ó���Ѵ�. (���ݷ� 3)
//���� ����Ʈ�� �������� �ʴ´�.
//������ ����Ų ���, ����ź ������Ʈ�� �������
public class FPS_Controller : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] float rotateSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] public int attack;

    [SerializeField] Target target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] float fireRate;
    [SerializeField] int maxAmmo = 30;

    private int currentAmmo;
    private bool isFiring;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        Move();
        Look();

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * x * moveSpeed * Time.deltaTime);
    }
    private void Look()
    {
        float x = Input.GetAxis("Mouse X"); //���콺 �¿� �����ӷ�
        float y = Input.GetAxis("Mouse Y"); //���콺 ���Ʒ� �����ӷ�

        //�¿�
        transform.Rotate(Vector3.up, rotateSpeed * x * Time.deltaTime);

        //���Ʒ� (ī�޶� - �÷��̾ �Ѿ��� �� ����)
        camTransform.Rotate(Vector3.right, rotateSpeed * -y * Time.deltaTime);
    }

    private void Fire()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit))
        {
            GameObject instance = hit.collider.gameObject;
            Target target = instance.GetComponent<Target>();

            if (target != null)
            {
                target.TakeHit(attack);
            }
        }
    }
}
