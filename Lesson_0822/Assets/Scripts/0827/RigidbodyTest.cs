using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTest : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float power;

    private void Start()
    {

    }

    private void Update()
    {
        //GetKeyDown은 눌렀을 때 한 번만
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //힘가하기(Force: 지속적으로 밀기, Impulse: 툭(때리기)) - 무게 고려 (무거우면 덜 밀림)
            //Acceleration, VelocityChange - 무게 고려 X
            rigid.AddForce(Vector3.up * power, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //회전가하기
            rigid.AddTorque(Vector3.up * power, ForceMode.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            //속도바꾸어주기
            rigid.velocity = new Vector3(1, 0, 1);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            //회전속도바꾸어주기
            rigid.angularVelocity = new Vector3(1, 0, 1);
        }
    }
}
