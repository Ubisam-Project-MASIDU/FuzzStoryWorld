/*
 * - Name : VMController.cs
 * - Writer : 최대준
 * 
 * - Content :
 * 다양한 언어를 로드하고, 언어에 따라서 다른 음성을 출력하도록 구현된 스크립트 코드이다.
 * 
 * - History
 * 1) 2021-08-05 : 코드 구현. 
 * 2) 2021-08-09 : 주석 작성.
 *  
 * - Variable 
 * public enum Country {
     KR,
     EN,
     JP,
     CN
 } 현재 선택된 언어를 표현하기 위한 enum 변수이다.
 * mn_LanguageLength        현재 지원되는 언어의 숫자이다.
 * mn_CurrentVMIdx          현재 로딩중인 언어의 인덱스 숫자를 표현한다.
 * mb_CheckSceneReady       현재 언어들의 로딩이 다 끝났는지를 표현해주는 변수이다.
 * mb_CheckLanguageReady    현재 언어들의 로딩이 다 끝났는지를 표현해주는 변수이다.
 * mgo_loadingScene         원래는 VoiceManager 클래스에 있던 로딩 화면 오브젝트인데, 다양한 언어를 지원하기 위해 VMController 클래스에서 담당하도록 하였다.
 * mc_loadingScene          원래는 VoiceManager 클래스에 있던 로딩 화면 프리팹인데, 다양한 언어를 지원하기 위해 VMController 클래스에서 담당하도록 하였다.
 * mct_CheckCountry         현재 선택된 언어를 뜻한다.
 *
 * - Function
 * Awake()                  생성된 VMController 오브젝트를 씬 전환시 파괴되지 않도록 DonDestroyOnLoad에 저장하고, 로딩화면을 화면에 띄운다.
 * Update()                 각각 맡은 언어의 VoiceManager 오브젝트의 로드를 구현하고, 언어 설정을 담당하는 함수이다.
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지원하는 언어의 VoiceManager를 관리하기 위한 스크립트 클래스이다.
public class VMController : MonoBehaviour {

    public enum Country {
        KR,
        EN,
        JP,
        CN
    }
    public int countryindex = 9;
    public int mn_LanguageLength = 4;
    private int mn_CurrentVMIdx = 0;
    public bool mb_CheckSceneReady = false;
    public bool mb_CheckLanguageReady = false;
    private GameObject mgo_loadingScene;
    public GameObject mc_loadingScene;
    private Country mct_CheckCountry = Country.KR;


    // VMController와 KRVoiceManager, ENVoiceManager, JPVoiceManager, CNVoiceManager는 씬이 전환되어도 유지되어야 하므로, DonDestroyOnLoad 함수로 Destroy 되지 않도록 한다.
    void Awake() {
        DontDestroyOnLoad(gameObject);
        mgo_loadingScene = Instantiate(mc_loadingScene);
        mgo_loadingScene.SetActive(true);
    }
    
    // VoiceManager들을 로딩하고, 언어를 선택하면 언어와 동일한 VoiceManager를 선택하도록 한다.
    void Update() {
        if (mn_CurrentVMIdx >= mn_LanguageLength && !mb_CheckSceneReady) {
            mb_CheckSceneReady = true;
            mgo_loadingScene.SetActive(false);
            return;
        }
        if (mn_CurrentVMIdx >= mn_LanguageLength && !mb_CheckLanguageReady) {
            for (int i = 0; i < mn_LanguageLength; i++) {
                if (i != (int)mct_CheckCountry) {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            mb_CheckLanguageReady = true;
        }        
        if (mn_CurrentVMIdx < mn_LanguageLength) {
            GameObject go_GetChild = transform.GetChild(mn_CurrentVMIdx).gameObject;

            if (!go_GetChild.activeSelf) {
                go_GetChild.SetActive(true);
            } else if (go_GetChild.GetComponent<VoiceManager>().mb_checkSceneReady) {
                mn_CurrentVMIdx++;
            }
        }
    }


    // 음성 출력의 언어를 세팅하는 함수.
    /// <summary>
    /// 음성 출력의 언어를 세팅하는 함수. 매개변수는 enum Country로 언어를 선택할 수 있다.
    /// </summary>
    public void SetCountry(Country ctStrCountry) {
        mct_CheckCountry = ctStrCountry;
        mb_CheckLanguageReady = false;
        countryindex = ((int)mct_CheckCountry);
    }
}
