using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncTest : MonoBehaviour
{
    //public string name;

    private void Start()
    {
        //�ڷ�ƾ
        //StartCoroutine(Routioe());

        //������
        Task.Run(ThreadFunc);
    }

    private void Update()
    {
        //�ڷ�ƾ
       // Debug.Log($"{name}");

        //������
        Debug.Log($"{name} ������Ʈ");
    }

    //�ڷ�ƾ
    //IEnumerator Routioe()
    //{
    //    while(true)
    //    {
    //        yield return null;
    //        Debug.Log($"{name} �ڷ�ƾ");
    //    }
    //}

    //������
    private void ThreadFunc()
    {
        for (int i = 0; i < 10; i++) 
        {
            Debug.Log($"{name} ������ {i}");
        }
    }
}
