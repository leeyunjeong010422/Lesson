using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform rotatetarget;
    [SerializeField] float rotateSpeed; //ȸ�� �ӵ�
    [SerializeField] float curRotateSpeed; //���� ȸ�� �ӵ�
    [SerializeField] float maxRotateSpeed; //�ִ� ȸ�� �ӵ�
    [SerializeField] float liftRotateSpeed; //�̷� �� �� ȸ�� �ӵ�
    [SerializeField] float liftSpeed; //��� �ӵ� (+�ϰ�)
    [SerializeField] float fuel = 100; //����
    [SerializeField] float fuelDecrease; //���ᰨ�ҷ�

    [SerializeField] Rigidbody missile;
    [SerializeField] Rigidbody missileRigidbody;
    [SerializeField] Transform missileSpawnPoint; //�̻��� �߻� ��ġ
    [SerializeField] float missileSpeed; //�̻��� �ӵ�
    [SerializeField] float missileFireRate; //�̻��� ���� �ֱ�
    [SerializeField] int maxMissile = 3; //�ִ� �̻��� �� 3��
    private float missileFireCoolTime; //�̻��� ������Ÿ��
    private float missileCount; //�����ϴ� �̻��� ��



    private void Update()
    {
        //���ᰡ ���� ��
        if (fuel > 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //�����̽�Ű�� ������ ������ ȸ�� �ӵ� ����
                //���� �ӵ��� ȸ�� �ӵ��� ����
                curRotateSpeed += rotateSpeed * Time.deltaTime;
            }
            else
            {
                //�����̽��ٸ� ���� ȸ�� �ӵ� ����
                //���� �ӵ��� ȸ�� �ӵ��� ��
                curRotateSpeed -= rotateSpeed * Time.deltaTime;
            }

            //�ϴÿ� ������ �� �ð��� ���� ���� ����
            if (curRotateSpeed >= liftRotateSpeed && target.position.y > 0)
            {
                fuel -= fuelDecrease * Time.deltaTime;
                fuel = Mathf.Clamp(fuel, 0, 100);
            }
        }
        else
        {
            curRotateSpeed -= rotateSpeed * Time.deltaTime;
        }

        //ȸ�� �ӵ� �����ϱ�
        //�������Ʈ: https://asix.tistory.com/3
        //Mathf.Clamp �Լ� ��� --> float value���� float min(�ּҰ�)�� float max(�ִ밪)���̿� �ְ� ���ִ� �Լ�
        curRotateSpeed = Mathf.Clamp(curRotateSpeed, 0, maxRotateSpeed);

        //�����̽� �ٸ� ���� �� ���� ȸ��
        transform.RotateAround(rotatetarget.position, Vector3.up, curRotateSpeed * Time.deltaTime);

        if (curRotateSpeed >= liftRotateSpeed) //ȸ���ӵ��� �̷��ӵ����� ũ��
        {
            //�︮���� ���
            target.position += Vector3.up * liftSpeed * Time.deltaTime;

        }
        else
        {
            //�ϰ�
            target.position -= Vector3.up * liftSpeed * Time.deltaTime;
        }

        //�︮���� ���� ���� 0~50
        target.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, 0, 50), target.position.z);

        StartMissileFire();

    }

    private void StartMissileFire()
    {
        if (curRotateSpeed >= liftRotateSpeed)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0) && missileFireCoolTime <= 0 && missileCount < maxMissile)
            {
                FireMissile();
                missileFireCoolTime = missileFireRate;
            }

            if (missileFireCoolTime > 0)
            {
                missileFireCoolTime -= Time.deltaTime;
            }
        }
    }

    private void FireMissile()
    {
        missileRigidbody = Instantiate(missile, missileSpawnPoint.position, missileSpawnPoint.rotation);
        missileRigidbody.AddForce(Vector3.forward * 10, ForceMode.Impulse);
        //Rigidbody rigid = missileobject.GetComponent<Rigidbody>();

        if (rigid != null)
        {
            rigid.velocity = missileSpawnPoint.forward * missileSpeed;
        }

        missileCount++;
        Destroy(missileobject, 4f);
    }
}
