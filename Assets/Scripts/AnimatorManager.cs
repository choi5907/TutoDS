using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator animator;
    int horizontal;
    int vertical;

    private void Awake() {
        animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

     public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement){
        // Animation Snapping(값이 맞게 떨어지게하는 애니메이션)
        float snappedHorizontal;
        float snappedVertical;
        // 입력한 수평값의 경계값 구간
        #region SnappedHorizontal
        if(horizontalMovement > 0 && horizontalMovement < 0.55f){           // 0 이상 0.54f 이하 = o.5f
            snappedHorizontal = 0.5f;
        }   
        else if(horizontalMovement > 0.55f){                                // 0.56f 이상 = 1
            snappedHorizontal = 1;
        }   
        else if(horizontalMovement < 0 && horizontalMovement > -0.55f){     // 0.1f 이하 -0.55f 이상 = -0.5f
            snappedHorizontal = -0.5f;
        }
        else if(horizontalMovement < -0.55f){                               // -0.56f 이하 = -1
            snappedHorizontal = -1;
        }
        else{
            snappedHorizontal = 0;
        }
        #endregion
        #region SnappedVertical
        if(verticalMovement > 0 && verticalMovement < 0.55f){           // 0 이상 0.54f 이하 = o.5f
            snappedVertical = 0.5f;
        }   
        else if(verticalMovement > 0.55f){                                // 0.56f 이상 = 1
            snappedVertical = 1;
        }   
        else if(verticalMovement < 0 && verticalMovement > -0.55f){     // 0.1f 이하 -0.55f 이상 = -0.5f
            snappedVertical = -0.5f;
        }
        else if(verticalMovement < -0.55f){                               // -0.56f 이하 = -1
            snappedVertical = -1;
        }
        else{
            snappedVertical = 0;
        }
        #endregion
        // 입력된 float값을 경계값으로 구분시켜서 애니메이션을 적용시킨다.( -0.5f, -1값은 절대값으로 바꿔 애니메이션으로 동작한다.)
        // SetFloat("파라메터", 값, damptime, Time.deltaTime); 
        // damptime이 클 수록 값으로 가기까지의 이전 값에 가까운 값이 할당된다. SetFloat의 실행과 현재 실행간의 시간 간격(프레임시간)
        animator.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);
    }
}
