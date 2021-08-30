/*
 * - Name : CaptionControl.cs
 * - Writer : 유희수
 * 
 * - Content : 자막을 컨트롤해서, 음성에 맞게 자막을 출력하는 스크립트
 *
 * - History
 * 1) 2021-08-24 : 초기 개발
 * 2) 2021-08-26 : 코드 수정
 * 3) 2021-08-30 : 주석 달기 & 변수명 획일화
 * 
 * - Variable 
 * mn_LangIndex                                     현재 출력중인 음성의 언어 구별을 위한 인덱스  
 * mn_VoiceIndex                                    현재 출력중인 음성의 index를 알려줌
 * mg_CaptionPanel                                  자막이 출력되는 패널UI 연결
 * mt_CaptionText                                   언어에 따라 자막을 바꾸기 위한 텍스트 연결
 * mvm_VoiceManager                                 나레이션을 위한 변수
 * mb_playOne                                       첫번째 나레이션의 실행 유무를 위한 flag
 * mb_playTwo                                       두번째 나레이션의 실행 유무를 위한 flag
 * 
 * - Function
 * v_GotoDoor()                                     문을 클릭해서 문에 헨젤과 그레텔이 다다를수있게 하는 함수
 * v_TutorialText()                                 문 클릭 이벤트 지시를 도와주기 위한 튜토리얼 텍스트와 애니메이션을 활성화해주는 함수
 * v_ChangeNextScene()                              다음 씬으로 넘어가기 위한 함수
 * v_ChangeNextSceneWhenSkipGame()                  게임이 스킵되는경우 다음씬으로 넘어가기 위한 함수
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptionControl : MonoBehaviour
{
    private VoiceManager mvm_VoiceManager;
    public int mn_LangIndex = 9;
    private GameObject mg_CaptionPanel;
    public GameObject mt_CaptionText;
    public int mn_VoiceIndex = 99;
    private string ms_TextTemp;
    private GameObject OnButton;
    private GameObject OffButton;

    void Start(){
        OnButton = GameObject.Find("On");
        OffButton = GameObject.Find("Off");
        mt_CaptionText = GameObject.Find("Caption");
        mvm_VoiceManager = GameObject.FindObjectOfType<VoiceManager>();
        mg_CaptionPanel = GameObject.Find("CaptionPanel");
        mn_LangIndex = ((int)mvm_VoiceManager.country);
        ms_TextTemp = mvm_VoiceManager.mlva_LanguageVoices[mn_LangIndex].mvifl_setVoiceInfoList[mn_VoiceIndex].words;
        ShowCaption();
    }

    public void ShowCaption(){
        if (mn_LangIndex == 0){ //한국어 선택 -> 자막 없애기
            this.gameObject.SetActive(false);
            OnButton.SetActive(false);
            OffButton.SetActive(false);
        }
        else{
            mt_CaptionText.GetComponent<Text>().text = ms_TextTemp;
        }
    }
}
