using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������̽�
//public class Item : MonoBehaviour, I_Interactable
//{
//    public void TargetInteract(Player player)
//    {
//        Use();
//    }

//    public void Use()
//    {
//        Debug.Log("������ ���");
//        Destroy(gameObject);
//    }
//}

public class Item : MonoBehaviour
{
    [SerializeField] int healPoint;
    public void Use(Player player)
    {
        Debug.Log("������ �Ծ����ϴ�!");
        player.Heal(healPoint);
        Destroy(gameObject);
    }
}
