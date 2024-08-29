using UnityEngine;

public class Shooter : MonoBehaviour
{
    //1,2,3 ���� �߻��ϴ� �� �˰� �߸� ������� ��ũ��Ʈ�ε� ����� �ƽ����� �׳� ���ѰԿ�...

    [SerializeField] Bullet bulletPrefab_1;
    [SerializeField] Bullet bulletPrefab_2;
    [SerializeField] Bullet bulletPrefab_3;

    [SerializeField] Transform muzzlePoint;

    [SerializeField] float bulletSpeed; //�⺻���ǵ�
    [SerializeField] float maxBulletSpeed; //�ִ뽺�ǵ�
    [SerializeField] float changeBulletSpeed; //�� ������ �� ������ ���ǵ� (��������� ������ ������)

    private float curBulletSpeed; //���罺�ǵ�
    private bool isGetKey; //GetKey�� ���ȴ���
    private bool nextFire; //���� �߻�

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
