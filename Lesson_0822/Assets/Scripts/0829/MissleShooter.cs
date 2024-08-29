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
        if (Input.GetKey(KeyCode.Space)) //������ ������ true
        {

        }

        if (Input.GetKeyDown(KeyCode.Space)) //������ ���� true
        {
            missleSpawn = StartCoroutine(MissleSpawn());
        }

        else if (Input.GetKeyUp(KeyCode.Space)) //���� ���� true
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
