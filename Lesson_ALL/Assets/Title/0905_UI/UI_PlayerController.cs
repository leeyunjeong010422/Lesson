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


    //������ ������ ���� ����
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
    //    scoreText.text = $"���� ����: {score}";
    //}

    //private void OnCoisionEnter(Collision collision)
    //{
    //    score++;
    //}

    //Controller�� View�� ���ļ� ���� ��찡 ����
    //1. UI(View) / Data(Model) �и����ֱ�
    //2. Model ���濡 ���� �̺�Ʈ �������ֱ� (������ ������Ƽ ����, �� �ٲٸ� �̺�Ʈ ���� �߻�)
    //   --> ��õ, ������Ƽ���� �̺�Ʈ�� set���� �߻��ϵ��� ����
    //3. View ���� Model ���濡 ���� �̺�Ʈ�� ����� UI ������ �۾�
    //4. --> ��õ, OnEnable���� ���, Ondisable���� ���� / Start���� ó�� ����

    //�� �ں��� controller�� model�� �����͸� �����ϸ� => �ڵ����� UI�� ����

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
