using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCConversation : MonoBehaviour
{
    Dictionary<int, string[]> talkDate;

    void TalkDateSetting()
    {
        talkDate.Add(1000, new string[] { "�ȳ��ϼ���. ����ȣ Ʃ�� �Դϴ�.", "���� �𸣽ô°� �ֳ���?" });
        talkDate.Add(2000, new string[] { "�ȳ��ϼ���. ������ Ʃ�� �Դϴ�.", "���� �� �̽Ű���?" });
    }
}
