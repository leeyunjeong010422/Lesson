using UnityEngine;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab_1;
    [SerializeField] Bullet bulletPrefab_2;
    [SerializeField] Bullet bulletPrefab_3;

    [SerializeField] Transform muzzlePoint;

    [Range(1, 20)]
    [SerializeField] float bulletSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Fire(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Fire(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Fire(3);
        }
    }

    public void Fire(int bulletType)
    {
        Bullet bullets = null;

        switch (bulletType)
        {
            case 1:
                bullets = bulletPrefab_1;
                break;
            case 2:
                bullets = bulletPrefab_2;
                break;
            case 3:
                bullets = bulletPrefab_3;
                break;
        }

        if (bullets != null)
        {
            Bullet bullet = Instantiate(bullets, muzzlePoint.position, muzzlePoint.rotation);
            bullet.SetSpeed(bulletSpeed * muzzlePoint.forward);
        }
    }
}
