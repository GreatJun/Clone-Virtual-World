using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOutName : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Start Scene에서 입력한 이름 가져와서 텍스트에 띄운다.
        //playerNameTxt.text = GameManager.instance.OutputPlayerName();
        player.transform.GetChild(1).GetComponent<TextMesh>().text = GameManager.instance.OutputPlayerName();
    }

    public void ReLoadName()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.GetChild(1).GetComponent<TextMesh>().text = GameManager.instance.OutputPlayerName();
    }
}
