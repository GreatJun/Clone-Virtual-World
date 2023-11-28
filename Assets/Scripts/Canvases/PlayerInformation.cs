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
        // Player Name 2 ~ 10 글자 사이 제한
        if (playerinputName.text.Length > 1 && playerinputName.text.Length < 11)
        {
            // 조건 충족시 이름 저장
            playerName = playerinputName.text;
            // 게임 매니저에 이름 저장
            GameManager.instance.SettingPlayerName(playerName);
            // 씬 이동
            sceneMove.GoMainScene();
        }
    }

    public void PlayerNameChange()
    {
        if (playerinputName.text.Length > 1 && playerinputName.text.Length < 11)
        {
            // 조건 충족시 이름 저장
            playerName = playerinputName.text;
            // 게임 매니저에 이름 저장
            GameManager.instance.SettingPlayerName(playerName);
        }

    }
}
