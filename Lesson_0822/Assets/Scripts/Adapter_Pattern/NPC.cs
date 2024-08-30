using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//인터페이스
//public class NPC : MonoBehaviour, I_Interactable
//{
//    public void TargetInteract(Player player)
//    {
//        Talk();
//    }

//    public void Talk()
//    {
//        Debug.Log("NPC와 대화를 합니다.");
//    }
//}

public class NPC : MonoBehaviour
{
    public void Talk()
    {
        Debug.Log("NPC와 대화를 합니다.");
    }
}
