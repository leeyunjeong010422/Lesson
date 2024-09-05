using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //ã�ٰ� ���� �ǵ� ����ó�� ���� ������Ʈ ����ȭ ��Ű�� �̰� �� ���� ��� ����!!
    //https://daekyoulibrary.tistory.com/entry/Charon-8-%ED%94%8C%EB%A0%88%EC%9D%B4%EC%96%B4%EC%99%80-%EC%B9%B4%EB%A9%94%EB%9D%BC-%EC%82%AC%EC%9D%B4%EC%9D%98-%EC%98%A4%EB%B8%8C%EC%A0%9D%ED%8A%B8-%ED%88%AC%EB%AA%85%ED%99%94%ED%95%98%EA%B8%B0

    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] float rotationSpeed; //�����ӿ� ���� ī�޶� ȸ����ų ����

    private float currentY; //���� Y�� ȸ�� ����
    private float currentX; //���� X�� ȸ�� ����

    private void Start()
    {
        if (playerTransform == null)
        {
            GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
            playerTransform = playerGameObject.transform;
        }
        else
        {
            Debug.LogWarning("�÷��̾ ����");
        }

        //ȸ���� �ʱ� ����
        currentY = transform.eulerAngles.y;
        currentX = transform.eulerAngles.x;
    }

    private void LateUpdate()
    {
        //���콺 ��Ŭ�� ������ �� ȸ��
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed; //���콺 �¿� ������
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed; //���콺 ���� ������

            //���� ������ �ʱ� ȸ������ ������ ȸ�� ������ ������
            currentY += mouseX;
            currentX -= mouseY;

            //������� �κб��� �ڲ� �̵��ϸ� �������淡 ���� ���� (���ڴ� ����...)
            currentX = Mathf.Clamp(currentX, -30f, 60f);
        }

        //ȸ�� �� ���
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);

        // ī�޶� �׻� �÷��̾ �ٶ󺸵��� ����(���� ������ �ڵ�)
        //transform.position = playerTransform.position + rotation * offset;
        //transform.LookAt(playerTransform.position);


        //�ڵ� ���� ����Ʈ: https://ansohxxn.github.io/unity%20lesson%202/ch5-3/
        Vector3 cameraPosition = playerTransform.position + rotation * offset;

        //Raycast�� �浹 ���� Ȯ��
        RaycastHit hit;
        if (Physics.Raycast(playerTransform.position, (transform.position - playerTransform.position).normalized, out hit, (offset.magnitude), LayerMask.GetMask("Wall")))
        {
            float dist = (hit.point - playerTransform.position).magnitude * 0.5f; // �浹�� �������κ����� �Ÿ�
            transform.position = Vector3.Lerp(transform.position, playerTransform.position + offset.normalized * dist, Time.deltaTime * 5f); // �浹 �� ī�޶� ��ġ ����
        }
        else
        {
            transform.position = cameraPosition;
        }

        // ī�޶� �׻� �÷��̾ �ٶ󺸵��� ����
        transform.LookAt(playerTransform.position);
        playerTransform.rotation = Quaternion.Euler(0, currentY, 0);

    }
}
