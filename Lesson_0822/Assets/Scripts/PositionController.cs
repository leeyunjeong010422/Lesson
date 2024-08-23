using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float moveSpeed;

    [SerializeField] float rate;


    private void Update()
    {

    }

    //방향으로 이동하기
    private void PositionMove()
    {
        //프레임과 상관없이 똑같은 속도로 움직이게 하고 싶을 때
        //1초 동안 x 만큼 가고 싶으면 x * Time.deltaTime
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime; // 1/s를 생각하면됨!!
    }

    //방향으로 이동하기
    private void TranslateMove()
    {
        //이동시키기 기능
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    //목적지로 이동하기 (일정속도)
    private void MoveTowardsMove()
    {
        //목표지점까지 이동시키기
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    //목적지로 이동하기 (처음엔 빠르고 점점 느려짐)
    private void LerpMove()
    {
        //멀리 있으면 빨리 움직이고 가까이 올수록 속도가 느려짐
        transform.position = Vector3.Lerp(transform.position, target.position, rate * Time.deltaTime);
    }
}
