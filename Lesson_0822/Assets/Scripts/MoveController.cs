using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float rate;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir == Vector3.zero)
            return;
        
        //이동
        //Normalize: 어떤 방향으로든 똑같은 속도로 움직이기 위해
        //대각선 이동이 빠른 것을 방지하기 위해
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);

        //회전
        //오른쪽 보고 있음 오른쪽 회전, 왼쪽 보고 있으면 왼쪽 회전        
        //Quaternion lookDir = Quaternion.LookRotation(moveDir);
        //transform.rotation = lookDir;

        //순간적으로 확 도는 게 아니라 천천히 돈다!
        //Quaternion lookRot = Quaternion.LookRotation(moveDir);
        //transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, rate * Time.deltaTime);

        //일정속도로 회전가능!!
        Quaternion lookRot = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, rotateSpeed);
    }
}
