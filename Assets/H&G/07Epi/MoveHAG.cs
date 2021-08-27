/*
 * - Name : MoveHAG.cs
 * - Writer : 최대준
 * 
 * - Content :
 * 화면을 터치시에 헨젤과 그레텔 오브젝트가 새를 따라가는 동작을 정의한 클래스이다. 
 * 
 * - History
 * 1) 2021-08-05 : 코드 구현. 
 * 2) 2021-08-06 : 주석 작성.
 *  
 * - Variable                    
 * mv3_TargetPos                        타겟 위치인 새의 위치를 나타내주는 변수이다.                                           
 * mb_StartWalk                         헨젤과 그레텔이 움직임을 시작하는 것을 표현한 변수이다.                                                              
 *
 * - Function
 * Update()                             이 스크립트 컴포넌트를 가진 오브젝트를 통해 다른 스크립트가 접근하여 SetTargetPos를 호출했을 경우에만 헨젤과 그레텔을 움직이게 된다.        
 * SetTargetPos(Vector3 v3TargetPos)    다른 스크립트 클래스에서 접근할 수 있는 함수로, 여기서 새의 위치를 갱신한다. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 헨젤과 그레텔의 움직임을 정의한 클래스이다.
public class MoveHAG : MonoBehaviour {
    private Vector3 mv3_TargetPos;      // 새의 위치를 나타내주는 변수이다.
    private bool mb_StartWalk = false;  // 헨젤과 그레텔이 걸을지 안걸을지 표현하는 변수이다.
    
    // mb_StartWalk가 true로 바뀌면, 헨젤과 그레텔을 점차 새 위치로 움직인다.
    void Update() {
        if(mb_StartWalk == true) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(mv3_TargetPos.x, transform.position.y, mv3_TargetPos.z), 0.5f * Time.deltaTime);
        }
    }

    // 다른 스크립트 클래스에서 접근하여 호출하는 함수이다. 여기서 새의 위치를 갱신하게 된다.
    public void SetTargetPos(Vector3 v3TargetPos) {
        mv3_TargetPos = v3TargetPos;
        mb_StartWalk = true;
    }

}
