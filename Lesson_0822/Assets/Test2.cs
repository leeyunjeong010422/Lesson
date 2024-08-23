using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    //[직렬화 [SerializeField]]
    //데이터 구조 또는 게임 오브젝트 상태를 보관하고 관리하는 기법
    //인스펙터 창에서 오브젝트의 직렬화된 멤버변수 값을 보여줌
    //이를 이용하여 소스코드의 수정 없이 유니티 에디터에서 값을 변경 가능

    //<데이터 직렬화>
    //오브젝트의 멤버변수 값을 확인하거나 변경
    //오브젝트의 멤버변수 참조를 드래그 앤 드랍 방식으로 연결

    [Header("Value Type")]
    //C# Type (int, bool, float, string)
    public int value;

    //Unity Type
    public Vector3 vector3; //X,Y,Z를 넣어줄 수 있음
    public Vector2 vector2; //X,Y만 넣어줄 수 있음
    public Vector3Int Vector3Int; //소수점 X
    public Vector2Int Vector2Int; //소수점 X
    public Color color; //색상 선택 가능

    public Rect rect; //사각형
    public LayerMask layerMask;
    public AnimationCurve curve;
    public Gradient Gradient;

    //열거형
    public enum JobType { a, b, c }
    public JobType jobType;

    //배열 기반 자료구조
    public int[] array;
    public List<JobType> list;

    [Header("Reference Type")]
    //드래그
    public Rigidbody rigid;
    public Collider coll;

    //[어트리뷰트]
    //클래스, 속성 또는 함수 위에 명시하여 특별한 동작을 나타낼 수 있는 마커
    [Space(30)]

    [Header("Unity Attribute")]
    [SerializeField] int privateValue; //private인데 보이게 하기
    [HideInInspector] public int publicValue; //public인데 안 보이게 하기

    [Range(3, 5)]
    public float percent = 4; //범위를 지정해 줘서 최소 최대를 강제로 정함

    [TextArea(3, 5)]
    public string story; //글 작성 범위 지정

    [System.Serializable]
    public struct Data
    {
        public string name;
        public int level;
        public float rate;
    }
    public Data data; //[System.Serializable] 이걸 해 줘야 유니티에서 볼 수 있음

    [System.Serializable]
    public class ClassType
    {
        public string name;
        public int level;
        public float rate;
    }
    public ClassType refer;


    //[유니티 메시지 함수]
    //유니티가 보내는 메시지에 반응하는 함수
    //MonoBehaviour 클래스에 메시지와 같은 이름의 함수가 반응 (MonoBehaviour 이게 없으면 안 됨)
    //스크립트는 유니티 엔진이 보내는 메시지를 받아 사건 타이밍을 확인
    //메시지 함수에서 자신의 행동을 정의하여 기능을 구성

    private void Awake()
    {
        Debug.Log("Start전에 실행!");
        //스크립트가 씬에 포함되었을 때 1회 호출
        //스크립트가 비활성화 되어 있는 경우에도 호출
        //역할: 스크립트가 필요로 하는 초기화 작업 진행 (외부 게임상황과 무관한 초기화 작업)
        //start보다 항상 먼저 호출!! 
        //내가 존재하는 순간 내가 준비해야 하는 것 (기능이 처음으로다가 존재하는 순간부터 준비하고 하는 것)
        //쉽게 말해 Awake는 내가 준비하는 거고 Start는 Awake로 다들 준비가 되어 있을 때 시작하는 것!!
    }
    private void Start()
    {
        Debug.Log("시작하면!");
        //스크립트가 씬에 처음으로 Update하기 직전에 1회 호출
        //스크립트가 비활성화 되어 있는 경우 호출되지 않음
        //역할: 스크립트가 필요로 하는 초기화 작업 진행 (외부 게임상황이 필요한 초기화 작업)
        //시작하기 전에 준비해야 하는 것들이긴 하지만 다들 준비되었을 때 시작하는 것
    }

    private void Update()
    {
        Debug.Log("동작할 때마다! (갱신)");
        //게임의 프레임 호출
        //역할: 핵심 게임 로직 구현
    }

    private void OnEnable()
    {
        Debug.Log("활성화 되면!");
        //스크립트가 활성화될 때마다 호출
        //역할: 스크립트가 활성화 되었을 때 작업 진행
    }

    private void OnDisable()
    {
        Debug.Log("비활성화 되면!");
        //스크립트가 비활성화될 때마다 호출
        //역할: 스크립트가 비활성화 되었을 때 작업 진행
    }

    private void OnDestroy()
    {
        //스크립트가 씬에서 삭제되었을 때 1회 호출
        //역할: 스크립트가 필요로 하는 마무리 작업 진행
        Debug.Log("삭제 되면!");
    }
}
