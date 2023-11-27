using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerCharacterController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        // Player에게 달려있는 PlayerInputController.cs Component의 상위 부모가 TopDownCharacterController
        _controller = GetComponent<PlayerCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // OnMoveEvent에 Move메서드 구독
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        // 이동 로직 실행
        ApllyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        // InputController에 입력이 생기면 이벤트가 발생해서
        // 이벤트가 뿌려주는 방향벡터를 _movementDirection에 담는다.
        _movementDirection = direction;
    }

    private void ApllyMovement(Vector2 direction)
    {
        // direction에는 입력받은 방향의 벡터가 들어있음.
        direction *= 5;

        // Player의 Rigidbody에 속도(velocity)를 넣어줌.
        _rigidbody.velocity = direction;
    }
}
