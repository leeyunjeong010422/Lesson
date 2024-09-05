using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesTest : MonoBehaviour
{
    [SerializeField] GameManager gameManagerPrefab;

    private void Start()
    {
        gameManagerPrefab = Resources.Load<GameManager>("Managers/GameManager");
    }
}
