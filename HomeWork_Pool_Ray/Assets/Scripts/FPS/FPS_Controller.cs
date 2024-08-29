using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FPS_Controller : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] float rotateSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] public int attack;

    [SerializeField] Target target;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Move();
        Look();

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * x * moveSpeed * Time.deltaTime);
    }
    private void Look()
    {
        float x = Input.GetAxis("Mouse X"); //마우스 좌우 움직임량
        float y = Input.GetAxis("Mouse Y"); //마우스 위아래 움직임량

        //좌우
        transform.Rotate(Vector3.up, rotateSpeed * x * Time.deltaTime);

        //위아래 (카메라만 - 플레이어가 넘어질 수 있음)
        camTransform.Rotate(Vector3.right, rotateSpeed * -y * Time.deltaTime);
    }

    private void Fire()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit))
        {
            GameObject instance = hit.collider.gameObject;
            Target target = instance.GetComponent<Target>();

            if (target != null)
            {
                target.TakeHit(attack);
            }
        }
    }
}
