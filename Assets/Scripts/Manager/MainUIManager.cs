using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public Text personUI;

    //private void Awake()
    //{
    //    personUI = GetComponent<Text>();
    //}

    private void LateUpdate()
    {
        
    }

    // ������ ��� ������Ʈ
    public void NameSetting()
    {
        string[] npcNames = GameManager.instance.OutPutNPCName();
        string playerName = GameManager.instance.OutputPlayerName();

        // ��� �ʱ�ȭ
        personUI.text = "";

        personUI.text += " ::������ ���:: \n\n";
        
        foreach (string npcName in npcNames) 
        {
            personUI.text += " " + npcName + "\n\n";
        }

        personUI.text += " " + playerName;
    }
}
