using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //���Ͱ� player�� ����ٴ� �� �ְ�
    [SerializeField] GameObject target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
}
