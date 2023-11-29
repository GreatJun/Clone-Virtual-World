using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCollision : MonoBehaviour
{
    public GameObject NPCPopupPanel;
    public GameObject NPCConversationPanel;

    public int npcKeyValue;

    // NPC ��ȭ ����
    protected Dictionary<int, string> talkDate;
    protected Dictionary<int, Sprite> npcProfile;

    private void Awake()
    {
        // �ʱ�ȭ
        talkDate = new Dictionary<int, string>();
        npcProfile = new Dictionary<int, Sprite>();
        TalkDateSetting();
    }
    void TalkDateSetting()
    {
        // NPC ���
        talkDate.Add(1000, "�ȳ��ϼ���. ����ȣ Ʃ�� �Դϴ�.");
        talkDate.Add(2000, "�ȳ��ϼ���. ������ Ʃ�� �Դϴ�.");
        talkDate.Add(3000, "�ȳ��ϼ���. �̼��� Ʃ�� �Դϴ�.");
        talkDate.Add(4000, "�ȳ��ϼ���. ������ Ʃ�� �Դϴ�.");
        talkDate.Add(5000, "�ȳ��ϼ���. ���Ͽ� Ʃ�� �Դϴ�.");
        talkDate.Add(6000, "�ȳ��ϼ���. ����ȣ �Ŵ��� �Դϴ�.");
        talkDate.Add(7000, "�ȳ��ϼ���. ��ȿ�� �Ŵ��� �Դϴ�.");
        talkDate.Add(8000, "�ȳ��ϼ���. ������ �Ŵ��� �Դϴ�.");
        talkDate.Add(9000, "�ȳ��ϼ���. ���ؿ� �Ŵ��� �Դϴ�.");

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
        // �ǳ� ���ֱ�
        NPCPopupPanel.SetActive(true);
        // ������ npc �̸����� �ǳ� �ؽ�Ʈ ����
        NPCPopupPanel.transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.ContactNPCNameOutput();
        // Npc ��ȭ text�� ���� NPC�� Key������ Value�޾ƿ���
        NPCConversationPanel.transform.GetChild(0).GetComponent<Text>().text = talkDate[npcKeyValue];
        NPCConversationPanel.transform.GetChild(2).GetComponent<Image>().sprite = npcProfile[npcKeyValue];
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // �ǳ� ���ֱ�
        NPCPopupPanel.SetActive(false);
        // ��ȭ �ǳڵ� ���ֱ�
        NPCConversationPanel.SetActive(false);
    }
}
