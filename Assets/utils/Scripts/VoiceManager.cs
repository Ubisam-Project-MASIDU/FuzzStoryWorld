/*
 * - Name : VoiceManager.cs
 * - Writer : 최대준
 * - Content : Text to Speech Class를 통해 최종적으로 AudioClip을 통해 음성을 출력하는 클래스이다. 여기서는 협업을 통해 작업하기 쉽도록 음성 세팅을 인스펙터에서 할 수 있도록 설정하게 되었다. 덕분에 VoiceManager 라는 프리팹 하나만 각각 씬으로 가져가 음성 세팅하고, 씬에 있는 스크립트 코드에 따라 VoiceManager 클래스의 playVoice함수만 호출해 주면 음성이 출력된다.
 * - Where the code is applied : for any scenes to need making a voice sounds...
 *
 * - How to Use -
 *
 * 1. VoiceManager라는 오브젝트를 프리팹으로 만들어두었다. 그것을 이용해서 쓰기만 하면 된다.
 * 2. VoiceManager 클래스의 안을 보자면, TTS 클래스를 선언한다. ex) TTS mtts_testTTS;
 * 3. TTS 클래스는 싱글톤 패턴이기 때문에 이미 사용중인 인스턴스가 있는지 확인하고 없으면 초기화한 인스턴스를 반환하는 함수를 호출한다. ex) mtts_textTTS = TTS.getInstance();
 * 4. VoiceManager는 인스펙터로 만들 보이스를 받아들이고 보이스를 TTS 클래스에서 구글 api를 통해서 audioclip으로 반환받게 된다.
 * 5. VoiceManager클래스는 AudioClip형태로 오디오를 가지고 있고, 클래스 안의 함수인 playVoice(id or name) 함수를 통해서 음성을 씬에 출력하게 된다.
 *
 * - History -
 * 1. 2021-07-19 : 구현
 * 2. 2021-07-20 : 주석 처리
 * 3. 2021-07-22 : thread에게 TTS 통신 처리 위임, TTS 통신 처리 중에 로드 화면 추가.
 * 4. 2021-07-23 : isPlaying() 함수 추가.
 * 5. 2021-07-27 : 피드백에 의한 주석 변경.
 * 6. 2021-08-10 : 피드백 요구사항 변경으로 인한 추가적인 기능 구현 시작.
 * 7. 2021-08-24 : 피드백 요구사항 변경으로 인한 실시간 로딩 방식으로 수정. 로딩 방식으로는 첫번째 씬부터, 한국어 영어 일본어 중국어 순으로 로딩 후 두번째 씬 언어 로딩 ... 이렇게 진행된다.

 *
 * - Variable 
 * public enum Country {
     KR,
     EN,
     JP,
     CN
 } 현재 선택된 언어를 표현하기 위한 enum 변수이다.
 * mlva_LanguageVoices      현재 지원되는 언어의 스크립트 클래스이다.
 * mn_LanguageLength        현재 지원되는 언어의 숫자이다.
 * mct_CheckCountry         현재 선택된 언어를 뜻한다. 이 언어를 바꾸면, 자연스럽게 음성이 국가에 따라 나오게 된다.
 * mas_playVoice            음성을 출력하기 위한 컴포넌트.
 *
 * - Function
 * Awake()                  생성된 VMController 오브젝트를 씬 전환시 파괴되지 않도록 DonDestroyOnLoad에 저장하고, 로딩화면을 화면에 띄운다.
 * stopVoice()              현재 출력중인 음성의 출력을 멈춘다.
 * LoadLanguageByOrder()    정의한 순서대로 로딩을 시작한다.
 * TakeVoice()              이제 VoiceManager에는 AudioClip이 있기 않고, LoadVoice 스크립트에 존재하기 때문에 그것을 가져와 playVoice로 출력시킨다.
 */

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;



// 씬에서 음성을 출력하는 게임오브젝트에 적용되는 VoiceManager 클래스이다.
/// <summary>
/// 씬에 VoiceManager의 인스펙터 창에서 설정한 음성 세팅값을 playVoice 함수를 통해 씬에 출력해주도록 도와주는 클래스.
/// </summary>
public class VoiceManager : MonoBehaviour {
    public enum Country {
        KR,
        EN,
        JP,
        CN
    }

    public int mn_LanguageLength = 4;
    public LoadVoice[] mlva_LanguageVoices;
    private AudioSource mas_playVoice;
    private Country mct_CheckCountry = Country.KR;
    public Country country {
        set {
            mct_CheckCountry = value;
        }
        get {
            return mct_CheckCountry;
        }
    }


    // VMController와 KRVoiceManager, ENVoiceManager, JPVoiceManager, CNVoiceManager는 씬이 전환되어도 유지되어야 하므로, DonDestroyOnLoad 함수로 Destroy 되지 않도록 한다. 또한 오브젝트가 만들어지자마자 코루틴을 통해 로딩 순서를 정의하여 로딩을 시작한다.
    void Awake() {
        mn_LanguageLength = transform.childCount;
        mas_playVoice = gameObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        mlva_LanguageVoices = new LoadVoice[mn_LanguageLength];
        for (int i = 0; i < mn_LanguageLength; i++) {
            mlva_LanguageVoices[i] = transform.GetChild(i).GetComponent<LoadVoice>();
        }
        StartCoroutine(LoadLanguageByOrder());
        // mgo_loadingScene = Instantiate(mc_loadingScene);
        // mgo_loadingScene.SetActive(true);
    }
    
    IEnumerator LoadLanguageByOrder() {
        int n_CurrentLoadIndex = 0;
        while (n_CurrentLoadIndex < mlva_LanguageVoices[0].mvifl_setVoiceInfoList.Length) {
            for (int i = 0; i < mn_LanguageLength; i++) {
                mlva_LanguageVoices[i].CurrentIndex = n_CurrentLoadIndex;
                Debug.Log(n_CurrentLoadIndex.ToString() + ":" + (i).ToString() + "Start.");
                yield return new WaitUntil(() => mlva_LanguageVoices[i].CheckLoadComplete);
                mlva_LanguageVoices[i].CheckLoadComplete = false;
                Debug.Log(n_CurrentLoadIndex.ToString() + ":" + (i).ToString() + "End.");
            }
            n_CurrentLoadIndex++;
        }
        yield break;

    }
    // 인스펙터창에 입력되는 음성 세팅 값을 저장하는 struct이다.
    // 해당 스크립트가 들어간 게임 오브젝트가 생성될 때, 인스펙터창에 저장된 음성 세팅 값들을 통해서 스레드를 하나 생성하여 TTS 통신 작업을 위임시킨다.
   

    // 이 함수를 통해 저장했고 해당되는 AudioClip을 씬에 출력하게 된다. 
    /// <summary>
    /// 설정한 음성을 씬에 출력하는 함수.
    /// </summary>
    /// <param name="nPlayVoiceClipId">인스펙터 창에서 설정한 음성의 인덱스 값.</param>
    public void playVoice(int nPlayVoiceClipId) {
        if (!mas_playVoice.isPlaying) {
            mas_playVoice.PlayOneShot(TakeVoice(nPlayVoiceClipId));
        }
    }

    // 음성이 출력되는지 확인, 출력되고 있다면 true, 출력되지 않고 있다면 false.
    /// <summary>
    /// 해당 씬의 VoiceManager 오브젝트의 컴포넌트 AudioSource에 음성이 출력되고 있는지 확인해주는 함수.
    /// </summary>
    /// <returns> 출력중이면 true, 아니라면 false 값 반환. </returns>
    public bool isPlaying() {
        return mas_playVoice.isPlaying;
    }

    public void stopVoice() {
        mas_playVoice.Stop();
    }

    private AudioClip TakeVoice(int nPlayVoiceClipId) {
        return mlva_LanguageVoices[(int)country].mvifl_setVoiceInfoList[nPlayVoiceClipId].audioClip;
    }
}
