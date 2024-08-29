using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event_Test : MonoBehaviour
{
   // public event Action OnScream;
   
    //매개변수가 없는 것
    //public UnityEvent OnScream;
    
    
    [SerializeField] float screamVolume;
    
    //매개변수가 있는 것
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
        Debug.Log("플레이어가 소리지릅니다!!!");
        //매개변수가 없는 것
        //OnScream?.Invoke(); //이벤트 발생시키기 (?를 하면 null이면 안 함)

        //매개변수 있는 것
        OnScream1?.Invoke(screamVolume);
    }
}
