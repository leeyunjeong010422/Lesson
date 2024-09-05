using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleShooter : MonoBehaviour
{
    [SerializeField] GameObject misslePrefab;
    [SerializeField] float repratTime;

    private Coroutine missleSpawn;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //누르고 있으면 true
        {

        }

        if (Input.GetKeyDown(KeyCode.Space)) //눌렀을 때만 true
        {
            missleSpawn = StartCoroutine(MissleSpawn());
        }

        else if (Input.GetKeyUp(KeyCode.Space)) //땠을 때만 true
        {
            StopCoroutine(missleSpawn);
        }
    }

    IEnumerator MissleSpawn()
    {
        WaitForSeconds delay = new WaitForSeconds(repratTime);

        while (true)
        {
            Instantiate(misslePrefab, transform.position, transform.rotation);
            yield return delay;
        }
    }
}
