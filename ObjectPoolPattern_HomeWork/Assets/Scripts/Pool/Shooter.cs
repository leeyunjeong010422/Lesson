using UnityEngine;

public class Shooter : MonoBehaviour
{
    //1,2,3 으로 발사하는 줄 알고 잘못 만들었던 스크립트인데 지우기 아쉬워서 그냥 냅둘게요...

    [SerializeField] Bullet bulletPrefab_1;
    [SerializeField] Bullet bulletPrefab_2;
    [SerializeField] Bullet bulletPrefab_3;

    [SerializeField] Transform muzzlePoint;

    [SerializeField] float bulletSpeed; //기본스피드
    [SerializeField] float maxBulletSpeed; //최대스피드
    [SerializeField] float changeBulletSpeed; //꾹 눌렀을 때 증가할 스피드 (어느정도씩 증가할 것인지)

    private float curBulletSpeed; //현재스피드
    private bool isGetKey; //GetKey가 눌렸는지
    private bool nextFire; //다음 발사

    private void Update()
    {

        if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3))
        {
            isGetKey = true;
            curBulletSpeed += changeBulletSpeed * Time.deltaTime;
            curBulletSpeed = Mathf.Clamp(curBulletSpeed, bulletSpeed, maxBulletSpeed);

        }
        else
        {
            isGetKey = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (nextFire)
            {
                int bulletType = 0;
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    bulletType = 1;
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                    bulletType = 2;
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                    bulletType = 3;

                Fire(bulletType);
            }
            else
            {
                nextFire = true;
            }
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

            float finalSpeed = isGetKey ? curBulletSpeed : bulletSpeed;
            //bullet.SetSpeed(muzzlePoint.forward * finalSpeed);

            curBulletSpeed = bulletSpeed;
            nextFire = false;
        }
    }
}
