using System.Collections;
using UnityEngine;

public class CoFPS_Controller : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] float rotateSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] public int attack;

    [SerializeField] Co_Target target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] float fireRate;
    [SerializeField] int maxAmmo = 30;

    private int currentAmmo;
    private bool isFiring;
    private bool isReloading;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        Move();
        Look();

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {         
            StartCoroutine(Reload());
        }

        if (Input.GetMouseButtonDown(0) && !isFiring && !isReloading && currentAmmo > 0)
        {
            StartCoroutine(Fire());
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

    private IEnumerator Fire()
    {
        isFiring = true;

        while (Input.GetMouseButton(0) && currentAmmo > 0)
        {
            currentAmmo--;
            if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit))
            {
                GameObject instance = hit.collider.gameObject;
                Co_Target target = instance.GetComponent<Co_Target>();

                if (target != null)
                {
                    target.TakeHit(attack);
                }
            }

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // �Ѿ˿� Rigidbody�� �ִ��� Ȯ���ϰ�, ������ �ӵ� ����
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = -bulletSpawnPoint.right * bulletSpeed;
            }

            yield return new WaitForSeconds(fireRate);
        }
        if (currentAmmo <= 0)
        {
            Debug.Log("������ �ʿ��մϴ�!");
        }

        isFiring = false;
    }

    //2�� �ڿ� �����ϱ�
    private IEnumerator Reload()
    {      
        isReloading = true;
        yield return new WaitForSeconds(2f);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
