using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTester : MonoBehaviour
{

    [SerializeField] AudioClip bgm1;
    [SerializeField] AudioClip bgm2;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SoundManager.Instance.PlayBGM(bgm1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SoundManager.Instance.PlayBGM(bgm2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SoundManager.Instance.StopBGM();
        }
    }
}
