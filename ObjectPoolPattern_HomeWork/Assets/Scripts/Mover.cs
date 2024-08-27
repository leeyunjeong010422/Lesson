using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform turretTransform;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float turretRotateSpeed;
    [Range(0f, 80f)]
    [SerializeField] float maxTurretVerticalAngle;

    private float turretVerticalAngle = 0f;

    private void Update()
    {
        Move();
        RotateTurret();
    }

    private void Move()
    {
        //기존 Horizontal과 Vertical은 AWSD 뿐만 아니라 방향키도 포함하기 때문에 새로운 Input Manager 생성
        float x = Input.GetAxis("Tank_Horizontal");
        float z = Input.GetAxis("Tank_Vertical");

        Vector3 moveDir = new Vector3(x, 0, z).normalized;
        if (moveDir != Vector3.zero)
        {
            transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
            Quaternion lookRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, rotateSpeed);
        }
    }

    private void RotateTurret()
    {
        float horizontal = Input.GetAxis("Turret_Horizontal");
        turretTransform.Rotate(Vector3.up, horizontal * turretRotateSpeed * Time.deltaTime);

        float vertical = Input.GetAxis("Turret_Vertical");
        turretVerticalAngle -= vertical * turretRotateSpeed * Time.deltaTime;

        turretVerticalAngle = Mathf.Clamp(turretVerticalAngle, -maxTurretVerticalAngle, maxTurretVerticalAngle);
        turretTransform.localRotation = Quaternion.Euler(turretVerticalAngle, turretTransform.localEulerAngles.y, 0f);
    }
}
