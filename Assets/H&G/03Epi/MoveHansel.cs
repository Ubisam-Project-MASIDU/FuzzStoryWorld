/*
 * - Name : MoveHansel.class
 * - Writer : 유희수, 이병권
 * - Content : 헨젤과그레텔 Epi3 - 스토리 진행 후, 미니게임 시작해주는 스크립트
 *                                 1) 걸어갈 때 소리가 나게 하기
 * - HISTORY
 * 1) 2021-08-10 : 초기 개발
 * 2) 2021-08-17 : 코드 획일화 및 주석처리
 * 3) 2021-08-24 : 게임 건너뛰기 추가 (김명현)
 * 4) 2021-08-26 : 게임 걸어갈 때 소리가 나게 하기(이병권)
 *
 * <Variable>
 * mg_Hansel                    헨젤 오브젝트 연결을 위한 변수
 * mv3_TargetPoint              헨젤을 이동시킬 목표 지점
 * mg_PopUp                     미니게임 시작을 위한 팝업창
 *  
 * <Function>
 * v_NextScene                  다음 씬으로 넘겨주는 함수
 * v_NextSceneWhenSkipGame      게임 스킵시 넘어갈 씬
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveHansel : MonoBehaviour{
    private GameObject mg_Hansel;
    public Vector3 mv3_TargetPoint;
    public GameObject mg_PopUp;
    public VoiceManager mvm_VoiceManager;

    GameObject mg_SoundManager;
    private bool mb_PlayFirstVoice = false;

    void Start(){
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();

        mg_SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결

        mv3_TargetPoint = new Vector3(-2.7f, -0.8f, -2.5f);                                                       //헨젤을 이동시킬 목표지점 설정
        mg_Hansel = GameObject.Find("Hansel");                                                                    //변수에 오브젝트 연결
        mg_PopUp.SetActive(false);                                                                                //팝업창 비활성화
    }
    
    void Update(){
        mg_Hansel.transform.position = Vector3.MoveTowards(mg_Hansel.transform.position, mv3_TargetPoint, 0.07f); //현재 오브젝트가 mv3_TargetPoint위치로 0.07f의 속력으로 가는 함수
        if (!mb_PlayFirstVoice)
        {
            mg_SoundManager.GetComponent<SoundManager>().playSound("Walk2");     // 핸젤이 걸어 갈때 효과음 재생
            mvm_VoiceManager.playVoice(5);
            mb_PlayFirstVoice = true;
        }
        
        if (mb_PlayFirstVoice && mvm_VoiceManager.isPlaying() == false)
        {
            // 게임건너뛰기가 켜져있는지 확인
            if(PlayerPrefs.GetInt("SkipGame") == 1)
            {
                Invoke("v_NextSceneWhenSkipGame", 1f);
            }
            else
            {
                popup();
            }
        }
    }

    void popup()
    {
        mg_PopUp.SetActive(true);
    }
    public void v_NextScene(){
        mg_SoundManager.GetComponent<SoundManager>().playSound("PlayMinGame2");     // 게임 시작 버튼 효과음 재생
        SceneManager.LoadScene("1_03H&G_Game");
    }

    public void v_NextSceneWhenSkipGame()
    {
        SceneManager.LoadScene("1_04H&G");
    }
}
