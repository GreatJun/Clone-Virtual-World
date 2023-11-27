using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    private string playerName;

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
}
