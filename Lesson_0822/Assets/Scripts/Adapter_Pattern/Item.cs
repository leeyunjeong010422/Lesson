using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//인터페이스
//public class Item : MonoBehaviour, I_Interactable
//{
//    public void TargetInteract(Player player)
//    {
//        Use();
//    }

//    public void Use()
//    {
//        Debug.Log("아이템 사용");
//        Destroy(gameObject);
//    }
//}

public class Item : MonoBehaviour
{
    [SerializeField] int healPoint;
    public void Use(Player player)
    {
        Debug.Log("포션을 먹었습니다!");
        player.Heal(healPoint);
        Destroy(gameObject);
    }
}
