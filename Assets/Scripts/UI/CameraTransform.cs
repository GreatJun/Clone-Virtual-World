using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    [SerializeField] private GameObject player;


    private void Start()
    {
        //if(GameManager.instance.CharacterCheck() == 0)
        //{
        //    player = Resources.Load<GameObject>("Prefabs/PlayerKnight");
        //}
        //else
        //{
        //    if(GameManager.instance.CharacterCheck() == 1) player = Resources.Load<GameObject>("Prefabs/PlayerWizzard");
        //}
        player = GameObject.FindWithTag("Player");
    }


    public void LateUpdate()
    {
        if (player == null) player = GameObject.FindWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
