using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //몬스터가 player를 따라다닐 수 있게
    [SerializeField] GameObject target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
}
