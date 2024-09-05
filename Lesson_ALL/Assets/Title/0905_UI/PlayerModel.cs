using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModel : MonoBehaviour
{
    public int hp;
    public int HP { get { return hp; } set { hp = value; OnHPChanged?.Invoke(hp); } }
    public UnityAction<int> OnHPChanged;

    [SerializeField] int maxHP;
    public int MaxHP { get { return maxHP; } }

    public int mp;
    public int MP { get { return mp; } set { mp = value; OnMPChanged?.Invoke(mp); } }
    public UnityAction<int> OnMPChanged;

    [SerializeField] int maxMP;
    public int MaxMP { get { return maxMP; } }
}
