/*
 * - Name : MoveTrashMonster.cs
 * - Writer : 이병권
 * - Content : 헨젤과그레텔Epi10 - 자동으로 쓰레기 몬스터 들이 움직이는 스크렙
  
 * 1. HISTORY (수정기록)
 * 1) 2021-08-5 : 초기 개발
 * 2) 2021-08-9 : 파일 인코딩 수정
 * 3) 2021-08-11 : 주석 처리 수정
 * 4) 2021-08-23 : 주석 수정
 
 * 2. <Function> 쓴것들에 대하여 설명
 * 1) currentPostion : 현제 위치표시 하는 변수
 * 2) rightMax : 캐릭터가 좌로 움직일 수 있는 총량 설정하는 변수
 * 3) leftMax : 캐릭터가 우로 움직일 수 있는 총량 설정하는 변수
 * 4) direction : 캐릭터가 움직일 때 이동하는 속도와 방향
 *  
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTrashMonster : MonoBehaviour{
    float rightMax = 7.0f;                              // 좌로 이동가능한 (x)최대값
    float leftMax = -3.0f;                              // 우로 이동가능한 (x)최대값
    float currentPosition;                              // 현재 위치(x) 저장
    float direction = 3.0f;                             // 이동속도+방향
    bool isStop = false;
    void Start() {
        currentPosition = transform.position.x;
    }

    void Update() {
        currentPosition += Time.deltaTime * direction;
        if(!isStop){
            if (currentPosition >= rightMax) {
                // 현재 위치(x)가 우로 이동가능한 (x)최대값보다 크거나 같다면
                // 이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 우로 이동가능한 (x)최대값으로 설정
                direction *= -1;
                currentPosition = rightMax;
            } else if (currentPosition <= leftMax) {
                // 현재 위치(x)가 좌로 이동가능한 (x)최대값보다 크거나 같다면
                // 이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 좌로 이동가능한 (x)최대값으로 설정
                direction *= -1;
                currentPosition = leftMax;    
            }
            
            // "Stone"의 위치를 계산된 현재위치로 초기화
            transform.position = new Vector3(currentPosition, this.transform.position.y , this.transform.position.z);
            v_isStop(false);
        }
    }

    void v_isStop(bool stop){
        isStop = stop;
    }
}

