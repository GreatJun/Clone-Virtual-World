using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Player�� �Է��� �����Ͽ� ���� �ް� ��ȯ�Ͽ� PlayerCharacterController���� �������ش�. 
public class PlayerInputController : PlayerCharacterController  // PlayerCharacterController�� ���
{
    private Camera _camera;

    private void Awake()
    {
        // �±װ� main�� Camera�� ã�ƿ´�.
        _camera = Camera.main;
    }

    // SendMessage��� Move, Look, Fire ��� 3���� Action�� �������µ� �� �տ��� On�� ���̸� �� �ֵ��� ������� �� �����޴� �Լ��� ����� �ִ� �� �̴�.
    public void OnMove(InputValue value)
    {
        // Ű�� ������ ���� �� ������ ���⺤�ͷ� ��ȯ
        Vector2 moveInput = value.Get<Vector2>().normalized;
        // PlayerCharacterController�� CallMoveEvent�޼��忡 ���Ͱ��� ������.
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        // Mouse�� ��ǥ (Screen���� ��ǥ)
        Vector2 newAim = value.Get<Vector2>();
        // Screen���� ��ǥ(newAim) -> World��ǥ�� ��ȯ(ScreenToWorldPoint)
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        // ���Ϳ��� ���͸� ���� �� ���ͷ� ���ϴ� ����,�Ÿ� �� ���´�. (normalized�Ͽ� ����ȭ(�� 1))
        // �� newAim = ĳ���Ͱ� ���콺 �� �ٶ󺸴� ����
        newAim = (worldPos - (Vector2)transform.position).normalized;

        // .magnitude : .�� ���� �ǹ� ( ������ normallized�� �Ͽ� ���� 1�� ����ȭ �� ���� �����´�. )
        if (newAim.magnitude >= 0.9f) CallLookEvent(newAim);
    }
}
