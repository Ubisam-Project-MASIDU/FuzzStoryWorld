/*
 * - Name : CheckAnswerEpi3.class
 * - Writer : 유희수
 * - Content : 헨젤과그레텔 Epi3 미니게임 - 오브젝트 3개가 모두 맞는 위치에 들어갔는지 확인하고, 다음씬으로 넘겨주는 스크립트
 *  
 * - HISTORY
 * 2021-08-10 : 초기 개발
 * 2021-08-12 : 코드 획일화 및 주석처리
 *
 * <Variable>
 * mn_count                     퍼즐이 몇개 맞춰졌는지 확인을 위한 변수
 * v_YouWinText;                게임이 끝났음을 표시해주는 텍스트
 * 
 * <Function>
 * v_CountAnswer()              퍼즐을 맞출때마다 개수 변수를 더해주는 함수
 * v_ChangeNextScene()          다음씬으로 넘어가는 함수
 * v_WinText()                  텍스트를 활성화해주는 함수
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckAnswerEpi3 : MonoBehaviour{
    public VoiceManager mvm_VoiceManager;
    public int mn_count;
    public GameObject v_YouWinText;
    GameObject mg_SoundManager;

    void Start(){
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        mn_count = 0;                                                           //퍼즐 개수 변수 0으로 초기화
        v_YouWinText.SetActive(false);                                          //텍스트 비활성화
        mvm_VoiceManager.playVoice(6);
        mg_SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결
    }

    //모양을 맞출때마다 개수 변수를 더해주는 함수
    //모양이 모두 맞춰지는지 개수로 확인하고, 다 맞춰지면 다음 씬으로 이동
    public void v_CountAnswer(){
        mn_count++;                                                             //개수 하나씩 더해준다
        Debug.Log("1");
        if (mn_count == 3){                                                     //맞춰진 퍼즐개수가 9개라면
            Invoke("v_WinText", 1f);                                            //텍스트 활성화
            Invoke("v_ChangeNextScene", 3f);                                    //다음씬 불러오기
        }
    }

    //다음 씬으로 이동하는 함수
    public void v_ChangeNextScene(){
        SceneManager.LoadScene("1_04H&G");
    }

    //텍스트를 활성화해주는 함수
    public void v_WinText(){
        v_YouWinText.SetActive(true);
        mg_SoundManager.GetComponent<SoundManager>().playSound("Win2");     // 게임 끝 버튼 효과음 재생       
    }
}