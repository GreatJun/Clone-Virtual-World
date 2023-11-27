using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        if(GameManager.instance.CharacterCheck() == 0)
        {
            player = Resources.Load<GameObject>("Prefabs/PlayerKnight");
        }
        else
        {
            if(GameManager.instance.CharacterCheck() == 1) player = Resources.Load<GameObject>("Prefabs/PlayerWizzard");
        }
    }

    public void Upadate()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);
    }
}
