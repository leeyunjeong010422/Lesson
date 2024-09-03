using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //찾다가 나온 건데 벽근처로 가면 오브젝트 투명화 시키기 이게 더 좋은 방법 같다!!
    //https://daekyoulibrary.tistory.com/entry/Charon-8-%ED%94%8C%EB%A0%88%EC%9D%B4%EC%96%B4%EC%99%80-%EC%B9%B4%EB%A9%94%EB%9D%BC-%EC%82%AC%EC%9D%B4%EC%9D%98-%EC%98%A4%EB%B8%8C%EC%A0%9D%ED%8A%B8-%ED%88%AC%EB%AA%85%ED%99%94%ED%95%98%EA%B8%B0

    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] float rotationSpeed; //움직임에 따라 카메라를 회전시킬 각도

    private float currentY; //현재 Y축 회전 각도
    private float currentX; //현재 X축 회전 각도

    private void Start()
    {
        if (playerTransform == null)
        {
            GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
            playerTransform = playerGameObject.transform;
        }
        else
        {
            Debug.LogWarning("플레이어가 없음");
        }

        //회전값 초기 설정
        currentY = transform.eulerAngles.y;
        currentX = transform.eulerAngles.x;
    }

    private void LateUpdate()
    {
        //마우스 우클릭 상태일 때 회전
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed; //마우스 좌우 움직임
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed; //마우스 상하 움직임

            //위에 설정한 초기 회전값에 움직인 회전 각도를 갱신함
            currentY += mouseX;
            currentX -= mouseY;

            //쓸모없는 부분까지 자꾸 이동하며 보여지길래 각도 제한 (숫자는 대충...)
            currentX = Mathf.Clamp(currentX, -30f, 60f);
        }

        //회전 값 계산
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);

        // 카메라가 항상 플레이어를 바라보도록 설정(기존 교수님 코드)
        //transform.position = playerTransform.position + rotation * offset;
        //transform.LookAt(playerTransform.position);


        //코드 참고 사이트: https://ansohxxn.github.io/unity%20lesson%202/ch5-3/
        Vector3 cameraPosition = playerTransform.position + rotation * offset;

        //Raycast로 충돌 여부 확인
        RaycastHit hit;
        if (Physics.Raycast(playerTransform.position, (transform.position - playerTransform.position).normalized, out hit, (offset.magnitude), LayerMask.GetMask("Wall")))
        {
            float dist = (hit.point - playerTransform.position).magnitude * 0.5f; // 충돌한 지점으로부터의 거리
            transform.position = Vector3.Lerp(transform.position, playerTransform.position + offset.normalized * dist, Time.deltaTime * 5f); // 충돌 시 카메라 위치 설정
        }
        else
        {
            transform.position = cameraPosition;
        }

        // 카메라가 항상 플레이어를 바라보도록 설정
        transform.LookAt(playerTransform.position);
        playerTransform.rotation = Quaternion.Euler(0, currentY, 0);

    }
}
