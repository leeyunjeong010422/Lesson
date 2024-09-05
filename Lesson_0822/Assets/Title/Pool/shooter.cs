using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    //풀패턴에 사용 (대여, 반납)
    //[SerializeField] ObjectPool bulletPool;
    
    [SerializeField] Bullet bulletPrefab;
    
    [SerializeField] Transform muzzlePoint;

    [Range(1,10)]
    [SerializeField] float bulletSpeed;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    public void Fire()
    {
        //생성해서 사용
        Bullet bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        bullet.SetSpeed(bulletSpeed * muzzlePoint.forward);

        //대여해서 사용 (풀패턴)
        //PooledObject instance = bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
        //Bullet bullet = instance.GetComponent<Bullet>();
        //bullet.SetSpeed(bulletSpeed);
    }
}
