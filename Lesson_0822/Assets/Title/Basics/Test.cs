using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int potionCount;
    void Start()
    {
        Debug.Log("�κ��丮���� �������� Ȯ���Ѵ�.");
        Debug.Log("�κ��丮���� ������ ã�´�.");
        Debug.LogWarning($"������ ���� ���� ������ �����ϼ���!! ���� ����: {potionCount}");

        if (potionCount > 0)
        {
            potionCount--;
            Debug.Log("�� ������ ����Ѵ�.");
        }
        else
        {
            Debug.LogError("������ �����ϴ�.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
