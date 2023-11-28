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

    // ĳ���� �缱��
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
