using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITester : MonoBehaviour
{
    //[SerializeField] Image image;
    [SerializeField] Button button;

    [SerializeField] TextMeshProUGUI text;

    //��ư
    //private void Start()
    //{
    //    button.onClick.AddListener(Test);
    //}
    //public void Test()
    //{
    //    Debug.Log("��ư�� ������~~!!!!");
    //}

    private void Start()
    {
        text.color = Color.red;
    }
}
