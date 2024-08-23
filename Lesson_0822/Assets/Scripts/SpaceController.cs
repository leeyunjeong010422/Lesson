using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self); //�ڱⰡ �����ִ� �������� �̵�
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World); //���踦 �߽�����

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}
