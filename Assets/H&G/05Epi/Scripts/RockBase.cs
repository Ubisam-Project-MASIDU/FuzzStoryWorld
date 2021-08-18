/*
 * - Name : RockBase.cs
 * - Writer : 이윤교
 * - Content : 오브젝트(조약돌)가 화면 우측에서 시작해서 화면 좌측으로 넘어가면 비활성화
 * 
 * - HISTORY
 * 2021-08-13 : 초기 개발
 * 2021-08-18 : 코드 획일화 및 주석처리
 *
 * <Variable>
 * StartPosition            오브젝트(조약돌) 활성화 될때의 처음 위치
 * 
 * <Function>
 * OnEnable()               오브젝트가 활성화 될때 실행되는 함수 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBase : MonoBehaviour{
    public Vector2 StartPosition;               // Inspector창에서 StartPosition 설정 가능
    private void OnEnable(){
        transform.position = StartPosition;     // 오브젝트(조약돌)가 활성화 될때 우측에서 시작할 수 있게끔 설정      
    }
    void Update(){
        // 게임 시작 버튼을 누르면
        if(GameManager.instance.isPlay){
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed);    // 오브젝트(조약돌) 좌측으로 이동
        }
        // 오브젝트(조약돌)의 X좌표가 -6보다 작아지면 
        if(transform.position.x < -6){
            // 오브젝트(조약돌)를 비활성화 
            gameObject.SetActive(false);
        }
    }
}
