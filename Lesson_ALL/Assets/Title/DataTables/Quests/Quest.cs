using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "생성시 파일명", menuName = "분류명/선택지 명")]
[CreateAssetMenu(menuName = "Quest/NormalQuest", fileName = "NormalQuest")]
public class Quest : ScriptableObject
{
    public string title;

    [TextArea(3,5)]
    public string description;

    public int exp;
    public int gold;

    public GameObject[] rewardItems;
    public Sprite icon;
    public Color Color;
}


