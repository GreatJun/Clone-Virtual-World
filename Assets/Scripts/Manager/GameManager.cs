using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    #region Instance
    public static GameManager instance = null;

    private void Awake()
    {
        // instance�� null�̶��
        if (instance == null)
        {
            // �ڱ� �ڽ��� intance�� �ִ´�.
            instance = this;
            //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
            DontDestroyOnLoad(gameObject);
        }
        // �̹� �����Ѵٸ�
        else 
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    #region �ʱ� ����
    private void Start()
    {
        Initalize();
    }

    // ĳ���� ����
    private GameObject kngiht;
    private GameObject wizzard;

    // ĳ���� ���� ����
    private int characterIndex = 0;

    // �÷��̾� �̸�
    private string playerName;

    // NPC �̸�
    private List<string> npcNames = new List<string>();

    // ���ҽ� �ε�
    private void Initalize()
    {
        kngiht = Resources.Load<GameObject>("Prefabs/PlayerKnight");
        wizzard = Resources.Load<GameObject>("Prefabs/PlayerWizzard");
    }
    #endregion

    // �÷��̾� �̸� ����
    public void SettingPlayerName(string name)
    {
        playerName = name;
    }

    // �÷��̾� �̸� �ҷ�����
    public string OutputPlayerName()
    {
        return playerName;
    }

    // Knight ����
    public void KnightChoice()
    {
        characterIndex = 0;
    }

    // Wizzard ����
    public void WizzardChoice()
    {
        characterIndex = 1;
    }

    public void InvokeCharacter()
    {
        if (characterIndex == 0) 
        {
            Instantiate(kngiht);
            //Destroy(wizzard);
        }
        else if (characterIndex == 1) 
        {
            Instantiate(wizzard);
            //Destroy(kngiht);
        }
    }

    public int CharacterCheck()
    {
        if (characterIndex == 0) return 0;
        else return 1;
    }

    // NPC �̸� ����
    public void NPCNameSave(string name)
    {
        npcNames.Add(name);
    }

}
