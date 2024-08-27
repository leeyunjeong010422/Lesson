using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����â���� �ƹ��� ��Ŭ���� ������ �� �� �������� �̵��ϴ� ĳ����
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

        //playerMover ������Ʈ ������
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
        //���콺�� ��ġ��� Ray�� �� �� ����
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
