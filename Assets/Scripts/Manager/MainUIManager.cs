using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public Text personUI;

    GameObject beforeCharacter;

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

    // 캐릭터 재선택
    public void KnightSelect()
    {
        GameManager.instance.KnightChoice();
    }

    public void WizzardSelect()
    {
        GameManager.instance.WizzardChoice();
    }

    public void SelectCharacter()
    {
        GameManager.instance.InvokeCharacter();
    }

    public void CheckDestory()
    {
        beforeCharacter = GameObject.FindGameObjectWithTag("Player");
        Destroy(beforeCharacter);
    }
}
