using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOutName : MonoBehaviour
{
    [SerializeField] private Text playerNameTxt;

    public void Start()
    {
        // Start Scene���� �Է��� �̸� �����ͼ� �ؽ�Ʈ�� ����.
        playerNameTxt.text = GameManager.instance.OutputPlayerName();
    }
}
