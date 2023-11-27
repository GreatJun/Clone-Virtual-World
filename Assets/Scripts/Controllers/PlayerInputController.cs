using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Player의 입력을 감지하여 값을 받고 변환하여 PlayerCharacterController에게 전달해준다. 
public class PlayerInputController : PlayerCharacterController  // PlayerCharacterController를 상속
{
    private Camera _camera;

    private void Awake()
    {
        // 태그가 main인 Camera를 찾아온다.
        _camera = Camera.main;
    }

    // SendMessage방식 Move, Look, Fire 라는 3가지 Action을 만들어놨는데 그 앞에다 On을 붙이면 그 애들이 실행됐을 때 돌려받는 함수를 만들어 주는 것 이다.
    public void OnMove(InputValue value)
    {
        // 키가 눌리면 값을 그 방향의 방향벡터로 변환
        Vector2 moveInput = value.Get<Vector2>().normalized;
        // PlayerCharacterController의 CallMoveEvent메서드에 벡터값을 보낸다.
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        // Mouse의 좌표 (Screen상의 좌표)
        Vector2 newAim = value.Get<Vector2>();
        // Screen상의 좌표(newAim) -> World좌표로 변환(ScreenToWorldPoint)
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        // 벡터에서 벡터를 빼면 그 벡터로 향하는 방향,거리 가 나온다. (normalized하여 정규화(값 1))
        // 즉 newAim = 캐릭터가 마우스 를 바라보는 방향
        newAim = (worldPos - (Vector2)transform.position).normalized;

        // .magnitude : .의 힘을 의미 ( 위에서 normallized를 하여 값은 1로 정규화 된 값이 내려온다. )
        if (newAim.magnitude >= 0.9f) CallLookEvent(newAim);
    }
}
