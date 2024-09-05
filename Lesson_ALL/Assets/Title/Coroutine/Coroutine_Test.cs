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
    //    ////하나
    //    //Coroutine coroutine = StartCoroutine(Routine(name)); //name에 이름을 넣어주면 됨 밑에 A,B이런 것처럼

    //    ////여러개
    //    //Coroutine coroutineA = StartCoroutine(Routine("A"));
    //    //Coroutine coroutineB = StartCoroutine(Routine("B"));
    //    //Coroutine coroutineC = StartCoroutine(Routine("C"));

    //    //Coroutine coroutine = StartCoroutine(BulletRoutine());
    //}

    private void Update()
    {
        //스페이스바를 누르면 코루틴 실행!!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(delayJumpCoroutine == null)
            {
                delayJumpCoroutine = StartCoroutine(DelayJump());
            }
        }

        //코루틴을 그만 돌아가라고 그만!!!그만!!!!!!!!!!
        //다시 스페이스바를 누르면 처음부터 실행함
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //StopCoroutine할 때 작업을 멈추는 게 아니라 담당자를 멈춰줘야함
            //DelayJump() 이게 아니라 delayJumpCoroutine를 해 줘야 함!!
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

        Debug.Log("3초 뒤에 점프합니다.");
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
    //        Debug.Log("총알 생성");
    //    }      
    //}

    //<코루틴 지연>
    //코루틴은 반복작업 중 지연처리를 정의하여 작업의 진행으 타이밍을 지정할 수 있음

    IEnumerator CorutineWait()
    {
        //Time.timeScale = 3f; //3배속 시키기

        yield return null; //한 프레임 지연
        yield return new WaitForSeconds(1f); //n초간 시간 지연
        yield return new WaitForSecondsRealtime(1f); //현실 n초간 시간 지연
        yield return new WaitForFixedUpdate(); //FixedUpdate 까지 지연
        yield return new WaitForEndOfFrame(); //프레임의 끝까지 지연
        yield return new WaitUntil(() => true); //조건이 충족할 때까지 지연
    }
}
