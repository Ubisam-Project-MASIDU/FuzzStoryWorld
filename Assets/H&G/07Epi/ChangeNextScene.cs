/*
 * - Name : ChangeNextScene.cs
 * - Writer : 최대준
 * 
 * - Content :
 * 헨젤과 그레텔 게임 오브젝트가 해당 스크립트 클래스 컴포넌트가 들어가 있는 오브젝트에 부딪히면, 1초 후에 changeNextScene함수를 호출하여 씬을 다음 씬으로 옮기도록 하였다.
 * 
 * - History
 * 1) 2021-08-05 : 코드 구현. 
 * 2) 2021-08-06 : 주석 작성.
 *  
 * - Variable 
 * null
 * 
 * - Function
* OnTriggerEnter(Collider cCollider)                      해당 오브젝트의 컴포넌트인 콜라이더 박스에 다른 콜라이더 박스가 닿았을 때, 호출되는 함수이다. 여기서는 헨젤과 그레텔 오브젝트와 닿았을 때 v_changeNextScene 1초후에 호출하도록 하여 다음 씬으로 넘어가도록 하였다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 다음 씬으로 넘어가는 동작을 정의한 스크립트 클래스이다.
public class ChangeNextScene : MonoBehaviour {
    
    // 해당 오브젝트의 컴포넌트에서 콜라이더 박스에 무언가 닿았다면 호출된다.
    private void OnTriggerEnter(Collider cCollider) {
        if (cCollider.tag == "HAG") {
            Invoke("v_changeNextScene", 0.2f);
        }
    }

    // 다음 씬을 호출하는 함수이다.
    private void v_changeNextScene() {
        SceneManager.LoadScene("1_08H&G");
    }
    
}
