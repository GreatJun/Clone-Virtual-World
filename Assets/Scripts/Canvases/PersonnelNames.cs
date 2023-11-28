using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonnelNames : MonoBehaviour
{
    [SerializeField] private List<GameObject> presonnels = new List<GameObject>();

    private void Start()
    {
        for(int i = 0;  i < presonnels.Count; i++)
        {
            presonnels.Add(GameObject.FindWithTag("NPC"));
            Debug.Log(presonnels[i]);
        }
    }
}
