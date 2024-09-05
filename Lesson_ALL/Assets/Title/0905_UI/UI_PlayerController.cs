using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerController : MonoBehaviour
{
    //[SerializeField] Rigidbody rd;
    //[SerializeField] TextMeshProUGUI scoreText;
    //[SerializeField] float jumpPower;

    //[SerializeField] int score;


    //점프할 때마다 점수 증가
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Jump();
    //    }
    //}
    //private void Jump()
    //{
    //    rd.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    //    score++;
    //    scoreText.text = $"현재 점수: {score}";
    //}

    //private void OnCoisionEnter(Collision collision)
    //{
    //    score++;
    //}

    //Controller와 View는 합쳐서 쓰는 경우가 많음
    //1. UI(View) / Data(Model) 분리해주기
    //2. Model 변경에 대한 이벤트 구현해주기 (값따로 프로퍼티 따로, 값 바꾸면 이벤트 동시 발생)
    //   --> 추천, 프로퍼티에서 이벤트도 set에서 발생하도록 구현
    //3. View 에서 Model 변경에 대한 이벤트에 변경시 UI 설정을 작업
    //4. --> 추천, OnEnable에서 등록, Ondisable에서 해제 / Start에서 처음 설정

    //이 뒤부터 controller가 model의 데이터를 변경하면 => 자동으로 UI도 변경

    [Header("UI")]
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] Slider hpSlider;
    [SerializeField] TextMeshProUGUI mpText;
    [SerializeField] Slider mpSlider;

    [Header("Model")]
    [SerializeField] PlayerModel model;

    [Header("Property")]
    [SerializeField] float jumpPower;

    private void OnEnable()
    {
        model.OnHPChanged += UpdateHP;
        model.OnMPChanged += UpdateMP;
    }

    private void OnDisable()
    {
        model.OnHPChanged -= UpdateHP;
        model.OnMPChanged -= UpdateMP;
    }

    private void Start()
    {
        UpdateHP(model.HP);
        UpdateMP(model.MP);
        hpSlider.maxValue = model.MaxHP;
        mpSlider.maxValue = model.MaxMP;
    }

    #region UI
    private void UpdateHP(int hp)
    {
        hpText.text = $"{hp}";  
        hpSlider.value = hp;
    }

    private void UpdateMP(int mp)
    {
        mpText.text = $"{mp}";
        mpSlider.value = mp;
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            model.HP += 10;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            model.MP += 10;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            model.MP -= 10;
        }
    }
}
