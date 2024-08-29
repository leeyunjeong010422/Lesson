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
        // 몬스터 오브젝트가 삭제되고 새로운 몬스터를 생성
        makeMonster.MakeMonster();
        Destroy(gameObject);
    }
}
