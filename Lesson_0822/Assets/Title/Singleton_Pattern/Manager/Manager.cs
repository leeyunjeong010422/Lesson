using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameManager를 추가하지 못했어도 코드로 자동 추가
public static class Manager
{
    public static GameManager Instance { get { return GameManager.Instance; } }
    //특수 어트리뷰트
    //게임 시작하자마자 무조건 먼저 호출되는 함수를 지정
    //게임 시작 전에 실행됨 (게임 시작하면 다른 것보다 가장 먼저 호출)
    //용도: 게임 설정, 싱글톤 정리, 등
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        //게임 설정 진행

        //싱글톤 생성
        GameManager.Create();
    }
}
