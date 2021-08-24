/*
 * - Name : JumpHG.cs
 * - Writer : 이예은, 최대준
 * 
 * - Content :
 * 헨젤과 그레텔이 책으로 점프하는 것을 구현한 코드이다.
 * - History
 * 1) 2021-08-05 : 코드 구현. 
 * 2) 2021-08-09 : 주석 작성.
 *  
 * - Variable                    
 * mv3_TargetPos        헨젤과 그레텔이 어느정도 위치로 이동한 후에, 점프를 할 것인데, 그때 어느정도 위치로 이동하는 기준 위치가 되주는 오브젝트 변수이다.
 * mb_CheckOnceJump     헨젤과 그레텔이 점프하는 것을 AddForce로 구현하였기에 계속해서 힘을 가해주는 것이 아니라 한번만 힘을 가해주어야 점프처럼 보이기 때문에 그것을 판명하기 위한 flag 변수이다.
 * 
 * - Function
 * Update()             책과 헨젤과그레텔이 부딪히면, 헨젤과 그레텔 오브젝트를 없애고, 이펙트를 생성하도록 구현하였다.
 * jump()               다음 씬으로 넘어가도록 구현한 함수이다. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHG : MonoBehaviour {
    public GameObject mv3_TargetPos;
    private bool mb_CheckOnceJump = true;

    void Update() {
        if (Mathf.Abs(mv3_TargetPos.transform.position.x - transform.position.x) < 0.001 && mb_CheckOnceJump) {
            Invoke("jump", 1.5f); 
            mb_CheckOnceJump = false;
        } else {
            transform.position = Vector3.Slerp(transform.position, mv3_TargetPos.transform.position, 0.4f * Time.deltaTime);
        }
    }
    void jump() {
        gameObject.GetComponent<Rigidbody>().AddForce(75f, 300f, 25f);
    }
}
