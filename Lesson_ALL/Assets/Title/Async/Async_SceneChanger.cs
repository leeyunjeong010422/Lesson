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

    //�ε��ϱ� ���� ����ϴ� ��
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
                //�ε���
                Debug.Log($"loading = {oper.progress}");
                loadingBar.value = oper.progress;
            }
            else
            {
                break;
            }

            yield return null;
        }

        //��¥ �ε�ȭ�� ����
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

        ////�ε��Ϸ�
        //Debug.Log("loading sucess");

        ////�ƹ�Ű�� ������ �� ���� ������ �Ѿ �� ����
        //if (Input.anyKeyDown)
        //{
        //    oper.allowSceneActivation = true;
        //    loadingImage.gameObject.SetActive(false);
        //}

    }
}

