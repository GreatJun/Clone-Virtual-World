using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    private PlayerCharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<PlayerCharacterController>();
    }

    private void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateMouse(newAimDirection);
    }

    private void RotateMouse(Vector2 direction)
    {
        // Mathf.Atan2 (아크탄젠트를 구하는 메서드) : 어떤 벡터의 y, x를 가지고 아크탄젠트르 하면 그 사이의 세타값이 나온다. ( 벡터의 각도를 구는 것 )
        // Mathf.Atan2(direction.y, direction.x) 를 하여 "세타"값이 나오면 "파이값. 라디안 값이 나온다.(0 ~ 3.14)" 
        // 그 라디안값을 디그리값(0 ~ 180도) 으로 바꿔주는 값(Mathf.Rad2Deg)을 곱해준다.
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // flipX : SpriteRenderer클래스가 제공하는 X축을 기준으로 뒤집는 코드
        // (X축이 기준) 절댓값 90도를 기준으로  넘어가면 무기는 위아래 전환(flip.Y), 캐릭터는 오른쪽왼쪽 전환(flip.X)
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}
