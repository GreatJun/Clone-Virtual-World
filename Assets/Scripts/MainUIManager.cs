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

    // 접속자 명단 업데이트
    public void NameSetting()
    {
        string[] npcNames = GameManager.instance.OutPutNPCName();
        string playerName = GameManager.instance.OutputPlayerName();

        // 명단 초기화
        personUI.text = "";

        personUI.text += " ::접속자 명단:: \n\n";
        
        foreach (string npcName in npcNames) 
        {
            personUI.text += " " + npcName + "\n\n";
        }

        personUI.text += " " + playerName;
    }
}
