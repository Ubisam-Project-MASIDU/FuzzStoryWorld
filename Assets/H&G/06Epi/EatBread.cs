/*
 * - Name : EatBreads.class
 * - Writer : 이예은
 * 
 * - Content :
 *  게임오브젝트를 삭제하고 정지시키는 함수 작성
 *  나레이션 출력 함수 작성
 *
 * - HISTORY
 * 2021-08-05 : 초기 개발
 * 2021-08-06 : 개발 수정
 * 2021-08-09 : 코드 획일화 및 주석처리
 *
 * - Variable 
 * mgo_Bread1                                  큰빵 게임오브젝트
 * mgo_Bread2                                  작은빵 게임오브젝트
 * mv3_Empty                                   새가 이동할 최종 위치 변수
 * mvm_VoiceManager                            음성 출력 변수
 * mb_Check                                    빵이 사라졌는지 확인하기 위한 논리형 변수
 * mb_playonce                                 음성을 한번 출력하기 위한 논리형 변수
 * mb_tellonce                                 changeNextScene() 함수를 한번 출력하기 위한 논리형 변수
 * 
 * <Function>
 * void Stop() : 게임 오브젝트 정지 함수
 * void destroyB1() : mgo_Bread1 제거 함수
 * void destroyB2() : mgo_Bread2 제거 함수
 * void changeNextScene() : 다음 씬으로 넘어가는 함수 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    // Epi6에서 나오는 게임오브젝트 소멸 스크립트
public class EatBread : MonoBehaviour
{
    // 바닥에 떨어진 빵 부스러기를 없애기 위해 필요한 변수들
    public GameObject mgo_Bread1;
    public GameObject mgo_Bread2;
    public GameObject mv3_Empty;
    private bool mb_Check = true;

    // 음성출력에 필요한 변수들
    private VoiceManager mvm_VoiceManager; 
    private bool mb_playonce = false;
    private bool mb_tellonce = false;


    // Epi6 시작하자마자 나레이션 출력
    void Start() {
        mvm_VoiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }
    void Update()
    {
    if(mvm_VoiceManager.mb_checkSceneReady && !mb_playonce) {
    // 나레이션 한번 출력 
        mvm_VoiceManager.playVoice(0);
        mb_playonce = true;
    }

    if(mvm_VoiceManager.isPlaying() == false && mvm_VoiceManager.mb_checkSceneReady && !mb_tellonce) {
        // 음성 출력이 끝나면 다음 씬으로 이동
        changeNextScene();  
        mb_tellonce = true;
    }

    if(Mathf.Abs(mgo_Bread1.transform.position.x - transform.position.x) < 1.0 && mb_Check) {
    // 빵1이 게임오브젝트와 근사하면
    // 빵1 없애기
        Invoke("destroyB1", 1f);
        mb_Check = false;
    } else if(Mathf.Abs(mgo_Bread2.transform.position.x - transform.position.x) < 0.7 
            && !mb_Check) {
    // 빵2가 게임오브젝트와 근사하면
    // 빵2 없애기
    // 빵2가 없어지면 게임 오브젝트도 정지
        Invoke("destroyB2", 1f);
        Invoke("Stop",1.3f);
    } else {
     transform.position = Vector3.MoveTowards(transform.position, mv3_Empty.transform.position, 0.5f * Time.deltaTime);
    // 최종 위치인 mv_Empty까지 걷기
        }
    }
    
    // 게임오브젝트 정지시키는 함수
    void Stop() {
        Time.timeScale = 0;
    }

    // 빵1 사라지게하는 함수
    void destroyB1() {
        mgo_Bread1.GetComponent<SpriteRenderer>().sprite = null;      
 
    }

    
    // 빵2 사라지게하는 함수
    void destroyB2() {
        mgo_Bread2.GetComponent<SpriteRenderer>().sprite = null;      
 
    }

    // 다음 씬으로 넘어가는 함수
    void changeNextScene() {
        SceneManager.LoadScene("1_07H&G");
    }
}
