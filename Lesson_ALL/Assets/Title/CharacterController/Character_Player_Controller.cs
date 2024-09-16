using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Player_Controller : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed;

    private float ySpeed;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0, z).normalized;

        controller.Move(dir * speed * Time.deltaTime);

        //땅으로 레이캐스트를 쏴서 하는 게 나음 controller.isGrounded 별로 안 좋은 성능임
        if (controller.isGrounded == false )
        {
            ySpeed -= Physics.gravity.y * Time.deltaTime;
            controller.Move(Vector3.down * ySpeed * Time.deltaTime);
        }
        else
        {
            ySpeed = 0f;
        }
    }
}
