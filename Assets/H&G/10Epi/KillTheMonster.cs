/*
 * - Name : KilltheMonster.cs
 * - Writer : 이병권
 * 
 * - Content : 
 * 쓰레기 몬스터 설정 스크립트
 * -1) 몇번을 터치하여 죽게할 것인지 설정
 * -2) 몬스터가 체력이 달아서 죽게 만든다
 * -3) 몬스터가 사라질 때 소리가 나게 하는 스크립트 적용 --> 눈에 보이지 않게하고, 보이게 하는 것을 한다
 * -4) 몬스터가 체력이 달때 소리가 나게 하는 스크립트 적용
 *            
 * -수정 기록-
 * 2021-08-10 : 초기 개발
 * 2021-08-11 : 주석 작성
 * 
 * - Variable 
 * T_Monster_HP : 쓰레기 몬스터 HP 설정 변수
 *
 * -Function()
 * OnMouseDown() : 바이러스 클릭시 작동되는 함수
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillTheMonster : MonoBehaviour {
    private int T_Monster_HP = 2;                                          // 몬스터의 채력 범위 설정
    
    private bool state; 
    GameObject ControlMonster;
    
    void Start(){
        ControlMonster = GameObject.Find("ControlMonster");
        state = true;
    }

    private void OnMouseDown() {   
        if (T_Monster_HP <= 0) {                                            // 몬스터의 HP가 0보다 작으면 죽는경우 설정
            ControlMonster.GetComponent<ControlMonster>().Delete();
            GetComponent<SoundEffectes>().PlaySound("DIE");                 // soundEffects에서 설정한 소리 가져오게 한다 
            
            if (Input.GetMouseButtonDown(0)) {
                print("마우스 입력 받았음");
                if(state == true) {
                    gameObject.SetActive(false);
                    GetComponent<TrashMonsterMove>().enabled = false;
                    Invoke("destroyTrash", 0.4f);                           // 바로 죽지 않고 0.4초 딜레이 후 삭제
                    print("사라져");
                    state =  false;
                }
                
                else {
                    gameObject.SetActive(true);                 
                    print("생겨나");
                    state = true;
                }
            }
        }
        else {
            T_Monster_HP -= 1;                                               // 몬스처를 터치하여 HP감소
            GetComponent<SoundEffectes>().PlaySound("ATTACK");               // soundEffects에서 설정한 소리 가져오게 한다
            Debug.Log("클릭");
        }
    }
    private void destroyTrash() {                                            // 몬스터를 삭제시킨다
        Destroy(gameObject);
    }
}