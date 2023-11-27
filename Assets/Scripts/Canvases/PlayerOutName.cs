using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOutName : MonoBehaviour
{
    [SerializeField] private Text playerNameTxt;

    public void Start()
    {
        // Start Scene에서 입력한 이름 가져와서 텍스트에 띄운다.
        playerNameTxt.text = GameManager.instance.OutputPlayerName();
    }
}
