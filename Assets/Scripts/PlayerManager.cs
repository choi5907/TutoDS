using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // 스크립트 불러오기
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;
    private void Awake() {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }
    // InputManager의 수평, 수직 입력값을 불러온다.
    private void Update() {
        inputManager.HandleAllInputs();
    }
    // PlayerLocomotion의 이동,회전제어 함수를 불러온다.
    private void FixedUpdate() {
        playerLocomotion.HandleAllMovement();
    }
}