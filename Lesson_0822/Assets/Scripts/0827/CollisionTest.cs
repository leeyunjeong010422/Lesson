using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    //�浹�� �������� ��
    private void OnCollisionEnter(Collision collision)
    {
        //tag�� �ƴ϶� name���� �ص� �� (tag�� �� ����)
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�ε����� �������� �ٰԿ�~~!!");
        }
        
        //� �Ŷ� �ε������� �̸� ���
        //Debug.Log($"Enter: {collision.gameObject.name}");
    }

    //�浹 ���� ��
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log($"Stay: {collision.gameObject.name}");
    }

    //�浹�� ������ ��
    private void OnCollisionExit(Collision collision)
    {
       //Debug.Log($"Exit: {collision.gameObject.name}");
    }
}
