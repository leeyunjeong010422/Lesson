using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Blade : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform rotatetarget;
    [SerializeField] float rotateSpeed; //ȸ�� �ӵ�
    [SerializeField] float curRotateSpeed; //���� ȸ�� �ӵ�
    [SerializeField] float maxRotateSpeed; //�ִ� ȸ�� �ӵ�
    [SerializeField] float liftRotateSpeed; //�̷� �� �� ȸ�� �ӵ�
    [SerializeField] float liftSpeed; //��� �ӵ� (+�ϰ�)

    private void Update()
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
