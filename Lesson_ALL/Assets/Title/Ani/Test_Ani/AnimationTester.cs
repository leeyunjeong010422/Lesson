using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTester : MonoBehaviour
{
    //[SerializeField] Animator animator;
    //[SerializeField] float speed;

    //private void Update()
    //{
    //    float z = Input.GetAxis("Horizontal");

    //    transform.Translate(Vector3.forward * speed * z * Time.deltaTime);
    //    animator.SetFloat("Speed", speed * z);
    //}

    [SerializeField] Animator animator;
    [SerializeField] bool show;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            show = !show;
            animator.SetBool("Show", show);
        }
    }
}
