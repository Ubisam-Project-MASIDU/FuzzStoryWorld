/*
 * - Name : GroundScroller.cs
 * - Writer : 이윤교
 * - Content : 배경이 화면 우측에서 시작해서 화면 좌측으로 이동
 * 
 * - HISTORY
 * 2021-08-18 : 초기 개발
 * 2021-08-18 : 코드 획일화 및 주석처리
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour{
    void Update(){
        if(GameManager.instance.isPlay){                                // 게임 시작 버튼을 누르면
            transform.Translate(Vector2.left * Time.deltaTime * 1f);    // 배경 좌측으로 이동
        }

    }
}
