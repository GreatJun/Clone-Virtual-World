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
        // ������ ĳ���� ����
        GameManager.instance.InvokeCharacter();
    }

    private void Start()
    {
        for (int i = 0; i < personnel.Count; i++)
        {
            // NPC�̸� ������
            names.Add(personnel[i].GetComponent<Text>().text);
            // GameManager�� NPC�̸� ����
            GameManager.instance.NPCNameSave(names[i]);
        }
    }


}
