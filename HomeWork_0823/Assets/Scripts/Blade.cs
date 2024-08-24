using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform rotatetarget;
    [SerializeField] float rotateSpeed; //회전 속도
    [SerializeField] float curRotateSpeed; //현재 회전 속도
    [SerializeField] float maxRotateSpeed; //최대 회전 속도
    [SerializeField] float liftRotateSpeed; //이륙 할 때 회전 속도
    [SerializeField] float liftSpeed; //상승 속도 (+하강)
    [SerializeField] float fuel = 100; //연료
    [SerializeField] float fuelDecrease = 15; //연료감소량

    private void Update()
    {
        //연료가 있을 때
        if (fuel > 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //스페이스키를 누르고 있으면 회전 속도 증가
                //현재 속도에 회전 속도를 더함
                curRotateSpeed += rotateSpeed * Time.deltaTime;
            }
            else
            {
                //스페이스바를 떼면 회전 속도 감소
                //현재 속도에 회전 속도를 뺌
                curRotateSpeed -= rotateSpeed * Time.deltaTime;
            }

            //하늘에 떠있을 때 시간에 따라 연료 감소
            if (curRotateSpeed >= liftRotateSpeed && target.position.y > 0)
            {
                fuel -= fuelDecrease * Time.deltaTime;
                fuel = Mathf.Clamp(fuel, 0, 100);
            }
        }
        else
        {
            curRotateSpeed -= rotateSpeed * Time.deltaTime;
        }

            //회전 속도 제한하기
            //참고사이트: https://asix.tistory.com/3
            //Mathf.Clamp 함수 사용 --> float value값이 float min(최소값)과 float max(최대값)사이에 있게 해주는 함수
            curRotateSpeed = Mathf.Clamp(curRotateSpeed, 0, maxRotateSpeed);

            //스페이스 바를 누를 때 날개 회전
            transform.RotateAround(rotatetarget.position, Vector3.up, curRotateSpeed * Time.deltaTime);

            if (curRotateSpeed >= liftRotateSpeed) //회전속도가 이륙속도보다 크면
            {
                //헬리콥터 상승
                target.position += Vector3.up * liftSpeed * Time.deltaTime;

            }
            else
            {
                //하강
                target.position -= Vector3.up * liftSpeed * Time.deltaTime;
            }

            //헬리콥터 높이 제한 0~50
            target.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, 0, 50), target.position.z);
        }
    }
