using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneSetting : MonoBehaviour
{
    [SerializeField] private List<GameObject> personnel = new List<GameObject>();
    [SerializeField] private List<string> names = new List<string>();

    private void Awake()
    {
        // 선택한 캐릭터 생성
        GameManager.instance.InvokeCharacter();
    }

    private void Start()
    {
        for (int i = 0; i < personnel.Count; i++)
        {
            // NPC이름 얻어오기
            names.Add(personnel[i].GetComponent<Text>().text);
            // GameManager에 NPC이름 저장
            GameManager.instance.NPCNameSave(names[i]);
        }
    }


}
