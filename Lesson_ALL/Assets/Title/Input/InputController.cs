using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] PlayerInput input;

    [SerializeField] float power;
    [SerializeField] float jumpPower;

    private void Update()
    {
        Vector2 move = input.actions["Move"].ReadValue<Vector2>();
        Vector3 dir = new Vector3(move.x, 0, move.y);
        rigid.AddForce(dir * power, ForceMode.Force );
        //rigid.velocity = dir * power;

        //bool jump = input.actions["Jump"].IsPressed(); //GetKey��� �����ϸ��
        //bool jump = input.actions["Jump"].WasPressedThisFrame(); //GetKeyDown���� �����ϸ��
        bool jump = input.actions["Jump"].WasReleasedThisFrame(); //GetKeyUp���� �����ϸ��

        if (jump )
        {
           rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse );
        }
    }
}
