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

    //코루틴으로 죽으면 3초 뒤에 살아나도록 했는데 잘 안 되어서
    //활성화 비활성화를 이용해서 죽으면 비활성화 되었다가 3초 뒤에 다시 활성화되게 했는데
    //이것도 비활성화 되었을 때 몬스터 프리팹을 찾지 못해서 활성화되지 못합니다...
    //어떻게 수정을 해야할지 모르겠어요 ㅠㅠ...
    private void Die()
    {
        //makeMonster.MakeMonster();
        //Destroy(gameObject);
        gameObject.SetActive(false);
        makeMonster.MakeMonster(gameObject);

    }
}
