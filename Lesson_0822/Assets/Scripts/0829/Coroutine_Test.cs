using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coroutine_Test : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    //[SerializeField] float bulletTime;

    private Coroutine delayJumpCoroutine;

    //private void Start()
    //{
    //    ////�ϳ�
    //    //Coroutine coroutine = StartCoroutine(Routine(name)); //name�� �̸��� �־��ָ� �� �ؿ� A,B�̷� ��ó��

    //    ////������
    //    //Coroutine coroutineA = StartCoroutine(Routine("A"));
    //    //Coroutine coroutineB = StartCoroutine(Routine("B"));
    //    //Coroutine coroutineC = StartCoroutine(Routine("C"));

    //    //Coroutine coroutine = StartCoroutine(BulletRoutine());
    //}

    private void Update()
    {
        //�����̽��ٸ� ������ �ڷ�ƾ ����!!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(delayJumpCoroutine == null)
            {
                delayJumpCoroutine = StartCoroutine(DelayJump());
            }
        }

        //�ڷ�ƾ�� �׸� ���ư���� �׸�!!!�׸�!!!!!!!!!!
        //�ٽ� �����̽��ٸ� ������ ó������ ������
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //StopCoroutine�� �� �۾��� ���ߴ� �� �ƴ϶� ����ڸ� ���������
            //DelayJump() �̰� �ƴ϶� delayJumpCoroutine�� �� ��� ��!!
            StopCoroutine(delayJumpCoroutine);
            delayJumpCoroutine = null;
        }
    }

    IEnumerator DelayJump()
    {
        //Debug.Log(3);
        //yield return new WaitForSeconds(1f);
        //Debug.Log(2);
        //yield return new WaitForSeconds(1f);
        //Debug.Log(1);
        //yield return new WaitForSeconds(1f);

        Debug.Log("3�� �ڿ� �����մϴ�.");
        yield return new WaitForSeconds(3f);

        rigid.AddForce(Vector3.up * 10f, ForceMode.Impulse);

        delayJumpCoroutine = null;
    }


    //IEnumerator Routine(string name)
    //{
    //    Debug.Log($"{name} Coroutine 0");
    //    yield return new WaitForSeconds(1f);
    //    Debug.Log($"{name} Coroutine 1");
    //    yield return new WaitForSeconds(1f);
    //    Debug.Log($"{name} Coroutine 2");
    //    yield return new WaitForSeconds(1f);
    //    Debug.Log($"{name} Coroutine 3");
    //    yield return new WaitForSeconds(1f);
    //    Debug.Log($"{name} Coroutine 4");
    //}

    //IEnumerator BulletRoutine()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(bulletTime);
    //        Debug.Log("�Ѿ� ����");
    //    }      
    //}

    //<�ڷ�ƾ ����>
    //�ڷ�ƾ�� �ݺ��۾� �� ����ó���� �����Ͽ� �۾��� ������ Ÿ�̹��� ������ �� ����

    IEnumerator CorutineWait()
    {
        //Time.timeScale = 3f; //3��� ��Ű��

        yield return null; //�� ������ ����
        yield return new WaitForSeconds(1f); //n�ʰ� �ð� ����
        yield return new WaitForSecondsRealtime(1f); //���� n�ʰ� �ð� ����
        yield return new WaitForFixedUpdate(); //FixedUpdate ���� ����
        yield return new WaitForEndOfFrame(); //�������� ������ ����
        yield return new WaitUntil(() => true); //������ ������ ������ ����
    }
}
