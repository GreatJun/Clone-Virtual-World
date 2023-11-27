using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformation : MonoBehaviour
{
    [SerializeField]private InputField playerinputName;

    private string playerName = null;

    private void Awake()
    {
        playerName = playerinputName.GetComponent<InputField>().text;
    }

    public void PlayerInputNameSave()
    {
        playerName = playerinputName.text;
        GameManager.instance.SettingPlayerName(playerName);
    }

}
