using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // NPC 이름을 가져온다.
        GameManager.instance.ContactNPCNameSave(collision.transform.parent.transform.GetComponent<TextMesh>().text);
    }
}
