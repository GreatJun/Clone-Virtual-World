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
        // Mathf.Atan2 (��ũź��Ʈ�� ���ϴ� �޼���) : � ������ y, x�� ������ ��ũź��Ʈ�� �ϸ� �� ������ ��Ÿ���� ���´�. ( ������ ������ ���� �� )
        // Mathf.Atan2(direction.y, direction.x) �� �Ͽ� "��Ÿ"���� ������ "���̰�. ���� ���� ���´�.(0 ~ 3.14)" 
        // �� ���Ȱ��� ��׸���(0 ~ 180��) ���� �ٲ��ִ� ��(Mathf.Rad2Deg)�� �����ش�.
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // flipX : SpriteRendererŬ������ �����ϴ� X���� �������� ������ �ڵ�
        // (X���� ����) ���� 90���� ��������  �Ѿ�� ����� ���Ʒ� ��ȯ(flip.Y), ĳ���ʹ� �����ʿ��� ��ȯ(flip.X)
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}
