using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // InputAction PlayerControls스크립트 변수, 입력값을 X, Y축으로 받을 2D Vector변수
    PlayerControls playerControls;
    AnimatorManager animatorManager;

    // 아날로그 스틱을 예로 중심축 두개의 입력값을 저장하는 변수 (키보드 WS AD)
    public Vector2 movementInput;
    // 입력값 저장하는 변수처럼 카메라가 이동해야될 값을 저장하는 변수
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;
    
    // 수직입력을 받는 변수, 수평입력을 받는 변수 -> movementInput을 개별변수로 분할해서 담는다.
    private float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    private void Awake(){
        animatorManager = GetComponent<AnimatorManager>();
    }
    // movementInput을 분할하는 함수 movementInput의 x,y값인 0~1을 가져온다.
    private void OnEnable(){
        if(playerControls == null){
             playerControls = new PlayerControls();
            // PlayerControls라는 InputAction에 액션맵인 PlayerMovement에 Actions에 Movement에 Collback Action event에 추가
            // public event Action<CallbackContext> performed; inputAction.performed에 i를 매개변수로 하는 람다식 추가
            // i람다의 ReadValue로 Vector2값을 받아들이는 식을 사용하여 InputManager의 Vector2 movementInput에 전달
            // InputAction의 performed와 ReadValue<>()를 사용하는 이름없는 함수식
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            // playerControls.PlayerMovement.Movement.performed += PerformedHandler;
            // void PerformedHandler(CallbackContext context) {
            // // i 대신에 context를 지정해줄 함수 performedHandler;
            // movementInput = context.ReadValue<Vector2>()}
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
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
        // 두 축의 값을 따로 저장하여 Mathf함수를 적용하기 위한 변수
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        // 카메라의 이동을 위한 두 축의 값을 저장하는 변수
        // CameraManager.cs에서 값을 호출하여 사용
        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;

        // Mathf.Clamp - 특정 범위를 벗어나지 않도록 도와주는 함수, Clamp01 - 0과 1사이의 값을 반환한다
        // Mathf.Abs - 데이터 절대값 반환
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }
}
