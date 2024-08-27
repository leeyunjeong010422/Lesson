using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTest : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float power;

    private void Start()
    {

    }

    private void Update()
    {
        //GetKeyDown�� ������ �� �� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�����ϱ�(Force: ���������� �б�, Impulse: ��(������)) - ���� ��� (���ſ�� �� �и�)
            //Acceleration, VelocityChange - ���� ��� X
            rigid.AddForce(Vector3.up * power, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //ȸ�����ϱ�
            rigid.AddTorque(Vector3.up * power, ForceMode.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            //�ӵ��ٲپ��ֱ�
            rigid.velocity = new Vector3(1, 0, 1);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            //ȸ���ӵ��ٲپ��ֱ�
            rigid.angularVelocity = new Vector3(1, 0, 1);
        }
    }
}
