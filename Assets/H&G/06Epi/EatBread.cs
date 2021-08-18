/*
 * - Name : BirdEatBreads.class
 * - Writer : 이예은
 * 
 * - Content :
 *  새가 빵(게임오브젝트)를 먹고(삭제)하고 새를 정지시키는 함수 작성
 *  나레이션 출력 함수 작성
 *
 * - HISTORY
 * 1) 2021-08-05 : 초기 개발
 * 2) 2021-08-06 : 개발 수정
 * 3) 2021-08-09 : 코드 획일화 및 주석처리
 * 4) 2021-08-10 : 주석 수정
 *
 * - Variable 
 * mgo_BigBread                                큰빵 게임오브젝트
 * mgo_SmallBread                              작은빵 게임오브젝트
 * mv3_FinalPos                                새가 이동할 최종 3차원 위치 변수
 * mvm_VoiceManager                            음성 출력 변수
 * mb_CheckBread                               빵이 사라졌는지 확인하기 위한 논리형 변수
 * mb_PlayOnce                                 음성을 한번 출력하기 위한 논리형 변수
 * mb_TellOnce                                 changeNextScene() 함수를 한번 출력하기 위한 논리형 변수
 * 
 * <Function>
 * void Stop()                                 게임 오브젝트 정지 함수
 * void DestroyBigBread()                      mgo_BigBread 제거 함수
 * void DestroySmallBread()                    mgo_SmallBread 제거 함수
 * void ChangeNextScene()                      다음 씬으로 넘어가는 함수 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    // Epi6에서 나오는 게임오브젝트 소멸 스크립트
public class EatBread : MonoBehaviour
{
    // 바닥에 떨어진 빵 부스러기를 없애기 위해 필요한 변수들
    public GameObject mgo_BigBread;
    public GameObject mgo_SmallBread;
    public GameObject mv3_FinalPos;
    private bool mb_CheckBread = true;

    // 음성출력에 필요한 변수들
    private VoiceManager mvm_VoiceManager; 
    private bool mb_PlayOnce = false;
    private bool mb_TellOnce = false;

    // 나레이션 출력
    void Start() {
        mvm_VoiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }

    void Update() {
        // 나레이션 한번 출력 
        if(mvm_VoiceManager.mb_checkSceneReady && !mb_PlayOnce) {
            mvm_VoiceManager.playVoice(0);
            mb_PlayOnce = true;
        }
        
        // 음성 출력이 끝나면 다음 씬으로 이동
        if(mvm_VoiceManager.isPlaying() == false && mvm_VoiceManager.mb_checkSceneReady && !mb_TellOnce) {
            ChangeNextScene();  
            mb_TellOnce = true;
        }

        if(Mathf.Abs(mgo_BigBread.transform.position.x - transform.position.x) < 1.0 && mb_CheckBread) {
            // 큰 빵이 게임오브젝트와 근사하면
            // 큰 빵 없애기
            Invoke("DestroyBigBread", 1f);
            mb_CheckBread = false;
            
        } else if(Mathf.Abs(mgo_SmallBread.transform.position.x - transform.position.x) < 0.7 && !mb_CheckBread) {
            // 작은 빵이 게임오브젝트와 근사하면
            // 작은 빵 없애기
            // 작은 빵이 없어지면 게임 오브젝트도 정지
            Invoke("DestroySmallBread", 1f);
            Invoke("Stop", 1.3f);
            
        } else {
            // 최종 위치인 mv_FinalPos까지 걷기
            transform.position = Vector3.MoveTowards(transform.position, mv3_FinalPos.transform.position, 0.5f * Time.deltaTime);
        }
    }
    
    // 게임오브젝트 정지시키는 함수
    void Stop() {
        Time.timeScale = 0;
    }

    // 큰 빵 사라지게하는 함수
    void DestroyBigBread() {
        mgo_BigBread.GetComponent<SpriteRenderer>().sprite = null;      
 
    }
    
    // 작은 빵 사라지게하는 함수
    void DestroySmallBread() {
        mgo_SmallBread.GetComponent<SpriteRenderer>().sprite = null;      
    }

    // 다음 씬으로 넘어가는 함수
    void ChangeNextScene() {
        SceneManager.LoadScene("1_07H&G");
    }
}
