using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerCharacterController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private Animator playerAnim;

    private void Awake()
    {
        // Player에게 달려있는 PlayerInputController.cs Component의 상위 부모가 TopDownCharacterController
        _controller = GetComponent<PlayerCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();

        // GetComponentInChildren : 특정 컴포넌트의 하위(자식) 객체 중 가장 선두에 존재하는 컴포넌트를 반환
        // GetComponentsInChildren : 특정 컴포넌트의 하위(자식)객체의 모두를 반환시킨다. 이때, 반환은 Array ( 배열 ) 형태로 반환된다.
        playerAnim = GetComponentInChildren<Animator>();
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

        // Player Animation is Run Check
        playerAnim.SetFloat("Move", _movementDirection.magnitude);
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
