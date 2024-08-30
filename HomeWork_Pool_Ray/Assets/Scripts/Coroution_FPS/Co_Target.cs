using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Co_Target : MonoBehaviour
{
    [SerializeField] Co_MakeMonster makeMonster;
    [SerializeField] public int hp;
    public void TakeHit(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            //Destroy(gameObject);
            Die();
        }
    }

    //�ڷ�ƾ���� ������ 3�� �ڿ� ��Ƴ����� �ߴµ� �� �� �Ǿ
    //Ȱ��ȭ ��Ȱ��ȭ�� �̿��ؼ� ������ ��Ȱ��ȭ �Ǿ��ٰ� 3�� �ڿ� �ٽ� Ȱ��ȭ�ǰ� �ߴµ�
    //�̰͵� ��Ȱ��ȭ �Ǿ��� �� ���� �������� ã�� ���ؼ� Ȱ��ȭ���� ���մϴ�...
    //��� ������ �ؾ����� �𸣰ھ�� �Ф�...
    private void Die()
    {
        //makeMonster.MakeMonster();
        //Destroy(gameObject);
        gameObject.SetActive(false);
        makeMonster.MakeMonster(gameObject);

    }
}
