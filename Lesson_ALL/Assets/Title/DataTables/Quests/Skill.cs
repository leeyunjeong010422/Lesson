using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill")]
public class Skill : ScriptableObject
{
    public string name;
    public float coolTime;

    public Sprite icon;

    public void Use()
    {
        Debug.Log($"{name} ��ų ���");
    }
}
