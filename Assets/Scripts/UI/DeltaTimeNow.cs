using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeltaTimeNow : MonoBehaviour
{
    private Text timeText;

    private void Awake()
    {
        timeText = transform.GetComponent<Text>();
    }

    private void Update()
    {
        timeText.text = GetCurrentDate();
    }

    public static string GetCurrentDate()
    {
        return DateTime.Now.ToString(("HH : mm"));
    }
}
