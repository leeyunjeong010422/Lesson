using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform turretTransform;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float turretRotateSpeed;
    [Range(0f, 80f)]
    [SerializeField] float maxTurretVerticalAngle;

    [SerializeField] Transform muzzlePoint;

    [SerializeField] ObjectPool[] bulletPool;
    private ObjectPool curBulletPool;

    private float turretVerticalAngle = 0f;

    private void Awake()
    {
        curBulletPool = bulletPool[0];
    }

    private void Update()
    {
        Move();
        RotateTurret();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        //총알 변경이 안되는데 도저히 왜 변경이 안되는지 모르겠습니다...
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapBullet(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapBullet(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwapBullet(2);
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Tank_Horizontal");
        float z = Input.GetAxis("Tank_Vertical");

        Vector3 moveDir = new Vector3(x, 0, z).normalized;
        if (moveDir != Vector3.zero)
        {
            transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
            Quaternion lookRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, rotateSpeed);
        }
    }

    private void RotateTurret()
    {
        float horizontal = Input.GetAxis("Turret_Horizontal");
        turretTransform.Rotate(Vector3.up, horizontal * turretRotateSpeed * Time.deltaTime);

        float vertical = Input.GetAxis("Turret_Vertical");
        turretVerticalAngle -= vertical * turretRotateSpeed * Time.deltaTime;

        turretVerticalAngle = Mathf.Clamp(turretVerticalAngle, -maxTurretVerticalAngle, maxTurretVerticalAngle);
        turretTransform.localRotation = Quaternion.Euler(turretVerticalAngle, turretTransform.localEulerAngles.y, 0f);
    }

    private void Fire()
    {
        curBulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);

    }

    private void SwapBullet(int index)
    {
        curBulletPool = bulletPool[index];
    }
}
