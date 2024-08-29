using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTaker : MonoBehaviour
{
    //[SerializeField] Event_Test terster;
    [SerializeField] Rigidbody rigid;

    //private void OnEnable()
    //{
    //    //이벤트가 발생시켰을 때 점프 진행
    //    terster.OnScream += Jump;
    //}

    //private void OnDisable()
    //{
    //    terster.OnScream -= Jump;
    //}

    //매개변수가 없는 것
    //public void Jump()
    //{
    //    rigid.AddForce(Vector3.up * 8f, ForceMode.Impulse);
    //}

    //매개변수가 있는 것
    public void Jump(float power)
    {
        rigid.AddForce(Vector3.up * 8f, ForceMode.Impulse);
    }
}
