using System.Collections;
using UnityEngine;

public class RayMakeMonster : MonoBehaviour
{
    [SerializeField] GameObject monsterPrefab;

    // 몬스터가 랜덤으로 생성될 위치
    [SerializeField] float xRange = 2;
    [SerializeField] float zRange = 2;
    [SerializeField] float yPosition = 2f;

    public void MakeMonster()
    {
        // 새로운 몬스터를 랜덤 위치에 생성
        Vector3 randomPosition = new Vector3(Random.Range(-xRange, xRange), yPosition, Random.Range(-zRange, zRange));
        GameObject newMonster = Instantiate(monsterPrefab, randomPosition, Quaternion.identity);

        // 생성된 몬스터의 hp를 3으로 설정
        RayTarget rayTarget = newMonster.GetComponent<RayTarget>();
        if (rayTarget != null)
        {
            rayTarget.hp = 3;
        }
    }
}
