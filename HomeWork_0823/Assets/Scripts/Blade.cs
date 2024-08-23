using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Blade : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotateSpeed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.RotateAround(target.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }        
    }
}
