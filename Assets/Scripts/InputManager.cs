using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // InputAction PlayerControls스크립트 변수, 입력값을 X, Y축으로 받을 2D Vector변수
    PlayerControls playerControls;

    public Vector2 movementInput;
    // 수직입력을 받는 변수, 수평입력을 받는 변수 -> movementInput을 개별변수로 분할해서 담는다.
    public float verticalInput;
    public float horizontalInput;

    // movementInput을 분할하는 함수 movementInput의 x,y값인 0~1을 가져온다.
    private void OnEnable(){
        if(playerControls == null){
             playerControls = new PlayerControls();
            // PlayerControls라는 InputAction에 액션맵인 PlayerMovement에 액션스에 Movement에 Collback Action event에 추가
            // public event Action<CallbackContext> performed; inputAction.performed에 i를 매개변수로 하는 람다식 추가
            // i람다의 ReadValue로 Vector2값을 받아들이는 식을 사용하여 InputManager의 Vector2 movementInput에 전달
            // InputAction의 performed와 ReadValue<>()를 사용하는 이름없는 함수식
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
    

    // 수직, 수평으로 입력받는 함수를 외부로 보내는 함수
    public void HandleAllInputs(){
        HandleMovementInput();
        // HandleJumpingInput
        // HandleActionInput
    }

    private void HandleMovementInput(){
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }
}
