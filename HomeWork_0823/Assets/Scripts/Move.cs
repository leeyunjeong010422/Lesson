using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed; // 1�ʿ� 360�� ȸ��

    private void Update()
    {
        float x = Input.GetAxis("Horizontal"); // �¿� �Է�
        float z = Input.GetAxis("Vertical");   // �յ� �Է�

        // �Էµ� �������� ������
        Vector3 moveDir = new Vector3(-z, 0, x);
        if (moveDir == Vector3.zero)
            return;
        // �̵� ó��
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);

        // ȸ�� ó��
        Quaternion lookRot = Quaternion.LookRotation(moveDir);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, rotateSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, rotateSpeed * Time.deltaTime);

    }
}
