using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncTest : MonoBehaviour
{
    //public string name;

    private void Start()
    {
        //코루틴
        //StartCoroutine(Routioe());

        //쓰레드
        Task.Run(ThreadFunc);
    }

    private void Update()
    {
        //코루틴
       // Debug.Log($"{name}");

        //쓰레드
        Debug.Log($"{name} 업데이트");
    }

    //코루틴
    //IEnumerator Routioe()
    //{
    //    while(true)
    //    {
    //        yield return null;
    //        Debug.Log($"{name} 코루틴");
    //    }
    //}

    //쓰레드
    private void ThreadFunc()
    {
        for (int i = 0; i < 10; i++) 
        {
            Debug.Log($"{name} 쓰레드 {i}");
        }
    }
}
