using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public Text personUI;

    GameObject beforeCharacter;

    [SerializeField] private GameObject player;

    //private void Awake()
    //{
    //    personUI = GetComponent<Text>();
    //}
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Start Scene���� �Է��� �̸� �����ͼ� �ؽ�Ʈ�� ����.
        //playerNameTxt.text = GameManager.instance.OutputPlayerName();
        player.transform.GetChild(1).GetComponent<TextMesh>().text = GameManager.instance.OutputPlayerName();
    }

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
        Invoke("PlayerNameSetting", 0.1f);
    }

    // �ٲ� ĳ���Ϳ� �̸� ����
    public void PlayerNameSetting()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.GetChild(1).GetComponent<TextMesh>().text = GameManager.instance.OutputPlayerName();
    }

    // ���� ĳ���� �ı�
    public void CheckDestory()
    {
        beforeCharacter = GameObject.FindGameObjectWithTag("Player");
        Destroy(beforeCharacter);
    }

    #region �̵� ���� �ð�
    // �̵� ����
    public void TimeStop()
    {
        Time.timeScale = 0;
    }

    public void TimeGo()
    {
        Time.timeScale = 1;
    }
    #endregion
}
