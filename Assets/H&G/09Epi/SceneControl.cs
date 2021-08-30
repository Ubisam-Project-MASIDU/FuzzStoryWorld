/*
 * - Name : SceneControl.cs
 * - Writer : 유희수

 * - Content : Scene9를 전체적으로 컨트롤해서 스토리 진행하는 스크립트
 *
 * - History
 * 1) 2021-08-13 : 초기 개발
 * 2) 2021-08-17 : 코드 획일화 및 주석 처리
 * 3) 2021-08-24 : 게임건너뛰기 기능 구현 (김명현)
 * 3) 2021-08-25 : 게임 소리 나기 작업 (이병권)
 * 
 * - Variable 
 * mvm_VoiceManager                                       나레이션을 위한 변수
 * mcc_CaptionControl                                     CaptionControl 클래스에서 자막 인덱스를 가져오기 위한 객체
 * mb_PlayFirstVoice                                      첫번째 나레이션의 실행 유무를 위한 flag
 * mb_PlaySecondVoice                                     두번째 나레이션의 실행 유무를 위한 flag
 * mb_PlayThirdVoice                                      세번째 나레이션의 실행 유무를 위한 flag
 * ms_CaptionTemp                                         자막을 일시적으로 저장하는 변수
 * mg_WitchText                                           마녀의 말풍선 오브젝트
 * mg_VibrateAni                                          헨젤과 그레텔에게 붙여줄 떨리는 애니메이션
 * mt_Text                                                가장 위에 나오는 스토리 진행 텍스트
 * mb_ObjClickStart                                       SceneControl 스크립트가 끝나고 ObjectClick 스크립트를 시작해도 됨을 알려주는 flag
 * mb_ChangeColorOnce                                 
 * mspr_BackGrouond                                       배경 스프라이트 연결을 위한 변수
 * mspr_Witch                                             마녀 스프라이트 연결을 위한 변수
 * 
 * - Function
 * v_ColorChange                                          클릭 오브젝트들을 제외하고 배경을 어둡게 해주는 함수
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour{
    public VoiceManager mvm_VoiceManager;
    public CaptionControl mcc_CaptionControl;
    private bool mb_PlayFirstVoice = false;
    private bool mb_PlaySecondVoice = false;
    private bool mb_PlayThirdVoice = false;
    string ms_CaptionTemp;
    public GameObject mg_WitchText;
    public GameObject mg_VibrateAni;
    public Text mt_Text;
    private string ms_Temp2;
    public bool mb_ObjClickStart = false;
    bool mb_ChangeColorOnce = false;
    private SpriteRenderer mspr_BackGrouond;
    private SpriteRenderer mspr_Witch;

    void Start(){
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        mcc_CaptionControl = GameObject.Find("CaptionPanel").GetComponent<CaptionControl>();
        mspr_BackGrouond = GameObject.Find("Background").GetComponent<SpriteRenderer>();
        mspr_Witch = GameObject.Find("witch").GetComponent<SpriteRenderer>();
        mg_WitchText.SetActive(false);
    }

    void Update(){
        // 첫번째 나레이션 시작 전이라면
        if (!mb_PlayFirstVoice){
            // 첫번째 나레이션 음성을 출력해주고,
            mvm_VoiceManager.playVoice(13);
            // 언어 자막에 선택한 나라에 맞는 언어로 자막을 출력해준다
            ms_CaptionTemp = mvm_VoiceManager.mlva_LanguageVoices[mcc_CaptionControl.mn_LangIndex].mvifl_setVoiceInfoList[13].words;
            mcc_CaptionControl.mt_CaptionText.GetComponent<Text>().text = ms_CaptionTemp;
            mb_PlayFirstVoice = true;
            // 스토리 진행상 마녀의 말풍선이 나오는 함수 진행
            Invoke("v_WitchText", 2.5f);
        }
        // 두번째 나레이션의 실행 조건 검사
        if (mvm_VoiceManager.isPlaying() == false && mb_PlayFirstVoice && !mb_PlaySecondVoice){
            // 두번째 나레이션 음성을 출력해주고,
            mvm_VoiceManager.playVoice(14); 
            // 언어 자막에 선택한 나라에 맞는 언어로 자막을 출력해준다
            mcc_CaptionControl.mn_VoiceIndex = 14;
            ms_CaptionTemp = mvm_VoiceManager.mlva_LanguageVoices[mcc_CaptionControl.mn_LangIndex].mvifl_setVoiceInfoList[14].words;
            mcc_CaptionControl.mt_CaptionText.GetComponent<Text>().text = ms_CaptionTemp;
            mb_PlaySecondVoice = true;
            // 스토리 진행상 마녀의 말풍선 오브젝트 없애기
            mg_WitchText.SetActive(false);
            // 스토리 진행하는 한국어 자막 변경
            ms_Temp2 = mvm_VoiceManager.mlva_LanguageVoices[0].mvifl_setVoiceInfoList[14].words;
            mt_Text.text = "\n        " + ms_Temp2 + "         \n";
        }
        // 세번째 나레이션의 실행 조건 검사
        if (mvm_VoiceManager.isPlaying() == false && mb_PlaySecondVoice && !mb_PlayThirdVoice){
            // 스킵게임이 아닐때만 음성 및 자막 출력
            if (PlayerPrefs.GetInt("SkipGame") == 0){
                mvm_VoiceManager.playVoice(15);
                mcc_CaptionControl.mn_VoiceIndex = 15;
                ms_CaptionTemp = mvm_VoiceManager.mlva_LanguageVoices[mcc_CaptionControl.mn_LangIndex].mvifl_setVoiceInfoList[15].words;
                mcc_CaptionControl.mt_CaptionText.GetComponent<Text>().text = ms_CaptionTemp;
                ms_Temp2 = mvm_VoiceManager.mlva_LanguageVoices[0].mvifl_setVoiceInfoList[15].words;
                mt_Text.text = "\n        " + ms_Temp2 + "         \n";
                mb_PlayThirdVoice = true;
            }
            if(mb_ChangeColorOnce == false){
                mb_ChangeColorOnce = true;
                Invoke("v_ColorChange", 2f);
            }
        }
    }
    //클릭 오브젝트들을 제외하고 배경을 어둡게 해주는 함수
    void v_ColorChange(){
        mspr_BackGrouond.color = new Color(75 / 255f, 75 / 255f, 75 / 255f, 255 / 255f);
        mspr_Witch.color = new Color(85 / 255f, 85 / 255f, 85 / 255f, 255 / 255f);
        mb_ObjClickStart = true;
    }
}