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

        // Start Scene에서 입력한 이름 가져와서 텍스트에 띄운다.
        //playerNameTxt.text = GameManager.instance.OutputPlayerName();
        player.transform.GetChild(1).GetComponent<TextMesh>().text = GameManager.instance.OutputPlayerName();
    }

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
        Invoke("PlayerNameSetting", 0.1f);
    }

    // 바뀐 캐릭터에 이름 적용
    public void PlayerNameSetting()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.GetChild(1).GetComponent<TextMesh>().text = GameManager.instance.OutputPlayerName();
    }

    // 원래 캐릭터 파괴
    public void CheckDestory()
    {
        beforeCharacter = GameObject.FindGameObjectWithTag("Player");
        Destroy(beforeCharacter);
    }

    #region 이동 방지 시간
    // 이동 방지
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
