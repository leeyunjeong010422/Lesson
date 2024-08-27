using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float maxDistance; //�ִ� �Ÿ�
    [SerializeField] LayerMask layerMask; //���⼭ üũ�� ������Ʈ�� �ε����� ��üũ�� ������Ʈ�� �Ⱥε���

    private void Update()
    {
        //��� �������� ǥ������ (gameâ���� ǥ�� X)
        //Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * 100, Color.red); //���� �ڿ� �� �� ���� �׸����� �ʵ� �������� �� ����

        //Raycast: ù��°�� �ε��� �� ã�� (bool��) --> �ε����� true, �ƴϸ� false
        //RaycastAll: �ڿ� �ִ� �͵� �� �ε��� (�迭��)

        //RaycastHit hit; //��� �ε������� (�ε��� ����)

        //Physics.Raycast(��� ��ġ, ��� ����, �ε��� ����(out), �ִ�Ÿ�, ���̾��ũ(�浹Ȯ�� �׷� - Ÿ�� �׷�))
        if (Physics.Raycast(muzzlePoint.position, muzzlePoint.forward, out RaycastHit hit, maxDistance, layerMask))
        {
            //�������� �ε��� �� ���� ��
            //Debug.Log("������ �ε��� ��ü�� �ֽ��ϴ�.");
            Debug.Log($"{hit.collider.gameObject.name}�̶� �ε�����, �Ÿ��� {hit.distance}m �������ֽ��ϴ�.");
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * hit.distance, Color.red);
            //���� ���� �� �� �ڵ� ����....
        }
        else
        {
            //�ε��� �� ���� ��
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * maxDistance, Color.red);
        }
    }
}
