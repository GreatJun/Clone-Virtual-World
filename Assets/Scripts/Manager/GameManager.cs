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

    // ������ NPC�� �̸�
    private string contactName = null;

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

    // ĳ���� ����
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

    // ĳ���� ���� üũ
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

    // NPC �̸� �ҷ�����
    public string[] OutPutNPCName()
    {
        string[] outName = new string[npcNames.Count];
        for(int i = 0; i < npcNames.Count; i++)
        {
            outName[i] = npcNames[i];
        }
        return outName;
    }

    // Player�� ������ NPC �̸� ����
    public void ContactNPCNameSave(string name)
    {
        contactName = name;
    }

    // Player�� ������ NPC �̸� ��������
    public string ContactNPCNameOutput()
    {
        return contactName;
    }
}
