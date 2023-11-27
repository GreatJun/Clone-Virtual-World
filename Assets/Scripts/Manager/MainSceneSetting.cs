using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneSetting : MonoBehaviour
{
    private void Awake()
    {
        // 선택한 캐릭터 생성
        GameManager.instance.InvokeCharacter();
    }
}
