/*
 * - Name : WitchAttack.cs
 * - Writer : 이예은
 * 
 * - Content :
 * 마녀가 헨젤과 그레텔에게 공격하는 것을 표현하는 스크립트 클래스이다.
 * 
 * - History
 * 1) 2021-08-18 : 코드 구현 
 * 2) 2021-08-13 : 주석 작성
 *  
 * - Variable 
 *
 * - Function
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WitchAttack : MonoBehaviour
{
    public GameObject mgo_HAG;     

    void Update() {

        if(Mathf.Abs(mgo_HAG.transform.position.x - transform.position.x) < 3.0 ) {
            Invoke("CreateEffect", 0.1f);
        } else {
            Invoke("FinishEffect", 1f);
        }
    }
 
    void CreateEffect() {
        this.transform.GetChild(0).gameObject.SetActive(true);
    }
    void FinishEffect() {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
}
