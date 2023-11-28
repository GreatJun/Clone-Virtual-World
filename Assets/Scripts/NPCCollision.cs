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
        // 판넬 켜주기
        NPCPopupPanel.SetActive(true);
        // 접촉한 npc 이름으로 판넬 텍스트 설정
        NPCPopupPanel.transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.ContactNPCNameOutput();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 판넬 꺼주기
        NPCPopupPanel.SetActive(false);
    }
}
