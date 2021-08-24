/*
 * - Name : PlayVoice.cs
 * - Writer : 최대준
 * 
 * - Content :
 * 간단하게 음성 출력을 도와주는 클래스이다. 0_01LanguageSelect 씬의 VMLoader - VMController - KR or EN or JP or CNVoiceManager 안의 인스펙터 창에 적힌 대사 인덱스를 현재 스크립트의 인스펙터 설정창에 적어주고 실행하면 된다.
 * 
 * - History
 * 1) 2021-08-05 : 코드 구현. 
 * 2) 2021-08-09 : 주석 작성.
 * 3) 2021-08-24 : 게임 건너뛰기시 설정 (김명현)
 *  
 * - Variable 
 * mn_PlayVoiceIndex    public으로 선언되어 인스펙터 창에서 설정할 수 있고, 음성을 출력할 대사의 인덱스를 나타낸다.
 * mvm_VoiceManager     음성을 출력할 AudioSource 컴포넌트를 가지고 있다.                                             
 * mb_PlayOnce          음성을 Update 함수를 통해 실행할 것 이므로 그냥 두면 계속 매프레임마다 실행되어 flag를 두어야 한다. 이게 그 flag이다.
 *
 * - Function
 * Start()              씬에서 VoiceManager 컴포넌트를 찾아 초기화한다.
 * Update()             씬에서 해당 컴포넌트를 가진 오브젝트가 생성되면, 바로 인덱스의 음성이 출력된다.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 음성 출력하는 것을 도와주는 간단한 스크립트 클래스이다.
public class PlayVoice : MonoBehaviour {

    public int mn_PlayVoiceIndex = 0;
    public string ms_ChangeNextSceneName;
    public string ms_ChangeNextSceneName_NoGame;
    private VoiceManager mvm_VoiceManager;
    
    // 씬에서 VoiceManager 컴포넌트를 찾아 초기화시킨다.
    void Start() {
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);

    }

    // 이 해당 컴포넌트가 들어있는 오브젝트가 생성되면 바로 음성을 출력하게 되어 있다. 이때 출력은 한번만 되도록 한다.
    void Update() {
        // 게임 건너뛰기시 분기점
        if (!mvm_VoiceManager.isPlaying()) {
            if (PlayerPrefs.GetInt("SkipGame") == 1)
            {
                SceneManager.LoadScene(ms_ChangeNextSceneName_NoGame);
            }
            else
            {
                SceneManager.LoadScene(ms_ChangeNextSceneName);
            }
        }
    }
}
