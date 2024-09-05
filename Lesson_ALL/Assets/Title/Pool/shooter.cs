using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    //Ǯ���Ͽ� ��� (�뿩, �ݳ�)
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
        //�����ؼ� ���
        Bullet bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        bullet.SetSpeed(bulletSpeed * muzzlePoint.forward);

        //�뿩�ؼ� ��� (Ǯ����)
        //PooledObject instance = bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
        //Bullet bullet = instance.GetComponent<Bullet>();
        //bullet.SetSpeed(bulletSpeed);
    }
}
