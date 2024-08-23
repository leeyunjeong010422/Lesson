using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int potionCount;
    void Start()
    {
        Debug.Log("인벤토리에서 아이템을 확인한다.");
        Debug.Log("인벤토리에서 포션을 찾는다.");
        Debug.LogWarning($"포션이 없을 수도 있으니 주의하세요!! 포션 갯수: {potionCount}");

        if (potionCount > 0)
        {
            potionCount--;
            Debug.Log("그 포션을 사용한다.");
        }
        else
        {
            Debug.LogError("포션이 없습니다.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
