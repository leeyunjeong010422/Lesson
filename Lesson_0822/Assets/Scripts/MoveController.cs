using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float rate;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir == Vector3.zero)
            return;
        
        //�̵�
        //Normalize: � �������ε� �Ȱ��� �ӵ��� �����̱� ����
        //�밢�� �̵��� ���� ���� �����ϱ� ����
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);

        //ȸ��
        //������ ���� ���� ������ ȸ��, ���� ���� ������ ���� ȸ��        
        //Quaternion lookDir = Quaternion.LookRotation(moveDir);
        //transform.rotation = lookDir;

        //���������� Ȯ ���� �� �ƴ϶� õõ�� ����!
        //Quaternion lookRot = Quaternion.LookRotation(moveDir);
        //transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, rate * Time.deltaTime);

        //�����ӵ��� ȸ������!!
        Quaternion lookRot = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, rotateSpeed);
    }
}
