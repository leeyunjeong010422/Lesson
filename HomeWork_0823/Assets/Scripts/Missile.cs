using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float lifetime = 4f;
    private float timer;

    public bool Expired {  get; private set; }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Expired = true;
        }
    }
}
