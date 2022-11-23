using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform targetTransform; // The object the camera will follow
    private Vector3 cameraFollowVelocity = Vector3.zero;
    public float cameraFollowSpeed = 0.2f;

    public float lookAngle;     // 카메라가 위아래를 보게하는 함수
    public float pivotAngle;    // 카메라가 좌우를 보게하는 함수

    private void Awake() {
        // PlayerManager의 위치값을 목표로 움직이므로 컴포넌트의 위치를 가져온다.
        targetTransform = FindObjectOfType<PlayerManager>().transform;
    }

    public void FollowTarget(){
        // Vector3.SmoothDamp(변화시킬 값, 목표값, 현재변화량[속도], 목표까지 도달하는 시간)
        // 변화
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;
    }

    public void RotateCamera(){
        //lookAngle = lookAngle + (mouseXInput * cameraLookSpeed);
        //pivotAngle = pivotAngle - (mouseYInput * cameraPivotSpeed);
    }
}
