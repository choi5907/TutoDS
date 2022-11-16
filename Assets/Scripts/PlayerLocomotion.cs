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

    // 정규화된 벡터에 속력을 넣어줄 변수
    public float movementSpeed = 7;
    // 구면선형보간함수의 회전에 걸리는 시간 변수
    public float rotationSpeed = 15;

    // 컴포넌트 가져오기
    // InputManager 스크립트, 카메라 오브젝트의 값
    private void Awake() {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    // private로 바꾸고 함수로 묶어서 호출한다. 이동,회전제어를 외부에서 받는 함수
    public void HandleAllMovement(){
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement(){
        // 수직(vertical), 수평(horizontal) 방향의 입력값에 따라 카메라가 향한 방향에서 이동
        // (Vector3)forward - World에서 파란색축(Z축)을 나타내는 정규화 벡터 반환 // 세로
        // (Vector3)right - World에서 빨간색축(X축)을 나타낸다. // 가로
        // Vector3인 moveDirection을 정규화 시키고 y값은 0으로 초기화한다.
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * movementSpeed;  // 정규화된 벡터의 값에 각각 7을 곱한다

        // 정규화 한 이동값을 새 Vector3에 저장
        // 저장한 값을 Rigidbody로 생성한 오브젝트에서 velocity값으로 준다.
        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;
    }

    // 수평, 수직값만큼 카메라방향으로의 이동을
    // 회전값을 주어 객체 자체를 회전한다.
    private void HandleRotation(){
        // 회전값 Vector3오브젝트 초기화
        Vector3 targetDirection = Vector3.zero;
        // 수직 수평값을 정규화 시켜서 쿼터니언으로 변환
        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        // 멈춰있을 때 회전을 유지
        if(targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        // Quaternion.LookRotation(상대좌표, 머리의방향) 2번째 매개변수는 기본으로 월드좌표의 위쪽이다.
        // 벡터 방향을 바라보는 회전 상태를 반환하고 쿼터니언을 넣어준다. 벡터 사용x
        // 쿼터니언 값에 해당하는 방향을 바라본다. 정규화된 해당 쿼터니언을 바라보는 함수.
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        // Quaternion.Slerp(회전a, 회전b, 시간) // 일정 시간을 두어 목표하는 방향으로 회전
        // 회전a: 해당 오브젝트의 회전값, 회전b: 바라볼 오브젝트, 시간
        // 내가보는 방향에서부터 바라볼 방향까지 시간에 맞춰서 움직이므로 부드럽게 회전한다.
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        // 보간된 쿼터니언을 오브젝트에 넣어준다.
        transform.rotation = playerRotation;
    }
}
