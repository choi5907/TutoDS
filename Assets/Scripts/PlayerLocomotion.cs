using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    // InputManager에서 분할된 수평수직 값을 가져오기위한 변수, 정규화용 Vector3변수, 바라보는 방향판단 변수, 등속운동을위한 변수
    // 속도변수
    InputManager inputManager;
    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    public float movementSpeed = 7;

    // 컴포넌트 가져오기
    private void Awake() {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void HandleMovement(){
        // 수직(vertical), 수평(horizontal) 방향의 입력값에 따라 카메라가 향한 방향에서 이동
        // (Vector3)forward - World에서 파란색축(Z축)을 나타내는 정규화 벡터 반환 // 세로
        // (Vector3)right - World에서 빨간색축(X축)을 나타낸다. // 가로
        // Vector3인 moveDirection을 정규화 시키고 y값은 0으로 초기화한다.
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * movementSpeed;  // 벡터 각각의 값에 7을 곱한다

        // 정규화 한 이동값을 새 Vector3에 저장
        // 저장한 값을 Rigidbody로 생성한 오브젝트에서 velocity값으로 준다.
        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;
    }

    // 수평, 수직값만큼 카메라방향으로의 이동을
    // 회전값을 주어 객체 자체를 회전한다.
    public void HandleRotation(){
        // 회전값 Vector3오브젝트 초기화
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

    }
}
