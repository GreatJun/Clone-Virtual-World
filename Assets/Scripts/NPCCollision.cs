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
        talkDate.Add(1000, new string[] { "�ȳ��ϼ���. ����ȣ Ʃ�� �Դϴ�." });
        talkDate.Add(2000, new string[] { "�ȳ��ϼ���. ������ Ʃ�� �Դϴ�." });
        talkDate.Add(3000, new string[] { "�ȳ��ϼ���. �̼��� Ʃ�� �Դϴ�." });
        talkDate.Add(4000, new string[] { "�ȳ��ϼ���. ������ Ʃ�� �Դϴ�." });
        talkDate.Add(5000, new string[] { "�ȳ��ϼ���. ���Ͽ� Ʃ�� �Դϴ�." });
        talkDate.Add(6000, new string[] { "�ȳ��ϼ���. ����ȣ �Ŵ��� �Դϴ�." });
        talkDate.Add(7000, new string[] { "�ȳ��ϼ���. ��ȿ�� �Ŵ��� �Դϴ�." });
        talkDate.Add(8000, new string[] { "�ȳ��ϼ���. ������ �Ŵ��� �Դϴ�." });
        talkDate.Add(9000, new string[] { "�ȳ��ϼ���. ���ؿ� �Ŵ��� �Դϴ�." });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        nowKey = npcKeyValue;
        // �ǳ� ���ֱ�
        NPCPopupPanel.SetActive(true);
        // ������ npc �̸����� �ǳ� �ؽ�Ʈ ����
        NPCPopupPanel.transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.ContactNPCNameOutput();
        //
        NPCConversationPanel.transform.GetChild(0).GetComponent<Text>().text = talkDate[nowKey].ToString();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // �ǳ� ���ֱ�
        NPCPopupPanel.SetActive(false);
        // ��ȭ �ǳڵ� ���ֱ�
        NPCConversationPanel.SetActive(false);
    }
}
