using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //Vector3 dir = new Vector3(x, 0 ,z);
        //if(dir == Vector3.zero)
        //    return;

        //����ī�޶� ������ �޾ƿ���
        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
        Vector3 right = Camera.main.transform.TransformDirection(Vector3.right);

        //y�� �����̴� �� ����
        forward.y = 0;
        right.y = 0;

        Vector3 moveDir = (forward * z + right * x).normalized;

        //transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        //transform.rotation = Quaternion.LookRotation(dir);

        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);

        // ȸ�� ó��
        if (moveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
    }
}
