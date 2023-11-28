using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NPCCollision : MonoBehaviour
{
    public GameObject NPCPopupPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ǳ� ���ֱ�
        NPCPopupPanel.SetActive(true);
        // ������ npc �̸����� �ǳ� �ؽ�Ʈ ����
        NPCPopupPanel.transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.ContactNPCNameOutput();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // �ǳ� ���ֱ�
        NPCPopupPanel.SetActive(false);
    }
}
