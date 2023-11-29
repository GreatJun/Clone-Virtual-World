using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCollision : MonoBehaviour
{
    public GameObject NPCPopupPanel;
    public GameObject NPCConversationPanel;

    public int npcKeyValue;

    // NPC 대화 정보
    protected Dictionary<int, string> talkDate;
    protected Dictionary<int, Sprite> npcProfile;

    private void Awake()
    {
        // 초기화
        talkDate = new Dictionary<int, string>();
        npcProfile = new Dictionary<int, Sprite>();
        TalkDateSetting();
    }
    void TalkDateSetting()
    {
        // NPC 대사
        talkDate.Add(1000, "안녕하세요. 오정호 튜터 입니다.");
        talkDate.Add(2000, "안녕하세요. 송지원 튜터 입니다.");
        talkDate.Add(3000, "안녕하세요. 이성언 튜터 입니다.");
        talkDate.Add(4000, "안녕하세요. 강성훈 튜터 입니다.");
        talkDate.Add(5000, "안녕하세요. 김하연 튜터 입니다.");
        talkDate.Add(6000, "안녕하세요. 정승호 매니저 입니다.");
        talkDate.Add(7000, "안녕하세요. 한효승 매니저 입니다.");
        talkDate.Add(8000, "안녕하세요. 장윤서 매니저 입니다.");
        talkDate.Add(9000, "안녕하세요. 박준영 매니저 입니다.");

        // NPC Image
        npcProfile.Add(1000, Resources.Load<Sprite>("Image/OH Tuter"));
        npcProfile.Add(2000, Resources.Load<Sprite>("Image/Song Tuter"));
        npcProfile.Add(3000, Resources.Load<Sprite>("Image/Lee tuter"));
        npcProfile.Add(4000, Resources.Load<Sprite>("Image/Kang tuter"));
        npcProfile.Add(5000, Resources.Load<Sprite>("Image/White Tuter"));
        npcProfile.Add(6000, Resources.Load<Sprite>("Image/Jung Manager"));
        npcProfile.Add(7000, Resources.Load<Sprite>("Image/Han Manager"));
        npcProfile.Add(8000, Resources.Load<Sprite>("Image/Jang Manager"));
        npcProfile.Add(9000, Resources.Load<Sprite>("Image/Park Manager"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 판넬 켜주기
        NPCPopupPanel.SetActive(true);
        // 접촉한 npc 이름으로 판넬 텍스트 설정
        NPCPopupPanel.transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.ContactNPCNameOutput();
        // Npc 대화 text에 만난 NPC의 Key값으로 Value받아오기
        NPCConversationPanel.transform.GetChild(0).GetComponent<Text>().text = talkDate[npcKeyValue];
        NPCConversationPanel.transform.GetChild(2).GetComponent<Image>().sprite = npcProfile[npcKeyValue];
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 판넬 꺼주기
        NPCPopupPanel.SetActive(false);
        // 대화 판넬도 꺼주기
        NPCConversationPanel.SetActive(false);
    }
}
