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
    [SerializeField] float fuelDecrease = 15; //���ᰨ�ҷ�

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
        }
    }
