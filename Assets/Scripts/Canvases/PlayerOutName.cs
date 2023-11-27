using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOutName : MonoBehaviour
{
    [SerializeField] private Text playerNameTxt;

    public void Start()
    {
        playerNameTxt.text = GameManager.instance.OutputPlayerName();
    }
}
