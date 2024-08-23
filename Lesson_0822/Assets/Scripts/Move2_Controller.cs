using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//레이싱게임 같은 움직임
public class Move2_Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //전진 후진 (앞뒤 z)
        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime, Space.Self);

        //회전 (좌우 x)
        transform.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime);
    }
}
