using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField] RayBullet bulletPrefab_1;
    [SerializeField] RayBullet bulletPrefab_2;

    [SerializeField] Transform muzzlePoint;

    [SerializeField] float bulletSpeed;
    [SerializeField] int damege;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            int bulletType = 0;
            if (Input.GetKeyDown(KeyCode.Alpha1))
                bulletType = 1;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                bulletType = 2;

            Fire(bulletType);
        }
    }

    public void Fire(int bulletType)
    {
        RayBullet bulletPrefab = null;

        switch (bulletType)
        {
            case 1:
                bulletPrefab = bulletPrefab_1;
                break;
            case 2:
                bulletPrefab = bulletPrefab_2;
                break;
        }

        if (bulletPrefab != null)
        {
            RayBullet bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Vector3 speed = muzzlePoint.forward * bulletSpeed;
            bullet.SetSpeed(speed);
            bullet.SetDamege(damege);
        }
    }
}
