using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NPCCollision : MonoBehaviour
{
    public GameObject NPCPopupPanel;
    public GameObject NPCConversationPanel;

    Dictionary<int, string[]> talkDate;

    public int npcKeyValue;
    private int nowKey;

    private void Start()
    {
        TalkDateSetting();
    }

    void TalkDateSetting()
    {
        talkDate.Add(1000, new string[] { "안녕하세요. 오정호 튜터 입니다." });
        talkDate.Add(2000, new string[] { "안녕하세요. 송지원 튜터 입니다." });
        talkDate.Add(3000, new string[] { "안녕하세요. 이성언 튜터 입니다." });
        talkDate.Add(4000, new string[] { "안녕하세요. 강성훈 튜터 입니다." });
        talkDate.Add(5000, new string[] { "안녕하세요. 김하연 튜터 입니다." });
        talkDate.Add(6000, new string[] { "안녕하세요. 정승호 매니저 입니다." });
        talkDate.Add(7000, new string[] { "안녕하세요. 한효승 매니저 입니다." });
        talkDate.Add(8000, new string[] { "안녕하세요. 장윤서 매니저 입니다." });
        talkDate.Add(9000, new string[] { "안녕하세요. 박준영 매니저 입니다." });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        nowKey = npcKeyValue;
        // 판넬 켜주기
        NPCPopupPanel.SetActive(true);
        // 접촉한 npc 이름으로 판넬 텍스트 설정
        NPCPopupPanel.transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.ContactNPCNameOutput();
        //
        NPCConversationPanel.transform.GetChild(0).GetComponent<Text>().text = talkDate[nowKey].ToString();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 판넬 꺼주기
        NPCPopupPanel.SetActive(false);
        // 대화 판넬도 꺼주기
        NPCConversationPanel.SetActive(false);
    }
}
