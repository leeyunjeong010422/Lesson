using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Name : BaseUI
{
    private void Start()
    {
        //��ư �̸��� ������ �ִ� UI�� ���� �������� �ٲ�
        Image image = GetUI("Button").GetComponent<Image>();
        //Image image = GetUI<Image>("Button");
        image.color = Color.red;

        //CoinText�̸��� ������ �ִ� �ؽ�Ʈ�� �ؽ�Ʈ�� 5000���� �ٲ�
        GetUI<Text>("CoinText").text = "5000";

        GetUI<Button>("Button").onClick.AddListener(ButtonAction);
    }

    public void ButtonAction()
    {
        Debug.Log("��ư ����");
    }
}
