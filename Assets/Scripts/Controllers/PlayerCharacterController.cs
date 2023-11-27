using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    // event : 외부에서 호출하지 못하게 막는다.
    // Action : 입력값 반환값이 없는 델리게이트. 제네릭<T>을 이용.
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        // ?. : Null이 아니라면, 실행하라(Invoke).
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
