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
 * 2021-08-13 : 소리 나오게는 스크립 적용
 * 2021-08-17 : 오류 수정 및 마우스로 입력 되었을 때 움직이게 수정
 * 2021-08-26 : 오류 수정 및 소리 설정 다시 체크 
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
    
    private bool state;                                                    // 참과 거짓 판별하게 작성
    GameObject ControlMonster;

    GameObject mg_SoundManager;
    
    void Start(){
        mg_SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결
        ControlMonster = GameObject.Find("ControlMonster");
        state = true;
    }

    private void OnMouseDown() {   
        if (T_Monster_HP <= 0) {                                            // 몬스터의 HP가 0보다 작으면 죽는경우 설정
            ControlMonster.GetComponent<ControlMonster>().Delete();
            GetComponent<ActiveTrashMonster>().enabled = false;               // soundEffects에서 설정한 소리 가져오게 한다 
            
            if (Input.GetMouseButtonDown(0)) {                              // 마우스로 클릭 하였을 때 캐릭터가 죽으면서 소리나게 하기
                print("마우스 입력 받았음");
                if(state == true) {
                    gameObject.SetActive(false);
                    Invoke("destroyTrash", 1f);                           // 바로 죽지 않고 0.4초 딜레이 후 삭제
                    mg_SoundManager.GetComponent<SoundManager>().playSound("Die");     // 몬스터가 죽었을 때 효과음 재생
                    print("사라져");
                    state = true;
                } else {
                    gameObject.SetActive(true);                 
                    print("생겨나");
                    state = false;
                }
            }
        } else {
            T_Monster_HP -= 1;                                               // 몬스처를 터치하여 HP감소
            GetComponent<SoundEffectes>().PlaySound("ATTACK");               // soundEffects에서 설정한 소리 가져오게 한다
            Debug.Log("클릭");
        }
    }
    private void destroyTrash() {                                            // 몬스터를 삭제시킨다
        Destroy(gameObject);
    }
}