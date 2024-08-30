using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Co_MakeMonster : MonoBehaviour
{
    [SerializeField] GameObject monsterPrefab;

    // ���Ͱ� �������� ������ ��ġ
    [SerializeField] float xRange = 2;
    [SerializeField] float zRange = 2;
    [SerializeField] float yPosition = 2f;

    public void MakeMonster(GameObject monster)
    {
        StartCoroutine(RespawnMonster(monster, 3f)); // 3�� �ڿ� ���� Ȱ��ȭ �ڷ�ƾ ����
    }

    public IEnumerator RespawnMonster(GameObject monster, float delay)
    {
        yield return new WaitForSeconds(delay);

        // ���ο� ���͸� ���� ��ġ�� ����
        Vector3 randomPosition = new Vector3(Random.Range(-xRange, xRange), yPosition, Random.Range(-zRange, zRange));
        GameObject newMonster = Instantiate(monsterPrefab, randomPosition, Quaternion.identity);

        // ������ ������ hp�� 3���� ����
        Co_Target coTarget = newMonster.GetComponent<Co_Target>();
        if (coTarget != null)
        {
            coTarget.hp = 3;
        }
        monster.SetActive(true);
    }
}

    //public void MakeMonster()
    //{
    //    // ���ο� ���͸� ���� ��ġ�� ����
    //    Vector3 randomPosition = new Vector3(Random.Range(-xRange, xRange), yPosition, Random.Range(-zRange, zRange));
    //    GameObject newMonster = Instantiate(monsterPrefab, randomPosition, Quaternion.identity);

    //    // ������ ������ hp�� 3���� ����
    //    Co_Target rayTarget = newMonster.GetComponent<Co_Target>();
    //    if (rayTarget != null)
    //    {
    //        rayTarget.hp = 3;
    //    }
    //}
