using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//싱글톤에는 씬에 있는 내용을 드래그앤드롭하면 안 됨!!
//싱글톤이 게임오브젝트를 가져다 쓰면 안됨 (find해서 찾아서 써야 함)
//씬마다 싱글톤을 넣어주는 걸 까먹으면 안 됨 (아님 처음 시작하는 곳에만 넣어둠!!!!!!!)
//씬 이동 시 사라짐
public class GameManager : MonoBehaviour
{

   // private static GameManager instance = null;
    //public static GameManager Instance { get { return instance; } }

    //아래 코드 한 줄로 위 코드 두 줄 대신 사용할 수 있음!! 같은 코드임
    public static GameManager Instance { get; private set; }

    public int score;

    //public event UnityAction OnStarted;
    //public event UnityAction OnPaused;
    //public event UnityAction OnResumed;
    //public event UnityAction OnFinished;

    //단 하나의 인스턴스를 보장
    private void Awake()
    {
        //Awake: 처음 만들어졌을 때 호출되는 함수
        //1. 싱글톤이 없었으면 => 지금 만든 인스턴스를 싱글톤으로 쓰자
        if (Instance == null)
        {
            Instance = this;

            //새로운 씬전환(로딩)에서도 지워지지 않는 게임 오브젝트로 만드는 것
            //score의 값이 씬을 전환해도 값이 바뀌지 않음
            //씬이 바뀌어도 사라지지 않고 냅둠
            //다른 씬에 GameManager을 만들지 않더라도 그대로 옮겨짐
            DontDestroyOnLoad(gameObject);
        }
        //2. 싱글톤이 있었으면 => 지금 만든 인스턴스를 삭제하자
        else // (instance != null)인 상황
        {
            Destroy(gameObject);
        }
    }

    //싱글톤 만들기
    public static void Create()
    {
        // Resources 폴더 : 유니티의 특수폴더로 Resources 폴더안의 에셋은 코드 경로를 통해서 로딩 가능
        // 단, Resources 폴더는 빌드과정에 반드시 포함되는 에셋으로 분류되므로 게임빌드파일의 크기를 증가시킴
        // 따라서, 게임의 규모가 작거나 리소스가 많지 않을 때 사용 권장 (보통 6개월 미만의 게임제작 결과물에 추천)
        // 추후, 에셋번들이나 어드레서블을 통해서 관리할 필요가 있음

        // Resources.Load<T>(path) : Resources 폴더 안의 경로에서 에셋을 찾아 참조함

        GameManager gameManagerPrefab = Resources.Load<GameManager>("Managers/GameManager");
        Instantiate(gameManagerPrefab);
    }

    //싱글톤 지우기
    public static void Release()
    {
        if(Instance == null)
            return;

        Destroy(Instance.gameObject);
        Instance = null;
    }
}
