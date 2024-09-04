using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class New_PlayerController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distance;
    [SerializeField] float rate;

    [SerializeField] float mouseSensitivity;
    [SerializeField] float xAngle;
    [SerializeField] float yAngle;

    private void LateUpdate()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(1) == false)
            return;

        xAngle -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        yAngle += Input.GetAxis("Mouse X") * mouseSensitivity;

    }

    private void Move()
    {
        //기본실습
        transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);
        transform.position = target.position - transform.forward * distance;
        //return;

        //심화실습
        transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);

        if(Physics.Raycast(target.position, - transform.forward, out RaycastHit hit, distance))
        {
            Vector3 position = hit.point;
            transform.position = Vector3.Lerp(transform.position, position, rate * Time.deltaTime);
        }
        else
        {
            Vector3 position = target.position - transform.forward * distance;
            transform.position = Vector3.Lerp(transform.position, position, rate * Time.deltaTime);
        }
    }
}
