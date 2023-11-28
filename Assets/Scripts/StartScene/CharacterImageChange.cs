using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImageChange : MonoBehaviour
{
    [SerializeField] private Sprite changeImage_Knight;
    [SerializeField] private Sprite changeImage_Wizzard;

    private Image isImage;

    private void Awake()
    {
        isImage = GetComponent<Image>();
    }

    public void Select_Knight()
    {
        isImage.sprite = changeImage_Knight;
    }

    public void Select_Wizzard()
    {
        isImage.sprite = changeImage_Wizzard;
    }

}
