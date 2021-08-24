/*
 * - Name : LoadVoice.cs
 * - Writer : 최대준
 * 
 * - Content :
 * 기존 씬에 적용되었던 코드를 재사용하기 위해서 VoiceManager를 수정하는 과정에서 추가 생성된 스크립트. VoiceManager의 기존 역할을 담당해준다.
 * 
 * - History
 * 1) 2021-08-24 : 코드 구현. 
 * 2) 2021-08-24 : 주석 작성.
 *  
 *
 * - LoadVoice Member Variable 
 * 
 * VoiceInfo[] mvifl_setVoiceInfoList           인스펙터창에서 음성 커스터마이징 할 수 있는 정보를 가진 struct 데이터이다. 구조체 안을 보면, {
    public Voice svt_voiceType                  원하는 구글 TTS API의 기본 보이스를 설정하는 enum 데이터이다. 필요한 데이터만 정리를 하여 쓸것만 enum형식으로 재구성 하였다. enum 종류로는, KR_FEMALE_A, KR_FEMALE_B, KR_MALE_A, KR_MALE_B, EN_FEMALE_A, EN_FEMALE_B, EN_MALE_A, EN_MALE_B, JP_FEMALE_A, JP_FEMALE_B, JP_MALE_A, JP_MALE_B, CN_FEMALE_A, CN_FEMALE_B 로 구성되어 있다.
    public string sstr_words                    음성이 무슨 말을 출력할지를 string 형식으로 저장하는 변수이다.
    public float sf_pitch                       음성의 음조(높낮이)를 조절하는 변수이다.
    public string sf_speakingRate               음성의 말 빠르기를 조절하는 변수이다.
    public audioClip sac_voiceAudioClip         최종적으로 TTS 와의 통신으로 받아낸 음성 데이터를 저장하는 변수이다.
 }
 * mtts_getVoice                                TTS 통신을 정의한 클래스이다.
 * mb_CheckLoadComplete                         API 통신이 끝났다는 것을 알려주는 변수이다.
 * mn_checkCurInx                               스레드의 작업물의 결과로 인덱싱하기 위해서 필요한 변수이다. 현재 진행되는 씬의 index를 뜻하게 되며, 이 인덱스가 변경될 때마다 setter 에서는 코루틴과 쓰레드를 이용해 통신을 진행하게 된다.
 *  mquefa_queue                                메인 스레드와 생성된 스레드의 데이터 통신을 위한 큐로, 생성된 스레드는 이 큐에 작업물을 저장하게 되며, 그때 메인 스레드에서는 이 작업물을 통해 음성을 만들게 된다.
 * mth_workThread                               위에서 언급된 생성된 스레드이다. TTS 통신을 대신 작업하게 된다.
 * mb_checkSceneReady                           작업이 다 끝났다면 true로 만들어 다른 스크립트에서 감지할 수 있게 해주는 변수이다.
 * 
 * - LoadVoice Member Function
 *
 * Start()                                      VoiceManager 게임 오브젝트가 생성될 때 최초로 실행되는 함수로, 인스펙터 창에 입력된 음성 세팅값들을 통해 씬에서 필요한 음성 데이터를 만든다.
 * isPlaying()                                  현재 AudioSource를 통해 음성이 출력되고 있는지 아닌지를 반환해주는 함수. 출력되고 있다면 true, 아니라면 false를 반환한다.
 * runThread()                                  mth_workThread 스레드의 TTS 처리 코드가 실행되는 함수. 작업된 float array 반환 값은 mquefa_queue 큐에 저장하게 된다.
 * CheckQueue()                                 이 코루틴을 통해 각각씬들의 작업단계를 정의한다.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class LoadVoice : MonoBehaviour {

    [System.Serializable]
    public struct VoiceInfo {
        [SerializeField]
        private TTS.Voice svt_voiceType;
        public TTS.Voice voiceType {
            set {
                svt_voiceType = value;
            }
            get {
                return svt_voiceType;
            }
        }      

        [SerializeField]
        private string sstr_words;
        public string words {
            set {
                sstr_words = value;
            }
            get {
                return sstr_words;
            }
        }
        [SerializeField]
        private float sf_pitch;
        public float pitch {
            set {
                sf_pitch = value;
            }
            get {
                return sf_pitch;
            }
        }
        [SerializeField]
        private string sf_speakingRate;
        public string speakingRate {
            set {
                sf_speakingRate = value;
            }
            get {
                return sf_speakingRate;
            }
        }
        [SerializeField]
        private AudioClip sac_voiceAudioClip;
        public AudioClip audioClip {
            set {
                sac_voiceAudioClip = value;
            }
            get {
                return sac_voiceAudioClip;
            }
        }
    }

    public VoiceInfo[] mvifl_setVoiceInfoList;
    private int mn_checkCurInx = 0;
    public int CurrentIndex {
        set {
            mn_checkCurInx = value;
            StartCoroutine(CheckQueue());
            mth_workThread = new Thread(new ParameterizedThreadStart(runThread));
            mth_workThread.Start(value);
        }
        get {
            return mn_checkCurInx;
        }
    }
    private bool mb_CheckLoadComplete = false;
    public bool CheckLoadComplete {
        set {
            mb_CheckLoadComplete = value;
        }
        get {
            return mb_CheckLoadComplete;
        }
    }
    private TTS mtts_getVoice;
    private Queue<float[]> mquefa_queue = new Queue<float[]>();
    private Thread mth_workThread;
    public bool mb_checkSceneReady = false;

    // TTS를 위한 클래스를 선언한다.
     void Awake() {
        mtts_getVoice = TTS.GetInstance();
    }

    // 큐를 한 프레임마다 검사를 하여 큐에 내용물이 있다면 AudioClip으로 만들고 없다면 대기하게 한다.
    IEnumerator CheckQueue() {
        while (true) {
            if(mquefa_queue.Count > 0) {
                var fa_convertFloatArray = mquefa_queue.Dequeue();
                
                AudioClip ac_createAudioClip = AudioClip.Create("audioContent", fa_convertFloatArray.Length, 1, 44100, false);

                ac_createAudioClip.SetData(fa_convertFloatArray, 0);
                mvifl_setVoiceInfoList[mn_checkCurInx].audioClip = ac_createAudioClip;
                mb_CheckLoadComplete = true;
                yield break;
            }
            yield return null;  // 한 프레임마다 검사.
        }
    }


    // 생성된 스레드가 작업해야 하는 일을 정의한 함수이다.(TTS 통신)
    private void runThread(object nLoadId) {
        float tempSpeakRate = 0.8f;
        int n_LoadIndex = (int)nLoadId;
        //load the audio clips to need...
        if (float.TryParse(mvifl_setVoiceInfoList[n_LoadIndex].speakingRate, out tempSpeakRate)) {
            mquefa_queue.Enqueue(mtts_getVoice.CreateAudio(mvifl_setVoiceInfoList[n_LoadIndex].words, mvifl_setVoiceInfoList[n_LoadIndex].voiceType, mvifl_setVoiceInfoList[n_LoadIndex].pitch, tempSpeakRate));
        } else {
            mquefa_queue.Enqueue(mtts_getVoice.CreateAudio(mvifl_setVoiceInfoList[n_LoadIndex].words, mvifl_setVoiceInfoList[n_LoadIndex].voiceType, mvifl_setVoiceInfoList[n_LoadIndex].pitch));
        }
    }
}
