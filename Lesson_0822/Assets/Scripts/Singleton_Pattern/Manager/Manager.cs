using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameManager�� �߰����� ���߾ �ڵ�� �ڵ� �߰�
public static class Manager
{
    public static GameManager Instance { get { return GameManager.Instance; } }
    //Ư�� ��Ʈ����Ʈ
    //���� �������ڸ��� ������ ���� ȣ��Ǵ� �Լ��� ����
    //���� ���� ���� ����� (���� �����ϸ� �ٸ� �ͺ��� ���� ���� ȣ��)
    //�뵵: ���� ����, �̱��� ����, ��
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        //���� ���� ����

        //�̱��� ����
        GameManager.Create();
    }
}
