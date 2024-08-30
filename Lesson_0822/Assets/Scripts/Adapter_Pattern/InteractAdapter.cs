using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//어뎁터 패턴
public class InteractAdapter : MonoBehaviour, I_Interactable
{
    public UnityEvent<Player> OnInteract;
    public void TargetInteract(Player player)
    {
        OnInteract?.Invoke(player);
    }
}
