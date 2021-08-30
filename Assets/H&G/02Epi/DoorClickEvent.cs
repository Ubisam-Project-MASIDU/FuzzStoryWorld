/*
 * - Name : DoorClickEvent.cs
 * - Writer : 유희수
 * - Sounds : 이병권

 * - Content : 문을 클릭하는 튜토리얼을 통한 스크립트 진행
 *             -1) 문을 클릭하면 케릭터가 걸어가는 소리가 난다.
 *             -2) 게임을 시작하는 버튼을 누르면 소리가 난다.
 *
 * - History
 * 1) 2021-08-03 : 초기 개발
 * 2) 2021-08-12 : 코드 획일화 및 주석 처리
 * 3) 2021-08-24 : 게임건너뛰기 기능 구현 (김명현)
 * 3) 2021-08-25 : 게임 소리 나기 작업 (이병권)
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
 * v_ChangeNextScene()                              다음 씬으로 넘어가기 위한 함수
 * v_ChangeNextSceneWhenSkipGame()                  게임이 스킵되는경우 다음씬으로 넘어가기 위한 함수
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorClickEvent : MonoBehaviour{
    private ChangeCountry mn_PlayVoiceIndex;
    public GameObject mg_Hansel;                                                                                                    // 연결을 위한 변수 -> 헨젤 연결
    public GameObject mg_Gretel;                                                                                                    // 연결을 위한 변수 -> 그레텔 연결
    string temp;
    public Button mbtn_Door;                                                                                                        // 문을 클릭하기 위한 버튼
    public GameObject mg_DoorClickBlink;                                                                                                   // 문 클릭을 지시하기 위한 애니메이션
    public Text mt_Text;                                                                                                            // 자막을 출력하기 위한 텍스트
    public VoiceManager mvm_VoiceManager;                                                                                           // 나레이션을 위한 변수
    public CaptionControl cc;
    private bool mb_PlayFirstVoice = false;                                                                                         // 첫번째 나레이션의 실행 유무를 위한 flag
    private bool mb_PlaySecondVoice = false;                                                                                        // 두번째 나레이션의 실행 유무를 위한 flag
    private bool mb_doorclicksound = false;
    public GameObject mg_Popup;
    GameObject mg_SoundManager;                                                                                                     // 팝업창 오브젝트 연결을 위한 변수
    
    void Start(){        
        //오브젝트 연결
        mg_Hansel = GameObject.Find("Hansel");                                                                               
        mg_Gretel = GameObject.Find("Gretel");                                                                                  
        mt_Text = GameObject.Find("Text").GetComponent<Text>();     
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        cc = GameObject.Find("CaptionPanel").GetComponent<CaptionControl>();
        mbtn_Door = transform.GetComponent<Button>();                                                                               // 문 클릭 버튼
                                                                                  // 버튼을 클릭하면 괄호안에 있는 함수를 불러옴
        mg_DoorClickBlink.SetActive(false);                                                                                         // 처음에는 문 클릭 지시 애니메이션을 비활성화
        mg_Popup.SetActive(false);
        mg_SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결

        if (PlayerPrefs.GetInt("SkipGame") == 1)
        {
            mg_Gretel.transform.position = new Vector3(9.28f, mg_Gretel.transform.position.y, mg_Gretel.transform.position.z);
            mg_Hansel.transform.position = new Vector3(7.48f, mg_Hansel.transform.position.y, mg_Hansel.transform.position.z);
        }
    }
    
    void Update(){
        
        if (!mb_PlayFirstVoice){                                                             // 나레이션1 실행조건 검사
            mvm_VoiceManager.playVoice(1);                                                                                          // 나레이션1과 playVoice(1) 연결됨
            mb_PlayFirstVoice = true;                                                                                               // 나레이션1 출력 완료 
        }
        /*
        if (mvm_VoiceManager.isPlaying() == false && mb_PlayFirstVoice)
        {
            v_TutorialText();
        }
        */
        if (mvm_VoiceManager.isPlaying() == false && mb_PlaySecondVoice){                    // 나레이션2까지 출력 끝나면 다음씬으로 이동
            Debug.Log("11111111111111111111111");
            if (PlayerPrefs.GetInt("SkipGame") == 1)
            {
                Debug.Log("dssds");
                Invoke("v_ChangeNextSceneWhenSkipGame", 1f);
            }
            else
            {
                mg_Popup.SetActive(true);                                                                                               // 다음씬으로 이동하기 위한 함수
            }
        }
        else if (mvm_VoiceManager.isPlaying() == false && mb_PlayFirstVoice)
        {
            v_TutorialText();
        }
    }

    // 문을 클릭해서 문에 헨젤과 그레텔이 다다를수있게 하는 함수
    public void v_GotoDoor(){
        if (mvm_VoiceManager.isPlaying() == false && mb_doorclicksound){                                                            // 현재 음성출력이 끝났다면
                                                                                                      // 문을 클릭하게하기 위한 튜토리얼 지시
            if (mg_Gretel.transform.position.x < 9){                                                                                // 현재 그레텔의 위치가 문보다 앞에 있다면
                mg_Gretel.transform.Translate(1, 0, 0);                                                                             // 헨젤과 그레텔 모두 문쪽으로 이동
                mg_Hansel.transform.Translate(1, 0, 0);
                GetComponent<SoundofS2>().PlaySound("Walk");
            }else{                                                                                                                  // 문에 도착했다면
                mg_DoorClickBlink.SetActive(false);                                                                                 // 문 클릭 지시 애니메이션을 비활성화
                mt_Text.text = "\n           가난을 못 버티고 부모님은 헨젤과 그레텔을 숲속에 버리려 계획했어요.        \n";        // 문 클릭 이벤트 끝난 뒤 다음 자막 출력
                cc.mn_VoiceIndex = 3;
                mvm_VoiceManager.playVoice(3);
                temp = mvm_VoiceManager.mlva_LanguageVoices[cc.mn_LangIndex].mvifl_setVoiceInfoList[3].words;
                cc.mt_CaptionText.GetComponent<Text>().text = temp;// 자막과 함께 나레이션2 출력
                mb_PlaySecondVoice = true;                                                                                          // 나레이션2 출력 완료
            }
        }
    }
    
    // 문 클릭 이벤트 지시를 도와주기 위한 튜토리얼 텍스트와 애니메이션을 활성화해주는 함수
    void v_TutorialText(){
        if(PlayerPrefs.GetInt("SkipGame") == 1)
        {
            mt_Text.text = "\n           가난을 못 버티고 부모님은 헨젤과 그레텔을 숲속에 버리려 계획했어요.        \n";        // 문 클릭 이벤트 끝난 뒤 다음 자막 출력
            cc.mn_VoiceIndex = 3;
            temp = mvm_VoiceManager.mlva_LanguageVoices[cc.mn_LangIndex].mvifl_setVoiceInfoList[3].words;
            cc.mt_CaptionText.GetComponent<Text>().text = temp;
            mvm_VoiceManager.playVoice(3);                                                                                      // 자막과 함께 나레이션2 출력
            mb_PlaySecondVoice = true;                                                                                          // 나레이션2 출력 완료
        }
        else
        {
            if (!mb_doorclicksound)
            {
                mvm_VoiceManager.playVoice(2);
                cc.mn_VoiceIndex = 2;
                mt_Text.text = "\n     문을 클릭해주세요        \n";                                                                        // 문을 클릭하게 하기 위한 텍스트 변경
                temp = mvm_VoiceManager.mlva_LanguageVoices[cc.mn_LangIndex].mvifl_setVoiceInfoList[2].words;
                cc.mt_CaptionText.GetComponent<Text>().text = temp;
                mg_DoorClickBlink.SetActive(true);                                                                                          // 문 클릭 지시 애니메이션 활성화
                mg_DoorClickBlink.GetComponent<BlinkObject>().ChangBlinkFlagTrue();
                mb_doorclicksound = true;
            }
        }                                                       
    }

    // 다음 씬으로 넘어가기 위한 함수
    public void v_ChangeNextScene(){
        //mg_SoundManager.GetComponent<SoundManager>().playSound("PlayMiniGame1");   // 시작 버튼을 눌렀을 때 나오는 효과음 재생
        Invoke("LoadScene", 1f);
        SceneManager.LoadScene("1_02H&G_Game");
    }

    public void v_ChangeNextSceneWhenSkipGame()
    {
        SceneManager.LoadScene("1_03H&G");
    }

}

