using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineTest : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerCam;
    [SerializeField] CinemachineVirtualCamera bossCam;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            bossCam.Priority = 20;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            bossCam.Priority = 5;
        }
    }
}
