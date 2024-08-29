using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTarget : MonoBehaviour
{

    //������ �ٽ� ������ �Ǵ� �� ���� X
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
