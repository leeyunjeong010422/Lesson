using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTarget : MonoBehaviour
{

    //죽으면 다시 리스폰 되는 거 구현 X
    [SerializeField] int hp = 3;

    public void TakeHit(int damage)
    {
        hp -= damage;
        if (hp <= 0 )
        {
            Die();
        }    
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
