using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player가 들어오면 다음 스테이지로 이동한다");
        }
        Debug.Log($"Trigger Enter: {other.gameObject.name}");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"Trigger Stay: {other.gameObject.name}");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"Trigger Exit: {other.gameObject.name}");
    }
}
