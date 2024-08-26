using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    [SerializeField] ObjectPool BulletPool;
    //[SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform Point;

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
        //�����ؼ� ���
        //Bullet bullet = Instantiate(bulletPrefab, Point.position, Point.rotation);
        //bullet.SetSpeed(bulletSpeed);

        //�뿩�ؼ� ���
        PooledObject instance = BulletPool.GetPool(Point.position, Point.rotation);
        Bullet bullet = instance.GetComponent<Bullet>();
        bullet.SetSpeed(bulletSpeed);
    }
}
