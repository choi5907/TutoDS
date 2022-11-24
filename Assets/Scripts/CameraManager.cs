using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;

    public Transform targetTransform;   // The object the camera will follow
    public Transform cameraPivot;       // The object the camera uses to pivot (Look up and down)
    public Transform cameraTransform;   // The transfrom of the actual camera object in the scene
    public LayerMask collisionLayers;   // The layers we want our camera to collide with
    private float defaultPosition;
    private Vector3 cameraFollowVelocity = Vector3.zero;

    public float cameraCollisionRadius = 2;
    // 카메라가 타겟을 쫓는데 걸리는 시간
    public float cameraFollowSpeed = 0.2f;
    // 카메라의 두 축이 이동하는 값을 가진 변수에 포함되는 속도값, 따라오는 속도를 저장한 변수
    public float cameraLookSpeed = 2;
    public float cameraPivotSpeed = 2;

    public float lookAngle;     // 카메라가 위아래를 보게하는 함수
    public float pivotAngle;    // 카메라가 좌우를 보게하는 함수
    public float minimumPivotAngle = -35; // 카메라피봇의 수직 최저값
    public float maximumPivotAngle = 35; // 카메라피봇의 수직 최대값

    private void Awake() {
        inputManager = FindObjectOfType<InputManager>();
        // PlayerManager의 위치값을 목표로 움직이므로 컴포넌트의 위치를 가져온다.
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        // 씬을 재생했을 때 가진 카메라의 transform값
        cameraTransform = Camera.main.transform;
        // z축의 값을 저장하는 변수
        defaultPosition = cameraTransform.localPosition.z;
    }

    public void HandleAllCameraMovement(){
        FollowTarget();
        RotateCamera();
    }

    private void FollowTarget(){
        // Vector3.SmoothDamp(변화시킬 값, 목표값, 현재변화량[속도], 목표까지 도달하는 시간)
        // 변화
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;
    }

    private void RotateCamera(){
        Vector3 rotation;
        Quaternion targetRotation;


        // 카메라의 입력값을 가진 두 축의 변수를 이동값에 따라 변화하게 하는 변수
        lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed);
        // 수직 값의 최저최대 상한선을 가지게 한다
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);

        // 카메라의 수평회전
        // 방향값을 가진 쿼터니언 변수에 Quaternion.Euler() 적용
        // Euler() - x, y, z축의 회전한 각도를 저장하는 함수
        // targetROtation > rotation.y > lookAngle > inputManager.cameraInputY 값을 저장한 것을 현재 rotation에 저장
        // 수평 회전값을 현재 회전률에 적용
        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        // 카메라의 수직회전
        // Vector3 초기화 > x에 값 저장 > 쿼터니언 초기화 > cameraPivot의 회전 값을 변경한다.
        // localRotation는 cameraPivot의 부모인 CameraManager에 상대적인 회전을 주는 변수.
        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }

    private void HandleCameraCollisions(){
        // targetPosition에 카메라의 z축값을 넣어준다.
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector2 direction = cameraTransform.position - cameraPivot.position;
        // 어떤 각도로 이동해도 등속이동 하기 위한 정규화
        direction.Normalize();

        //if(Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers)) 
    }
}
