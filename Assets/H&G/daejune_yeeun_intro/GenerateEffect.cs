/*
 * - Name : GenerateEffect.cs
 * - Writer : 이예은, 최대준
 * 
 * - Content :
 * 헨젤과 그레텔이 책에 빠지는 순간 이펙트와 함께 헨젤과 그레텔이 사라지는 것을 표현한 스크립트 코드이다.
 * 
 * - History
 * 1) 2021-08-05 : 코드 구현. 
 * 2) 2021-08-09 : 주석 작성.
 *  
 * - Variable                    
 * mg_RepresentChar     젤과 그레텔의 위치를 표현하기 위한 변수이다.                                           
 * mg_SetEffect         헨젤과 그레텔이 책에 빠지게 되면 나오는 이펙트 오브젝트 변수이다.
 *
 * - Function
 * OnTriggerEnter()     책과 헨젤과그레텔이 부딪히면, 헨젤과 그레텔 오브젝트를 없애고, 이펙트를 생성하도록 구현하였다.
 * v_loadNextScene()    다음 씬으로 넘어가도록 구현한 함수이다. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 책에 헨젤과그레텔이 들어가는 장면을 표현한 스크립트 코드이다.
public class GenerateEffect : MonoBehaviour
{
    public GameObject mg_RepresentChar;     // 헨젤과 그레텔 게임 오브젝트.
    public GameObject mg_SetEffect;         // 이펙트 오브젝트.

    // 책과 헤네젤과그레텔이 부딪히면, 1초후에, 다음씬으로 넘어가도록 하였다.
    void OnTriggerEnter(Collider cCollider) {
        GetComponent<SoundsEffectsSprash>().PlaySound("Enter");  
        Destroy(mg_RepresentChar);
        this.transform.GetChild(0).gameObject.SetActive(true);  
        Invoke("v_loadNextScene", 1f);
    }

    // 다음 씬으로 넘어가도록 정의한 코드.
    void v_loadNextScene() {
        SceneManager.LoadScene("1_01H&G");
    }
}
