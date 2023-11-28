using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCConversation : MonoBehaviour
{
    Dictionary<int, string[]> talkDate;

    void TalkDateSetting()
    {
        talkDate.Add(1000, new string[] { "안녕하세요. 오정호 튜터 입니다.", "뭔가 모르시는게 있나요?" });
        talkDate.Add(2000, new string[] { "안녕하세요. 송지원 튜터 입니다.", "무슨 일 이신가요?" });
    }
}
