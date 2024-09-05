using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerTester : MonoBehaviour
{
    [System.Flags]
    enum MonsterType
    {
        Fire = 1 << 0, 
        Water = 1 << 1, 
        Grass = 1 << 2, 
        Electric = 1 << 3
    }

    [SerializeField] MonsterType monsterType;
    [SerializeField] LayerMask layerMask;

    private void Start()
    {
        //Debug.Log(layerMask.value);

        //1 << n ���ָ� n��° �ڸ����� üũ �� �� ���
        //layerMask = 1 << 6;

        //1. Ư�� ���̾� üũ ��Ű�� (���� �� �״�� ��������)
        //layerMask |= 1 << n;
        //layerMask : 0000 1110
        //üũ���̾� : 0100 0000
        // | ���
        //���     :  0100 1110

        //layerMask |= (1 << 6);

        //2. Ư�� ���̾� ���� ��Ű�� (���ϴ� �͸� ������ �������� ��������)
        //layerMask &= ~(1 << n);
        //layerMask : 0110 1100
        //üũ���̾� : 1011 1111
        // & ���
        //���       : 0010 1100

        //layerMask &= ~(1 << 6);

        //3. Ư�� ���̾� Ȯ���ϱ�
        //layerMask : 0110 1100
        //üũ���̾� : 0100 0000
        // & ���
        //���      : 0100 0000

        //bool isChecked = (layerMask & (1 << 6)) != 0;
        //Debug.Log(isChecked);

        layerMask.Check(6);
        layerMask.UnCheck(3);

        Debug.Log(layerMask.Contain(1));        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (layerMask.Contain(collision.gameObject.layer))
        {
            //�̷������� ����� �� ����~!
        }
    }
}
