/*
 * - Name : ClickAnim.cs
 * - Writer : 최대준
 * 
 * - Content :
 * 깜빡이는 동작을 정의한 스크립트 클래스이다.
 * 
 * - History
 * 1) 2021-08-05 : 코드 구현. 
 * 2) 2021-08-06 : 주석 작성.
 *  
 * - Variable 
 * mf_CountTime                                     시간을 재기 위한 변수이다.
 * mn_CountSecond                                   시간을 재기 위한 변수이다. 1 2 3 4 5 ... 의 초단위 시간이 지난 것을 표현한다.
 *
 * - Function
 * Update()                                         1초 마다 오브젝트의 그림을 보였다가 안 보여 줬다가 해서, 깜빡이는 효과를 표현하였다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 깜빡이는 효과를 표현하는 스크립트 클래스이다.
public class ClickAnim : MonoBehaviour {
    private float mf_CountTime = 0f;        // 소수점 단위의 시간을 표현한다.
    private int mn_CountSecond = 1;         // 정수 단위의 시간을 표현한다.
    
    // 업데이트 함수에서는 1초 마다 그림을 껏다 켰다 하는 동작을 표현한다.
    void Update() {
        mf_CountTime += Time.deltaTime;
        
        if (mn_CountSecond < mf_CountTime) {
            mn_CountSecond++;
            if (this.GetComponent<SpriteRenderer>().enabled) {
                this.GetComponent<SpriteRenderer>().enabled = false;
            } else {
                this.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
