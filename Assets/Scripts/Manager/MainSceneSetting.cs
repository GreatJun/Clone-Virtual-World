using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneSetting : MonoBehaviour
{
    // 접속자 명단 리스트
    [SerializeField] private List<GameObject> personnel = new List<GameObject>();

    private void Awake()
    {
        // 선택한 캐릭터 생성
        GameManager.instance.InvokeCharacter();
    }

    private void Start()
    {
        for (int i = 0; i < personnel.Count; i++)
        {
            // GameManager에 NPC이름 저장
            GameManager.instance.NPCNameSave(personnel[i].transform.GetChild(0).GetComponent<TextMesh>().text);
        }
    }
}
