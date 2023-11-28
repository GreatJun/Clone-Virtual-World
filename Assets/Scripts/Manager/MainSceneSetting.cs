using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneSetting : MonoBehaviour
{
    // ������ ��� ����Ʈ
    [SerializeField] private List<GameObject> personnel = new List<GameObject>();

    private void Awake()
    {
        // ������ ĳ���� ����
        GameManager.instance.InvokeCharacter();
    }

    private void Start()
    {
        for (int i = 0; i < personnel.Count; i++)
        {
            // GameManager�� NPC�̸� ����
            GameManager.instance.NPCNameSave(personnel[i].transform.GetChild(0).GetComponent<TextMesh>().text);
        }
    }
}
