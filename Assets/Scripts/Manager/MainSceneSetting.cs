using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneSetting : MonoBehaviour
{
    private void Awake()
    {
        // ������ ĳ���� ����
        GameManager.instance.InvokeCharacter();
    }
}
