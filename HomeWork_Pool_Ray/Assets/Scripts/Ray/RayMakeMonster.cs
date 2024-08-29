using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayMakeMonster : MonoBehaviour
{
    [SerializeField] GameObject monsterPrefab; // 몬스터 프리팹

    // 몬스터가 랜덤으로 생성될 위치
    [SerializeField] float xRange = 2;
    [SerializeField] float zRange = 2;
    [SerializeField] float yPosition = 2f;

    public void MakeMonster()
    {
        // 몬스터를 랜덤 위치에 생성
        Vector3 randomPosition = new Vector3(Random.Range(-xRange, xRange), yPosition, Random.Range(-zRange, zRange));

        // 몬스터 생성
        GameObject newMonster = Instantiate(monsterPrefab, randomPosition, Quaternion.identity);
    }
}
