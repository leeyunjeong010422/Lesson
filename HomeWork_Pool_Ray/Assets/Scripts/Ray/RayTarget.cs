using UnityEngine;

public class RayTarget : MonoBehaviour
{
    [SerializeField] public int hp = 3;
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
        // ���� ������Ʈ�� �����ǰ� ���ο� ���͸� ����
        makeMonster.MakeMonster();
        Destroy(gameObject);
    }
}
