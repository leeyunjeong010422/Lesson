using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Async_SceneChanger : MonoBehaviour
{
    [SerializeField] Image loadingImage;
    [SerializeField] Slider loadingBar;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}

    //로딩하기 전에 대기하는 것
    public void ChangeScene(string sceneName)
    {
        if (loading != null)
            return;

        loading = StartCoroutine(Loading(sceneName));
    }

    Coroutine loading;

    IEnumerator Loading(string sceneName)
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(sceneName);

        oper.allowSceneActivation = false;
        loadingImage.gameObject.SetActive(true);

        while (oper.isDone == false)
        {
            if(oper.progress < 0.9f)
            {
                //로딩중
                Debug.Log($"loading = {oper.progress}");
                loadingBar.value = oper.progress;
            }
            else
            {
                break;
            }

            yield return null;
        }

        //가짜 로딩화면 구현
        float time = 0f;

        while (time < 5f)
        {
            time += Time.deltaTime;
            loadingBar.value = time / 5f;
            yield return null;
        }

        while (Input.anyKeyDown == false)
        {
            yield return null;
        }

        oper.allowSceneActivation = true;
        loadingImage.gameObject.SetActive(false);

        ////로딩완료
        //Debug.Log("loading sucess");

        ////아무키나 눌렀을 때 다음 씬으로 넘어갈 수 있음
        //if (Input.anyKeyDown)
        //{
        //    oper.allowSceneActivation = true;
        //    loadingImage.gameObject.SetActive(false);
        //}

    }
}

