using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    #region Instance
    public static GameManager instance = null;

    private void Awake()
    {
        // instance가 null이라면
        if (instance == null)
        {
            // 자기 자신을 intance에 넣는다.
            instance = this;
            //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
            DontDestroyOnLoad(gameObject);
        }
        // 이미 존재한다면
        else 
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    #region 초기 설정
    private void Start()
    {
        Initalize();
    }

    // 캐릭터 정보
    private GameObject kngiht;
    private GameObject wizzard;

    // 캐릭터 선택 정보
    private int characterIndex = 0;

    // 플레이어 이름
    private string playerName;

    // NPC 이름
    private List<string> npcNames = new List<string>();

    // 접촉한 NPC의 이름
    private string contactName = null;

    // 리소스 로드
    private void Initalize()
    {
        kngiht = Resources.Load<GameObject>("Prefabs/PlayerKnight");
        wizzard = Resources.Load<GameObject>("Prefabs/PlayerWizzard");
    }
    #endregion

    // 플레이어 이름 저장
    public void SettingPlayerName(string name)
    {
        playerName = name;
    }

    // 플레이어 이름 불러오기
    public string OutputPlayerName()
    {
        return playerName;
    }

    // Knight 선택
    public void KnightChoice()
    {
        characterIndex = 0;
    }

    // Wizzard 선택
    public void WizzardChoice()
    {
        characterIndex = 1;
    }

    // 캐릭터 생성
    public GameObject InvokeCharacter()
    {
        if (characterIndex == 0) 
        {
            GameObject character = Instantiate(kngiht);
            return character;
            //Destroy(wizzard);
        }
        else //if (characterIndex == 1) 
        {
            GameObject character = Instantiate(wizzard);
            return character;
            //Destroy(kngiht);
        }
    }

    // 캐릭터 정보 체크
    public int CharacterCheck()
    {
        if (characterIndex == 0) return 0;
        else return 1;
    }

    // NPC 이름 저장
    public void NPCNameSave(string name)
    {
        npcNames.Add(name);
    }

    // NPC 이름 불러내기
    public string[] OutPutNPCName()
    {
        string[] outName = new string[npcNames.Count];
        for(int i = 0; i < npcNames.Count; i++)
        {
            outName[i] = npcNames[i];
        }
        return outName;
    }

    // Player가 접촉한 NPC 이름 저장
    public void ContactNPCNameSave(string name)
    {
        contactName = name;
    }

    // Player가 접촉한 NPC 이름 내보내기
    public string ContactNPCNameOutput()
    {
        return contactName;
    }
}
