using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임창에서 아무스 우클릭을 눌렀을 때 그 방향으로 이동하는 캐릭터
public class RTS_Mover : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject playerObject;
    [SerializeField] PlayerMover playerMover;
    [SerializeField] LayerMask LayerMask;

    private void Start()
    {
        cam = Camera.main;
        playerObject = GameObject.FindGameObjectWithTag("Player");

        //playerMover 컴포넌트 가져옴
        playerMover = playerObject.GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        //마우스의 위치대로 Ray를 줄 수 있음
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, 100f, LayerMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 0.2f);
            Vector3 destination = hit.point;
            playerMover.Move(destination);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 0.5f);
        }      
    }
}
