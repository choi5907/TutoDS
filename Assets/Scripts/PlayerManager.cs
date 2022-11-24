using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // 스크립트 불러오기
    InputManager inputManager;
    CameraManager cameraManager;
    PlayerLocomotion playerLocomotion;
    
    private void Awake() {
        inputManager = GetComponent<InputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }
    // InputManager의 수평, 수직 입력값을 불러온다.
    private void Update() {
        inputManager.HandleAllInputs();
    }
    // PlayerLocomotion의 이동,회전제어 함수를 불러온다.
    // 이동을 처리하는 과정을 FixedUpdate에서 처리하는게 좋다.
    private void FixedUpdate() {
        playerLocomotion.HandleAllMovement();
    }
    // 업데이트와 동일하지만 프레임이 끝나고 실행
    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
    }
}
