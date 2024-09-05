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

    //버튼
    //private void Start()
    //{
    //    button.onClick.AddListener(Test);
    //}
    //public void Test()
    //{
    //    Debug.Log("버튼을 눌렀다~~!!!!");
    //}

    private void Start()
    {
        text.color = Color.red;
    }
}
