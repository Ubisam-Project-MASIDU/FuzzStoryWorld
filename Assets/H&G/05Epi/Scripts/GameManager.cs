/*
 * - Name : GameManager.cs
 * - Writer : 이윤교
 * - Content : 게임 총괄
 * 
 * - HISTORY
 * 2021-08-13 : 초기 개발
 * 2021-08-18 : 코드 획일화 및 주석처리
 * 2021-08-19 : 효과음 재생 추가
 *
 * <Variable>
 * gameSpeed                ground와 조약돌의 속도 조절 변수
 * isPlay                   게임이 시작됬는지 구분하는 변수
 * playBtn                  게임 시작 버튼 연결
 * nextBtn                  게임 끝 버튼 연결
 * SoundManager             효과음 재생 연결 오브젝트
 *
 * <Function>
 * PlayBtnClick()           게임 시작 버튼을 클릭하면 호출할 매소드
 * GameOver()               게임 끝 버튼을 클릭하면 호출할 매소드
 * nextScene()              다음씬으로 넘어가기 위한 매소드
 *
 * delegate                 함수에 대한 참조, 하나의 delegate로 여러 함수들에 접근해 실행 가능, delegate를 이용해 함수를 파라미터로 전달할 수 있고, 여러 함수를 한꺼번에 실행하는 체인 기능과 
 *                          어떤 상황에 도달했을 때 이벤트를 발생시키는 delegate 이벤트도 제공됨.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
    
    public float gameSpeed = 1;
    public bool isPlay = false;
    public GameObject playBtn;
    public GameObject nextBtn;
    public GameObject Mission;

    public delegate void OnPlay(bool isplay); // 게임 시작 버튼이 눌리면 RespawnManager의 Coroutine이 작동되게 해주기
    public OnPlay onPlay; // delegate 생성

    GameObject SoundManager;

    void Start(){
        SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결
    }
    // 게임 시작 버튼을 클릭하면 호출할 매소드
    public void PlayBtnClick(){ 
        SoundManager.GetComponent<SoundManager>().playSound("Start");   // 시작 버튼 효과음 재생
        playBtn.SetActive(false);   // 게임 시작 버튼 비활성화
        Mission.SetActive(false);   // 미션 창 비활성화
        isPlay = true;              // 게임 시작
        onPlay.Invoke(isPlay);      // delegate 호출
    }

    // 게임 끝 버튼을 클릭하면 호출할 매소드
    public void GameOver(){
        SoundManager.GetComponent<SoundManager>().playSound("End");     // 게임 끝 버튼 효과음 재생
        nextBtn.SetActive(true);    // 게임 끝 버튼 활성화
        isPlay = false;             // 게임 끝
        onPlay.Invoke(isPlay);      
    } 

    public void nextScene(){        // 다음씬으로
        SceneManager.LoadScene("1_06H&G");
    }
}
