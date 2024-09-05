using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self); //자기가 보고있는 방향으로 이동
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World); //세계를 중심으로

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}
