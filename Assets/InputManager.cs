using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public InputAction playerController;
    PlayerControls playerControls;

    public Vector2 movementInput;

    private void OnEnable(){
        if(playerControls == null){
             playerControls = new PlayerControls();
            // PlayerControls라는 InputAction에 액션맵인 PlayerMovement에 액션스에 Movement에 Collback Action event에 추가
            // public event Action<CallbackContext> performed; inputAction.performed에 i를 매개변수로 하는 람다식 추가
            // i람다의 ReadValue로 Vector2값을 받아들이는 식을 사용하여 InputManager의 Vector2 movementInput에 전달
            // InputACtion의 performed와 ReadValue<>()를 사용하는 이름없는 함수식
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            // playerControls.PlayerMovement.Movement.performed +=PerformedHandler;
            // void PerformedHandler(CallbackContext context) {
            // // i 대신에 context를 지정해줄 함수 performedHandler;
            // movementInput = context.ReadValue<Vector2>()}
        }
        playerControls.Enable();    // PlayerControls는 Enable와 Disable을 해야한다.
    }

    private void OnDisable(){
        playerControls.Disable();
    }
}
