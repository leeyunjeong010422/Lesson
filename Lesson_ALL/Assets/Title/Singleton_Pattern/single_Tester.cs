using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class single_Tester : MonoBehaviour
{  
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            //���� ��𿡼����� ���ӸŴ����� ���� �ʹٸ� Instance�� ������ ����� �� ����
            GameManager.Instance.score++;

            //�̷������� ��� ����!
            //�巡�׾ص�� ���� �� �� �ص� ��
            //InventoryManager.Instance.AddIntem();
        }
    }
}