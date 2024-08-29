using System.Collections;
using UnityEngine;

public class RayTarget : MonoBehaviour
{
    [SerializeField] int hp = 3;
    [SerializeField] RayMakeMonster makeMonster;

    public void TakeHit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // 코루틴 시작
        StartCoroutine(RespawnMonsterAfterDelay(3f));
    }

    private IEnumerator RespawnMonsterAfterDelay(float delay)
    {
        // 현재 몬스터 오브젝트 삭제
        Destroy(gameObject);

        // 3초 동안 대기
        yield return new WaitForSeconds(delay);

        makeMonster.MakeMonster();

    }
}
