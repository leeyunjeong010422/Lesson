using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Name : BaseUI
{
    private void Start()
    {
        //버튼 이름을 가지고 있는 UI의 색을 빨강으로 바꿈
        Image image = GetUI("Button").GetComponent<Image>();
        //Image image = GetUI<Image>("Button");
        image.color = Color.red;

        //CoinText이름을 가지고 있는 텍스트의 텍스트를 5000으로 바꿈
        GetUI<Text>("CoinText").text = "5000";

        GetUI<Button>("Button").onClick.AddListener(ButtonAction);
    }

    public void ButtonAction()
    {
        Debug.Log("버튼 눌림");
    }
}
