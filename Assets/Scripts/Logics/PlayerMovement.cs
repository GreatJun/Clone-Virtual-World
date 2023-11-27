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
        // Player���� �޷��ִ� PlayerInputController.cs Component�� ���� �θ� TopDownCharacterController
        _controller = GetComponent<PlayerCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // OnMoveEvent�� Move�޼��� ����
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        // �̵� ���� ����
        ApllyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        // InputController�� �Է��� ����� �̺�Ʈ�� �߻��ؼ�
        // �̺�Ʈ�� �ѷ��ִ� ���⺤�͸� _movementDirection�� ��´�.
        _movementDirection = direction;
    }

    private void ApllyMovement(Vector2 direction)
    {
        // direction���� �Է¹��� ������ ���Ͱ� �������.
        direction *= 5;

        // Player�� Rigidbody�� �ӵ�(velocity)�� �־���.
        _rigidbody.velocity = direction;
    }
}
