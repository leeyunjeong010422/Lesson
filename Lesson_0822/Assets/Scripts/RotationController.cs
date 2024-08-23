using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] float angle;
    [SerializeField] Transform target;

    private void Update()
    {

    }

    //������ ȸ���ϱ� (������)
    private void RotationRotate()
    {
        angle += rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    //������ ȸ���ϱ� (������)
    private void RotateRotate()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    //�������� �߽����� ȸ���ϱ�
    private void RotateAroundRote()
    {
        transform.RotateAround(target.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }

    //�������� �ٶ󺸵��� ȸ���ϱ�
    private void LookAtRotate()
    {
        transform.LookAt(target.position);
    }
}
