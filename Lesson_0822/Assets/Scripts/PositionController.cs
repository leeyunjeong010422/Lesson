using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float moveSpeed;

    [SerializeField] float rate;


    private void Update()
    {

    }

    //�������� �̵��ϱ�
    private void PositionMove()
    {
        //�����Ӱ� ������� �Ȱ��� �ӵ��� �����̰� �ϰ� ���� ��
        //1�� ���� x ��ŭ ���� ������ x * Time.deltaTime
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime; // 1/s�� �����ϸ��!!
    }

    //�������� �̵��ϱ�
    private void TranslateMove()
    {
        //�̵���Ű�� ���
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    //�������� �̵��ϱ� (�����ӵ�)
    private void MoveTowardsMove()
    {
        //��ǥ�������� �̵���Ű��
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    //�������� �̵��ϱ� (ó���� ������ ���� ������)
    private void LerpMove()
    {
        //�ָ� ������ ���� �����̰� ������ �ü��� �ӵ��� ������
        transform.position = Vector3.Lerp(transform.position, target.position, rate * Time.deltaTime);
    }
}
