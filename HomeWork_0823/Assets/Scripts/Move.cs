using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed; // 1초에 360도 회전

    private void Update()
    {
        float x = Input.GetAxis("Horizontal"); // 좌우 입력
        float z = Input.GetAxis("Vertical");   // 앞뒤 입력

        // 입력된 방향으로 움직임
        Vector3 moveDir = new Vector3(-z, 0, x);
        if (moveDir == Vector3.zero)
            return;
        // 이동 처리
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);

        // 회전 처리
        Quaternion lookRot = Quaternion.LookRotation(moveDir);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, rotateSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, rotateSpeed * Time.deltaTime);

    }
}
