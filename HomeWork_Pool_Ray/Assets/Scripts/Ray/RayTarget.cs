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
        // �ڷ�ƾ ����
        StartCoroutine(RespawnMonsterAfterDelay(3f));
    }

    private IEnumerator RespawnMonsterAfterDelay(float delay)
    {
        // ���� ���� ������Ʈ ����
        Destroy(gameObject);

        // 3�� ���� ���
        yield return new WaitForSeconds(delay);

        makeMonster.MakeMonster();

    }
}
