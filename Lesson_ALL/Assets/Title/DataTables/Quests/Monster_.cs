using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_ : MonoBehaviour
{
    //[SerializeField] MonsterData data;
    //public int hp; --> �̷� ü���� ���⿡ �����ؾ� ��
    [SerializeField] Skill[] Skills;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Skills[0].Use();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Skills[1].Use();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Skills[2].Use();
        }
    }
}
