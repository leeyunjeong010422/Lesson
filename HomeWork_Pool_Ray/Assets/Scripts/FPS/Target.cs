using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] int hp;
    public void TakeHit(int attack)
    {
        hp -= attack;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
