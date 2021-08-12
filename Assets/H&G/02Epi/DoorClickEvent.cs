﻿/*
 * - Name : DoorClickEvent.cs
 * - Writer : 유희수
 * 
 * - Content : 문을 클릭하는 튜토리얼을 통한 스크립트 진행
 *  * 
 * - History
 * 2021-08-03 : 초기 개발
 * 2021-08-12 : 코드 획일화 및 주석 처리
 *  
 * - Variable 
 * mg_Hansel
 * mg_Gretel
 * mbtn_Door                                        문을 클릭하기 위한 버튼
 * mg_DoorClickBlink                                문 클릭을 지시하기 위한 애니메이션
 * mt_Text                                          자막을 출력하기 위한 텍스트
 * mvm_VoiceManager                                 나레이션을 위한 변수
 * mb_playOne                                       첫번째 나레이션의 실행 유무를 위한 flag
 * mb_playTwo                                       두번째 나레이션의 실행 유무를 위한 flag
 * 
 * - Function
 * v_GotoDoor()                                     문을 클릭해서 문에 헨젤과 그레텔이 다다를수있게 하는 함수
 * v_TutorialText()                                 문 클릭 이벤트 지시를 도와주기 위한 튜토리얼 텍스트와 애니메이션을 활성화해주는 함수
 * v_changeNextScene()                              다음 씬으로 넘어가기 위한 함수
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorClickEvent : MonoBehaviour{
    public GameObject mg_Hansel;                                                                                                    //연결을 위한 변수 -> 헨젤 연결
    public GameObject mg_Gretel;                                                                                                    //연결을 위한 변수 -> 그레텔 연결

    public Button mbtn_Door;                                                                                                        //문을 클릭하기 위한 버튼
    GameObject mg_DoorClickBlink;                                                                                                   //문 클릭을 지시하기 위한 애니메이션
    public Text mt_Text;                                                                                                            //자막을 출력하기 위한 텍스트

    public VoiceManager mvm_VoiceManager;                                                                                           //나레이션을 위한 변수
    private bool mb_playOne = false;                                                                                                //첫번째 나레이션의 실행 유무를 위한 flag
    private bool mb_playTwo = false;                                                                                                //두번째 나레이션의 실행 유무를 위한 flag

    public GameObject popup;

    void Start(){
        //오브젝트 연결
        mg_Hansel = GameObject.Find("Hansel");
        mg_Gretel = GameObject.Find("Gretel");
        
        mt_Text = GameObject.Find("Text").GetComponent<Text>();
        mvm_VoiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
        mg_DoorClickBlink = GameObject.Find("arrow");

        mbtn_Door = transform.GetComponent<Button>();                                                                               //문 클릭 버튼
        mbtn_Door.onClick.AddListener(v_GotoDoor);                                                                                  //버튼을 클릭하면 괄호안에 있는 함수를 불러옴

        mg_DoorClickBlink.SetActive(false);                                                                                         //처음에는 문 클릭 지시 애니메이션을 비활성화

        popup.SetActive(false);
    }
    void Update(){
        if (mvm_VoiceManager.mb_checkSceneReady && !mb_playOne){                                                                    //나레이션1 실행조건 검사
            mvm_VoiceManager.playVoice(0);                                                                                          //나레이션1과 playVoice(0) 연결됨
            mb_playOne = true;                                                                                                      //나레이션1 출력 완료 
        }
        if (mvm_VoiceManager.isPlaying() == false && mvm_VoiceManager.mb_checkSceneReady && mb_playTwo){                            //나레이션2까지 출력 끝나면 다음씬으로 이동
            v_changeNextScene();                                                                                                    //다음씬으로 이동하기 위한 함수
        }
    }

    //문을 클릭해서 문에 헨젤과 그레텔이 다다를수있게 하는 함수
    void v_GotoDoor(){
        if (mvm_VoiceManager.isPlaying() == false && mb_playOne){                                                                   //현재 음성출력이 끝났다면
            v_TutorialText();                                                                                                       //문을 클릭하게하기 위한 튜토리얼 지시
            if (mg_Gretel.transform.position.x < 9){                                                                                //현재 그레텔의 위치가 문보다 앞에 있다면
                mg_Gretel.transform.Translate(1, 0, 0);                                                                             //헨젤과 그레텔 모두 문쪽으로 이동
                mg_Hansel.transform.Translate(1, 0, 0);
                Debug.Log("buttonPress");
            }else{                                                                                                                  //문에 도착했다면
                mg_DoorClickBlink.SetActive(false);                                                                                 //문 클릭 지시 애니메이션을 비활성화
                mt_Text.text = "\n           가난을 못 버티고 부모님은 헨젤과 그레텔을 숲속에 버리려 계획했어요.        \n";        //문 클릭 이벤트 끝난 뒤 다음 자막 출력
                mvm_VoiceManager.playVoice(1);                                                                                      //자막과 함께 나레이션2 출력
                mb_playTwo = true;                                                                                                  //나레이션2 출력 완료
            }
        }
    }
    //문 클릭 이벤트 지시를 도와주기 위한 튜토리얼 텍스트와 애니메이션을 활성화해주는 함수
    void v_TutorialText(){
        mt_Text.text = "\n     문을 터치해주세요        \n";                                                                        //문을 클릭하게 하기 위한 텍스트 변경
        mg_DoorClickBlink.SetActive(true);                                                                                          //문 클릭 지시 애니메이션 활성화
        mg_DoorClickBlink.GetComponent<BlinkObject>().ChangBlinkFlagTrue();                                                         
    }

    //다음 씬으로 넘어가기 위한 함수
    public void v_changeNextScene(){
        SceneManager.LoadScene("1_03H&G");
    }
}

