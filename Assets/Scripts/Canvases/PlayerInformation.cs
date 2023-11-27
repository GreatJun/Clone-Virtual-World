using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformation : MonoBehaviour
{
    [SerializeField] private InputField playerinputName;
    [SerializeField] private SceneMovement sceneMove;

    private string playerName = null;

    private void Awake()
    {
        playerName = playerinputName.GetComponent<InputField>().text;
    }

    // 플레이어 이름 저장
    public void PlayerInputNameSave()
    {
        if (playerinputName.text.Length > 1 && playerinputName.text.Length < 11)
        {
            playerName = playerinputName.text;
            GameManager.instance.SettingPlayerName(playerName);
            sceneMove.GoMainScene();
        }
    }

}
