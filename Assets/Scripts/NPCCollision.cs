using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NPCCollision : MonoBehaviour
{
    public GameObject NPCPopupPanel;
    public GameObject NPCConversationPanel;

    public int npcKeyValue;

    // NPC ��ȭ ����
    protected Dictionary<int, string> talkDate;

    private void Awake()
    {
        talkDate = new Dictionary<int, string>();
        TalkDateSetting();
    }
    void TalkDateSetting()
    {
        talkDate.Add(1000, "�ȳ��ϼ���. ����ȣ Ʃ�� �Դϴ�.");
        talkDate.Add(2000, "�ȳ��ϼ���. ������ Ʃ�� �Դϴ�.");
        talkDate.Add(3000, "�ȳ��ϼ���. �̼��� Ʃ�� �Դϴ�.");
        talkDate.Add(4000, "�ȳ��ϼ���. ������ Ʃ�� �Դϴ�.");
        talkDate.Add(5000, "�ȳ��ϼ���. ���Ͽ� Ʃ�� �Դϴ�.");
        talkDate.Add(6000, "�ȳ��ϼ���. ����ȣ �Ŵ��� �Դϴ�.");
        talkDate.Add(7000, "�ȳ��ϼ���. ��ȿ�� �Ŵ��� �Դϴ�.");
        talkDate.Add(8000, "�ȳ��ϼ���. ������ �Ŵ��� �Դϴ�.");
        talkDate.Add(9000, "�ȳ��ϼ���. ���ؿ� �Ŵ��� �Դϴ�.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ǳ� ���ֱ�
        NPCPopupPanel.SetActive(true);
        // ������ npc �̸����� �ǳ� �ؽ�Ʈ ����
        NPCPopupPanel.transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.ContactNPCNameOutput();
        // Npc ��ȭ text�� talkDate[id]�� �����Ǵ� Value�� ����
        NPCConversationPanel.transform.GetChild(0).GetComponent<Text>().text = talkDate[npcKeyValue];
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // �ǳ� ���ֱ�
        NPCPopupPanel.SetActive(false);
        // ��ȭ �ǳڵ� ���ֱ�
        NPCConversationPanel.SetActive(false);
    }
}
