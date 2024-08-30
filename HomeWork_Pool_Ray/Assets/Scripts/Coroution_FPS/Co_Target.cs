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

    private void Die()
    {
        //makeMonster.MakeMonster();
        //Destroy(gameObject);
        gameObject.SetActive(false);
        makeMonster.MakeMonster(gameObject);

    }
}
