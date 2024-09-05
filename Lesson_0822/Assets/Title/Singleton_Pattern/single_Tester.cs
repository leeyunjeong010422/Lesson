using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class single_Tester : MonoBehaviour
{  
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            //게임 어디에서든지 게임매니저를 쓰고 싶다면 Instance를 가지고 사용할 수 있음
            GameManager.Instance.score++;

            //이런식으로 사용 가능!
            //드래그앤드롭 같은 거 안 해도 됨
            //InventoryManager.Instance.AddIntem();
        }
    }
}