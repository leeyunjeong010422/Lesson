using System.Collections;
using UnityEngine;

public class RayMakeMonster : MonoBehaviour
{
    [SerializeField] GameObject monsterPrefab;

    // ���Ͱ� �������� ������ ��ġ
    [SerializeField] float xRange = 2;
    [SerializeField] float zRange = 2;
    [SerializeField] float yPosition = 2f;

    public void MakeMonster()
    {
        // ���ο� ���͸� ���� ��ġ�� ����
        Vector3 randomPosition = new Vector3(Random.Range(-xRange, xRange), yPosition, Random.Range(-zRange, zRange));
        GameObject newMonster = Instantiate(monsterPrefab, randomPosition, Quaternion.identity);

        // ������ ������ hp�� 3���� ����
        RayTarget rayTarget = newMonster.GetComponent<RayTarget>();
        if (rayTarget != null)
        {
            rayTarget.hp = 3;
        }
    }
}
