/*
 * - Name : GameManager.cs
 * - Writer : 이윤교
 * - Content : 게임 총괄
 * 
 * - HISTORY
 * 2021-08-13 : 초기 개발
 * 2021-08-18 : 코드 주석처리
 * 2021-08-19 : 효과음 재생 추가
 * 2021-08-23 : 코드 획일화
 * 2021-08-24 : 총 횟수 창 추가
 *
 * <Variable>
 * mf_gameSpeed                ground와 조약돌의 속도 조절 변수
 * mb_isPlay                   게임이 시작됬는지 구분하는 변수
 * mg_playBtn                  게임 시작 버튼 
 * mg_nextBtn                  게임 끝 버튼 
 * mg_Mission                  미션 스크립트 
 * mg_Counts                   총 횟수 창
 * mg_SoundManager             효과음 재생 연결 오브젝트
 *
 * <Function>
 * PlayBtnClick()              게임 시작 버튼을 클릭하면 호출할 매소드
 * GameOver()                  게임 끝 버튼을 클릭하면 호출할 매소드
 * nextScene()                 다음씬으로 넘어가기 위한 매소드
 *
 * delegate                     함수에 대한 참조, 하나의 delegate로 여러 함수들에 접근해 실행 가능, delegate를 이용해 함수를 파라미터로 전달할 수 있고, 
                                여러 함수를 한꺼번에 실행하는 체인 기능과 어떤 상황에 도달했을 때 이벤트를 발생시키는 delegate 이벤트도 제공됨.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    //싱글톤 패턴 구현
    #region instance
    /*
     instance : 게임매니저의 인스턴스를 담는 Static 변수
     이 게임 내에서 게임매니저 인스턴스는 이 instance에 담긴 것만 존재하게 할 것임.
    */
    public static GameManager instance;
    private void Awake(){
        // 이미 instance에 인스턴스가 존재한다면 자신을 삭제해준다.
        if(instance != null){ 
            Destroy(gameObject);
            return;
        }
        // 이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨져 있지 않다면 자기 자신을 넣어준다.
        instance = this;
    }
    #endregion
    
    public float mf_gameSpeed = 1;
    public bool mb_isPlay = false;
    public GameObject mg_playBtn;
    public GameObject mg_nextBtn;
    public GameObject mg_Mission;
    public GameObject mg_Counts;

    public delegate void OnPlay(bool b_isplay);                            // 게임 시작 버튼이 눌리면 RespawnManager의 Coroutine이 작동되게 해주기
    public OnPlay onPlay;                                                  // delegate 생성
    GameObject mg_SoundManager;

    void Start(){
        mg_SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결
    }
    // 게임 시작 버튼을 클릭하면 호출할 매소드
    public void PlayBtnClick(){ 
        mg_SoundManager.GetComponent<SoundManager>().playSound("Start");   // 시작 버튼 효과음 재생
        mg_playBtn.SetActive(false);   // 게임 시작 버튼 비활성화
        mg_Mission.SetActive(false);   // 미션 창 비활성화
        mg_Counts.SetActive(true);     // 총 횟수 창 활성화
        mb_isPlay = true;              // 게임 시작
        onPlay.Invoke(mb_isPlay);      // delegate 호출
    }

    // 게임 끝 버튼을 클릭하면 호출할 매소드
    public void GameOver(){
        mg_SoundManager.GetComponent<SoundManager>().playSound("End");     // 게임 끝 버튼 효과음 재생
        mg_nextBtn.SetActive(true);    // 게임 끝 버튼 활성화
        mg_Counts.SetActive(false);    // 총 횟수 창 비활성화
        mb_isPlay = false;             // 게임 끝
        onPlay.Invoke(mb_isPlay);      
    } 

    public void nextScene(){           // 다음씬으로
        SceneManager.LoadScene("1_06H&G");
    }
}
