using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    // event : �ܺο��� ȣ������ ���ϰ� ���´�.
    // Action : �Է°� ��ȯ���� ���� ��������Ʈ. ���׸�<T>�� �̿�.
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        // ?. : Null�� �ƴ϶��, �����϶�(Invoke).
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
