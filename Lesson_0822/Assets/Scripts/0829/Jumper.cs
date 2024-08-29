using System.Collections;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float chargingTime;

    Coroutine chargerCoroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            chargerCoroutine = StartCoroutine(ChagerRoutine());
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(chargerCoroutine);
            rigid.AddForce(Vector3.up * chargingTime, ForceMode.Impulse);
        }

        IEnumerator ChagerRoutine()
        {
            chargingTime = 0;
            WaitForSeconds delay = new WaitForSeconds(0.1f);

            while (true)
            {
                yield return delay;
                chargingTime += 0.1f;
            }
        }
    }
}
