/*
 * - Name : CheckAnswer.class
 * - Writer : 이윤교
 * - Content : 헨젤과 그레텔 Epi8 미니 게임 - 충돌 시 정답 확인 및 정답일 경우 오브젝트 삭제
 *                                     
 * - HISTORY
 * 2021-08-10 : 초기 개발
 * 2021-08-11 : 코드 획일화 및 주석처리
 *
 * <Variable>
 * mg_GameDirector : GameDirector오브젝트 연결을 위한 변수
 * mg_RandomItem : RandomItem 오브젝트 연결을 위한 변수
 * mn_answer : 정답을 저장해두는 변수
 * mn_LeftTime : 남은 횟수를 저장해두는 변수
 * SoundManager : 효과음 재생 연결 오브젝트
 *
 * <Function>
 * OnTriggerEnter2D(Collider2D cCollidObj) : 오브젝트가 충돌됬을때 작동되는 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswer : MonoBehaviour{
    GameObject mg_GameDirector;
    GameObject mg_RandomItem;
    int mn_answer;
    int mn_LeftTime;
    GameObject SoundManager;

    void Start(){
        this.mg_GameDirector = GameObject.Find("GameDirector");                                         // 게임오브젝트들 연결
        this.mg_RandomItem = GameObject.Find("RandomImage");
        SoundManager = GameObject.Find("SoundManager");
    }
    void Update(){
        mn_answer = mg_RandomItem.GetComponent<RandomCandy>().n_ReturnAnswer();                         // 실시간으로 정답을 전달받는다
    }
    void OnTriggerEnter2D(Collider2D cCollidObj){
        if(cCollidObj.tag == "Pink"){
            if (mn_answer == 0){                                                                        // 정답인 경우
                SoundManager.GetComponent<SoundManager>().playSound("Eat");                             // 먹는 소리 재생
                Debug.Log("Pink Candy 먹기 성공");
                mg_GameDirector.GetComponent<CandyControl>().v_CheckRandomItemArr(0);                   // 정답배열에 해당 아이템이 정답처리가 되었다고 표시
                mn_LeftTime = mg_GameDirector.GetComponent<CandyControl>().n_HowManyleftArr();          // 남은 횟수 확인 및 값 저장
                Destroy(cCollidObj.gameObject);
                mg_GameDirector.GetComponent<CandyControl>().v_ChangeFlagTrue();                        // 정답이 되었다고 flag값 변경  
            }else{                                                                                      // 오답인 경우
                Debug.Log("Pink Candy 먹기 실패");
            }
        }else if(cCollidObj.tag == "Yellow"){
            if (mn_answer == 1){                                                                        // 정답인 경우
                SoundManager.GetComponent<SoundManager>().playSound("Eat");                             // 먹는 소리 재생
                Debug.Log("Yellow Candy 먹기 성공");
                mg_GameDirector.GetComponent<CandyControl>().v_CheckRandomItemArr(1);                   // 정답배열에 해당 아이템이 정답처리가 되었다고 표시
                mn_LeftTime = mg_GameDirector.GetComponent<CandyControl>().n_HowManyleftArr();          // 남은 횟수 확인 및 값 저장
                Destroy(cCollidObj.gameObject);
                mg_GameDirector.GetComponent<CandyControl>().v_ChangeFlagTrue();                        // 정답이 되었다고 flag값 변경  
            }else{                                                                                      // 오답인 경우
                Debug.Log("Yellow Candy 먹기 실패");    
            }
        }else if(cCollidObj.tag == "Blue"){
            if (mn_answer == 2){                                                                        // 정답인 경우
                SoundManager.GetComponent<SoundManager>().playSound("Eat");                             // 먹는 소리 재생
                Debug.Log("Blue Candy 먹기 성공");
                mg_GameDirector.GetComponent<CandyControl>().v_CheckRandomItemArr(2);                   // 정답배열에 해당 아이템이 정답처리가 되었다고 표시
                mn_LeftTime = mg_GameDirector.GetComponent<CandyControl>().n_HowManyleftArr();          // 남은 횟수 확인 및 값 저장
                Destroy(cCollidObj.gameObject);
                mg_GameDirector.GetComponent<CandyControl>().v_ChangeFlagTrue();                        // 정답이 되었다고 flag값 변경  
            }else{                                                                                      // 오답인 경우
                Debug.Log("Blue Candy 먹기 실패");
            }
        }
    }
}
