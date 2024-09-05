using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event_Test : MonoBehaviour
{
   // public event Action OnScream;
   
    //�Ű������� ���� ��
    //public UnityEvent OnScream;
    
    
    [SerializeField] float screamVolume;
    
    //�Ű������� �ִ� ��
    public UnityEvent<float> OnScream1;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Scream();
        }
    }

    private void Scream()
    {
        Debug.Log("�÷��̾ �Ҹ������ϴ�!!!");
        //�Ű������� ���� ��
        //OnScream?.Invoke(); //�̺�Ʈ �߻���Ű�� (?�� �ϸ� null�̸� �� ��)

        //�Ű����� �ִ� ��
        OnScream1?.Invoke(screamVolume);
    }
}
