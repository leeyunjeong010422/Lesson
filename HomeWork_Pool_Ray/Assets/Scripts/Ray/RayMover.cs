using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayMover : MonoBehaviour
{
    [SerializeField] Transform turretTransform;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float turretRotateSpeed;
    [Range(0f, 60f)]
    [SerializeField] float maxTurretVerticalAngle;

    [SerializeField] Transform muzzlePoint;

    private float turretVerticalAngle = 0f;

    //private int hits = 0; //ºÎµúÈù È½¼ö
    //[SerializeField] int hitGameOut = 5; //5¹ø ºÎµúÈ÷¸é °ÔÀÓ ³¡

    private void Update()
    {
        Move();
        RotateTurret();
    }

    private void Move()
    {
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

        turretVerticalAngle = Mathf.Clamp(turretVerticalAngle, -maxTurretVerticalAngle, 0);
        turretTransform.localRotation = Quaternion.Euler(turretVerticalAngle, turretTransform.localEulerAngles.y, 0f);
    }
}
