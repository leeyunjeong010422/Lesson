using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTaker : MonoBehaviour
{
    //[SerializeField] Event_Test terster;
    [SerializeField] Rigidbody rigid;

    //private void OnEnable()
    //{
    //    //�̺�Ʈ�� �߻������� �� ���� ����
    //    terster.OnScream += Jump;
    //}

    //private void OnDisable()
    //{
    //    terster.OnScream -= Jump;
    //}

    //�Ű������� ���� ��
    //public void Jump()
    //{
    //    rigid.AddForce(Vector3.up * 8f, ForceMode.Impulse);
    //}

    //�Ű������� �ִ� ��
    public void Jump(float power)
    {
        rigid.AddForce(Vector3.up * 8f, ForceMode.Impulse);
    }
}
