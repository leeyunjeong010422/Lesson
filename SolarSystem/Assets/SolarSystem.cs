using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SolarSystem : MonoBehaviour
{
    [SerializeField] float revolutionSpeed; //�����ӵ� (Ŭ���� ������)
    [SerializeField] float rotationSpeed; //�����ӵ� (Ŭ���� ������)
    [SerializeField] Vector3 revolutionDirection; // ���� ����
    [SerializeField] Vector3 rotationDirection;  // ���� ����
    [SerializeField] float angle; //���� ���� ����
    [SerializeField] Transform target; //�߽�(target: �¾�)

    private void Update()
    {
        // ����
        transform.RotateAround(target.position, revolutionDirection.normalized, revolutionSpeed * Time.deltaTime);

        // ����
        transform.Rotate(rotationDirection.normalized, rotationSpeed * Time.deltaTime);
    }
}
