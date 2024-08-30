using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Co_MakeMonster : MonoBehaviour
{
    [SerializeField] GameObject monsterPrefab;

    // 몬스터가 랜덤으로 생성될 위치
    [SerializeField] float xRange = 2;
    [SerializeField] float zRange = 2;
    [SerializeField] float yPosition = 2f;

    public void MakeMonster(GameObject monster)
    {
        StartCoroutine(RespawnMonster(monster, 3f)); // 3초 뒤에 몬스터 활성화 코루틴 시작
    }

    public IEnumerator RespawnMonster(GameObject monster, float delay)
    {
        yield return new WaitForSeconds(delay);

        // 새로운 몬스터를 랜덤 위치에 생성
        Vector3 randomPosition = new Vector3(Random.Range(-xRange, xRange), yPosition, Random.Range(-zRange, zRange));
        GameObject newMonster = Instantiate(monsterPrefab, randomPosition, Quaternion.identity);

        // 생성된 몬스터의 hp를 3으로 설정
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
    //    // 새로운 몬스터를 랜덤 위치에 생성
    //    Vector3 randomPosition = new Vector3(Random.Range(-xRange, xRange), yPosition, Random.Range(-zRange, zRange));
    //    GameObject newMonster = Instantiate(monsterPrefab, randomPosition, Quaternion.identity);

    //    // 생성된 몬스터의 hp를 3으로 설정
    //    Co_Target rayTarget = newMonster.GetComponent<Co_Target>();
    //    if (rayTarget != null)
    //    {
    //        rayTarget.hp = 3;
    //    }
    //}
