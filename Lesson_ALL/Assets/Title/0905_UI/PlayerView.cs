using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] PlayerModel model;

    private void OnEnable()
    {
        model.OnHPChanged += UpdateHP;
    }

    private void OnDisable()
    {
        model.OnHPChanged -= UpdateHP;
    }

    private void Start()
    {
        UpdateHP(model.HP);
    }
    private void UpdateHP(int hp)
    {
        hpText.text = $"{hp}";
    }
}
