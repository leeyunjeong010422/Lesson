using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SolarSystem : MonoBehaviour
{
    [SerializeField] float revolutionSpeed; //공전속도 (클수록 빨라짐)
    [SerializeField] float rotationSpeed; //자전속도 (클수록 빨라짐)
    [SerializeField] Vector3 revolutionDirection; // 공전 방향
    [SerializeField] Vector3 rotationDirection;  // 자전 방향
    [SerializeField] float angle; //자전 각도 설정
    [SerializeField] Transform target; //중심(target: 태양)

    private void Update()
    {
        // 공전
        transform.RotateAround(target.position, revolutionDirection.normalized, revolutionSpeed * Time.deltaTime);

        // 자전
        transform.Rotate(rotationDirection.normalized, rotationSpeed * Time.deltaTime);
    }
}
