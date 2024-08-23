using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���̰̽��� ���� ������
public class Move2_Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //���� ���� (�յ� z)
        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime, Space.Self);

        //ȸ�� (�¿� x)
        transform.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime);
    }
}
