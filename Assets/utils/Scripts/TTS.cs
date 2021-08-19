/*
 * - Name : TTS.cs
 * - Writer : 최대준
 * - Content : Text to Speech Class로, 디자인 패턴은 싱글톤 패턴을 이용하였다. 조금 무거운 클래스 이므로 하나의 인스턴스를 다른 오브젝트 클래스에서 재사용할 수 있도록 하기 위해서 싱글톤 패턴을 이용하였다.
 * 
 * - How to Use-
 * 1. VoiceManager라는 오브젝트를 프리팹으로 만들어두었다. 그것을 이용해서 쓰기만 하면 된다.
 * 2. TTS 클래스를 선언한다. ex) TTS mtts_testTTS;
 * 3. VoiceManager라는 클래스의 안을 살펴보자면,
 * 4. 아래의 쓰여진 TTS 클래스는 싱글톤 패턴이기 때문에 이미 사용중인 인스턴스가 있는지 확인하고 없으면 초기화한 인스턴스를 반환하는 함수를 호출한다. ex) mtts_textTTS = TTS.getInstance();
 * 5. VoiceManager는 인스펙터로 만들 보이스를 받아들이고 보이스를 TTS 클래스에서 구글 api를 통해서 float array 형태로 반환받게 된다.
 * 6. VoiceManager클래스는 float array형태로 받은 오디오 데이터를 AudioClip형태로 변환하여 가지고 있고, 클래스 안의 함수인 playVoice(id or name)함수를 통해서 음성을 씬에 출력하게 된다.
 *
 * - History -
 * 2021-07-19 : 구현
 * 2021-07-20 : 주석 처리
 * 2021-07-22 : createAudio() 함수의 반환 값을 AudioClip이 아닌 float Array 방식으로 바꾸었다.
 * 2021-07-27 : 피드백에 의한 주석 변경.
 * 2021-08-10 : 피드백 요구사항 변경에 의한 추가적인 기능 구현 (다양한 언어 지원 - 영어, 한국어, 일본어, 중국어) 및 주석 변경.
 *
 * - TTS Member Variable 
 *
 * ms_UseApiURL             Google TTS API 서버와 통신을 위한 URL 주소이다.
 * mstts_SetTtsApi          Google TTS API 서버와 통신하여 데이터를 주고 받기 위한 데이터 형식을 맞춰주는 클래스이다. 이 안에는 보이스의 종류, 음조, 음성으로 바꿀 텍스트 등 음서으로 바꾸기 위해서 필요로 하는 세팅 데이터가 설정된다. 이때 이 세팅을 저장하는 이너클래스가 존재하는데, 각각 SetTextToSpeech, 
 * instance                 이 함수는 아무래도 통신을 하는 클래스로써, 무겁다고 작성자가 판단이 되어 클래스의 인스턴스를 계속 생산하는 것이 아니라, 싱글톤 디자인 패턴을 이용하여 하나의 인스턴스만 생성하게 만들었다. 이렇게 하면, 클래스의 인스턴스를 하나만 생성하여 여러 오브젝트 클래스들이 재사용할 수 있게 된다.
 * 
 * - TTS Member Function
 *
 * TextToSpeechPost()       본 스크립트 코드의 클래스에서는 Rest API를 이용하여 Google TTS API와 통신하기 때문에 그에 필요한 통신 코드가 들어있는 함수이다.
 * ConvertByteToFloat()     통신을 통해 원하는 음성을 바이트 형태로 Google TTS API 서버에서 보내주게 되고, 우리는 그것을 AudioClip형태로 만들기 위해서 float형태로 변환시켜야 한다. 그 작업을 해주는 함수이다.
 * setInput()               통신에 필요한 음성 세팅 정보에 대해서 설정하는 함수이다. 여기서 설정하는 정보는 어떤 Text를 음성으로 변환할지를 설정해주는 함수이다.
 * setAudioConfig()         통신에 필요한 음성 세팅 정보에 대해서 설정하는 함수이다. 여기서 설정하는 정보는 음성의 음조, 말 빠르기를 어떻게 할지를 설정해주는 함수이다.
 * setVoice()               통신에 필요한 음성 세팅 정보에 대해서 설정하는 함수이다. 여기서 설정하는 정보는 Google TTS API에서 정해놓은 보이스 종류를 설정해주는 함수이다.
 * CreateAudio()            최종적으로 Google TTS API서버에서 받은 바이트 데이터를 float 데이터로 변환했었는데, 이것을 이용해서 유니티에서 이용할 수 있는 AudioClip으로 만드는 작업을 해주는 함수이다.(2021-07-22 updated, 아래에는 상세한 이유를 적었다.)
 *                          반환값을 AudioClip에서 float array 형태로 바꾸었다. 이 이유는, AudioClip을 다루려면, 메인 스레드가 다루어야 하기 때문이다. 
 *                          TTS 통신은 메인 스레드가 아닌 스레드에서 담당하도록 설계를 바꾸게 되었다. 그 이유는 메인 스레드에서 UI와 이 TTS 통신에 데이터 처리까지 맡게 되면, 부하가 커져서 화면이 멈추는 프리징 현상이 일어나게 되기 때문에 반환값을 바꾸어 메인 스레드가 아닌 스레드에서 처리하도록 바꾸었다.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System;



// TTS 클래스이다. Google TTS API서버와 통신하여 최종적으로 createAudio()함수를 통해서 AudioClip 클래스를 반환하게 된다.
public class TTS {
    //Google TTS API에서 세팅값으로 준 보이스 설정을 쓰기 편하게 enum형식으로 정리하였다. 이렇게 정의해놓으면, 유니티 인스펙터창에서 고를수 있어 편하다.
    public enum Voice {
        KR_FEMALE_A,
        KR_FEMALE_B,
        KR_MALE_A,
        KR_MALE_B,
        EN_FEMALE_A,
        EN_FEMALE_B,
        EN_MALE_A,
        EN_MALE_B,
        JP_FEMALE_A,
        JP_FEMALE_B,
        JP_MALE_A,
        JP_MALE_B,
        CN_FEMALE_A,
        CN_FEMALE_B,
        CN_MALE_A,
        CN_MALE_B

    }
        
    // 최종적으로 API서버와 통신하기 위한 데이터 형식을 정의하는 클래스이다. 안에도 클래스 형태로 있어서, 이를 Json형태로 변환하여 API서버가 원하는 형태로 요청을 보내게 된다.
    [System.Serializable]
    public class SetTextToSpeech {
        public SetInput input;
        public SetVoice voice;
        public SetAudioConfig audioConfig;
    }

    // 음성으로 바꿀 텍스트 데이터를 넣는 클래스로, 최종적으로 SetTextToSpeech클래스안에 들어가게 된다.
    [System.Serializable]
    public class SetInput {
        public string text;
    }

    // 음성의 커스텀 세팅 설정 데이터를 넣는 클래스로, 최종적으로 SetTextToSpeech클래스안에 들어가게 된다.
    [System.Serializable]
    public class SetVoice {
        public string languageCode;
        public string name;
        public string ssmlGender;
    }

    // 음성의 커스텀 세팅 설정 데이터를 넣는 클래스로, 최종적으로 SetTextToSpeech클래스안에 들어가게 된다.
    [System.Serializable]
    public class SetAudioConfig {
        public string audioEncoding;
        public float speakingRate;
        public float pitch;
        public int volumeGainDb;
    }

    // API 서버에서 요청에 대한 응답을 받는 클래스로, 스트링(바이트) 형태로 받게 된다. 이를 float 형태로 변환하고 우리가 원하는 형태인 AudioClip으로 변환하게 된다.
    [System.Serializable]
    public class GetContent {
        public string audioContent;
    }

    private string ms_UseApiURL = "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=AIzaSyANPEwOXAhoxpeYwpJQBUkZRew42sI9ECU";
    private SetTextToSpeech mstts_SetTtsApi;
    private static TTS instance = null;

    
    // TTS 생성자.
    /// <summary>
    /// TTS API와 통신을 정의하고 통신을 실행할 수 있는 클래스를 생성한다.
    /// </summary>
    /// <returns> TTS 클래스. </returns>
    public TTS() {
        mstts_SetTtsApi = new SetTextToSpeech();
    } 

    // TTS는 싱글톤 디자인 패턴을 이용할 거므로, 앞으로 이 정적 함수를 통해 TTS 클래스의 인스턴스를 가져온다.
    /// <summary>
    /// TTS API와 통신을 정의하고 통신을 실행할 수 있는 클래스를 하나의 인스턴스만 사용하기 위한 함수이다. (싱글톤 패턴 이용)
    /// </summary>
    /// <returns> TTS 클래스. </returns>
    public static TTS GetInstance() {
        // 만약 instance가 존재하지 않을 경우 새로 생성한다.
        if (instance is null) {
            instance = new TTS();
        }
        // instance를 반환한다.
        return instance;
    }

    //convert the received byte array to float array. And then, return float array..
    /// <summary>
    /// Google TTS API서버 통신을 수행하여 가져온 string 형태의 데이터를 byte 형태로, byte 형태를 float 형태로 바꾸어 반환하는 함수이다. 후에 이를 받아서 VoiceManager 클래스에서는 오디오 클립 형태로 유니티 씬에 넣어 사용할 수 있도록 한번 랩하게 된다.
    /// </summary>
    /// <returns> 사용자가 원했던 오디오 float array </returns>
    public float[] CreateAudio(string sTargetSpeech, Voice vTargetVoice, float fSetPitch = 0f, float fSpeakRate = 0.6f) {

        setAudioConfig(fSetPitch, fSpeakRate);
        setVoice(vTargetVoice);
        setInput(sTargetSpeech);

        //After request HttpWebRequest, save the returned data in string format. And pasing the Json only to need content.
        var s_APIRequestResultString = TextToSpeechPost(mstts_SetTtsApi);
        
        GetContent gc_ConvertStringToJson = JsonUtility.FromJson<GetContent>(s_APIRequestResultString);
    
        var ba_ConvertByteArray = Convert.FromBase64String(gc_ConvertStringToJson.audioContent);
        var fa_ConvertFloatArray = ConvertByteToFloat(ba_ConvertByteArray);

        return fa_ConvertFloatArray;
    }
    
    // 스트링형태로 받은 응답 데이터를 우리가 원하는 float형태로 만들어 준다.
    /// <summary>
    /// byte형태의 데이터를 16비트 형태의 int형 데이터로 변환하고 32768를 나누어 float로 변환하여 저장한다.
    /// </summary>
    /// <returns> 사용자가 원했던 오디오 float array </returns>
    private static float[] ConvertByteToFloat(byte[] baArray) {
        float[] fa_ResultFloatArr = new float[baArray.Length / 2];

        for(int i = 0; i < fa_ResultFloatArr.Length; i++) {
            fa_ResultFloatArr[i] = BitConverter.ToInt16(baArray, i*2) / 32768.0f;
        }
        return fa_ResultFloatArr;
    }
    
    // REST API를 통해 Google TTS API서버와 통신하는 코드이다.
    /// <summary>
    /// Google TTS API서버 통신을 수행하는 과정을 정의한 함수로, Google TTS API 서버에 우리가 원하는 음성 데이터 정보를 정의한 클래스를 Json 형태로 보내면, string 형태의 Json 음성 데이터를 API 서버에서 보내주게 된다.
    /// </summary>
    /// <returns> 사용자가 원했던 오디오 Json 데이터 </returns>
    private string TextToSpeechPost(object oSettingData) {
        //use JsonUtility. convert byte[] to send this string..
        // 제이슨 직관성있게 oSendDate 수정. (PostMan)
        string s_ConvertSettingDataToJson = JsonUtility.ToJson(oSettingData);
        var b_ConvertSettingJsonDataToBytes = System.Text.Encoding.UTF8.GetBytes(s_ConvertSettingDataToJson);

        //set address to request..
        HttpWebRequest hwr_RequestApi = (HttpWebRequest)WebRequest.Create(ms_UseApiURL);
        hwr_RequestApi.Method = "POST";
        hwr_RequestApi.ContentType = "application/json";
        hwr_RequestApi.ContentLength = b_ConvertSettingJsonDataToBytes.Length;

        //send this data in Stream form.
        try {
            using (var stream = hwr_RequestApi.GetRequestStream()) {
                stream.Write(b_ConvertSettingJsonDataToBytes, 0, b_ConvertSettingJsonDataToBytes.Length);
                stream.Flush();
                stream.Close();
            }

            //receiving the response data to request data in StreamReader format. 
            HttpWebResponse hwr_ReceiveResponse = (HttpWebResponse)hwr_RequestApi.GetResponse();
            //read stream to StreamReader
            StreamReader sr_ReadStream = new StreamReader(hwr_ReceiveResponse.GetResponseStream());
            //convert stream data to string format.
            string s_OutputJson = sr_ReadStream.ReadToEnd();
            Debug.Log(s_OutputJson);
            return s_OutputJson;
        } catch (WebException e) {
            using (WebResponse response = e.Response) {
                HttpWebResponse httpResponse = (HttpWebResponse) response;
                Debug.Log(httpResponse.StatusCode);
                using (Stream data = response.GetResponseStream())
                using (var reader = new StreamReader(data)) {
                    string text = reader.ReadToEnd();
                }
            }
            return null;
        }
    }

    // 이 아래 코드는 클래스 앞부분에서 보았던 음성 세팅 설정들을 설정해주는 함수이다.
    /// <summary>
    /// TTS APi 서버에 보낼 데이터를 정의한다. 이 함수에서는 음성으로 바꿀 텍스트를 넣게 된다.
    /// </summary>
    private void setInput(string sTargetSpeech) {
        SetInput si_setInputData = new SetInput();
        si_setInputData.text = sTargetSpeech;
        mstts_SetTtsApi.input = si_setInputData;
    }

    /// <summary>
    /// TTS APi 서버에 보낼 데이터를 정의한다. 이 함수에서는 음성의 높낮이, 말빠르기 등 음성 자체를 커스터마이징할 수 있도록 정의한다.
    /// </summary>
    private void setAudioConfig(float fSetPitch, float fSpeakRate) {
        SetAudioConfig sa_setAudioConf = new SetAudioConfig();
        sa_setAudioConf.audioEncoding = "LINEAR16";
        sa_setAudioConf.speakingRate = fSpeakRate;
        sa_setAudioConf.pitch = fSetPitch;
        sa_setAudioConf.volumeGainDb = 0;
        mstts_SetTtsApi.audioConfig = sa_setAudioConf;
    }

    /// <summary>
    /// TTS APi 서버에 보낼 데이터를 정의한다. 이 함수에서는 음성의 베이스 국적을 입력하게 된다. 여기서는 현재 작성자가 정의한 한국, 일본, 중국, 영어의 형태만을 정의하였다.
    /// </summary>
    private void setVoice(Voice srcVoice) {
        SetVoice sv_setVoiceConf = new SetVoice();
        // TTS API의 목소리를 커스터마이징하는 세팅을 정의한다. 국적과 성별을 정의한다.
        switch(srcVoice) {
            // 한국어 여성 A 목소리를 정의한다.
            case Voice.KR_FEMALE_A:
                sv_setVoiceConf.languageCode = "ko-KR";
                sv_setVoiceConf.name = "ko-KR-Wavenet-A";
                sv_setVoiceConf.ssmlGender = "FEMALE";
                break;
            // 한국어 여성 B 목소리를 정의한다.
            case Voice.KR_FEMALE_B:
                sv_setVoiceConf.languageCode = "ko-KR";
                sv_setVoiceConf.name = "ko-KR-Wavenet-B";
                sv_setVoiceConf.ssmlGender = "FEMALE";
                break;
            // 영어 여성 A 목소리를 정의한다.
            case Voice.EN_FEMALE_A:
                sv_setVoiceConf.languageCode = "en-US";
                sv_setVoiceConf.name = "en-US-Wavenet-C";
                sv_setVoiceConf.ssmlGender = "FEMALE";
                break;
            // 영어 여성 B 목소리를 정의한다.
            case Voice.EN_FEMALE_B:
                sv_setVoiceConf.languageCode = "en-US";
                sv_setVoiceConf.name = "en-US-Wavenet-E";
                sv_setVoiceConf.ssmlGender = "FEMALE";
                break;
            // 일본어 여성 A 목소리를 정의한다.
            case Voice.JP_FEMALE_A:
                sv_setVoiceConf.languageCode = "ja-JP";
                sv_setVoiceConf.name = "ja-JP-Wavenet-A";
                sv_setVoiceConf.ssmlGender = "FEMALE";
                break;
            // 일본어 여성 B 목소리를 정의한다.
            case Voice.JP_FEMALE_B:
                sv_setVoiceConf.languageCode = "ja-JP";
                sv_setVoiceConf.name = "ja-JP-Wavenet-B";
                sv_setVoiceConf.ssmlGender = "FEMALE";
                break;
            // 중국어 여성 A 목소리를 정의한다.
            case Voice.CN_FEMALE_A:
                sv_setVoiceConf.languageCode = "cmn-CN";
                sv_setVoiceConf.name = "cmn-CN-Wavenet-A";
                sv_setVoiceConf.ssmlGender = "FEMALE";
                break;
            // 중국어 여성 B 목소리를 정의한다.
            case Voice.CN_FEMALE_B:
                sv_setVoiceConf.languageCode = "cmn-CN";
                sv_setVoiceConf.name = "cmn-CN-Wavenet-D";
                sv_setVoiceConf.ssmlGender = "FEMALE";
                break;
            // 한국어 남성 A 목소리를 정의한다.
            case Voice.KR_MALE_A:
                sv_setVoiceConf.languageCode = "ko-KR";
                sv_setVoiceConf.name = "ko-KR-Wavenet-C";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
            // 한국어 남성 B 목소리를 정의한다.
            case Voice.KR_MALE_B:
                sv_setVoiceConf.languageCode = "ko-KR";
                sv_setVoiceConf.name = "ko-KR-Wavenet-D";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
            // 영어 남성 A 목소리를 정의한다.
            case Voice.EN_MALE_A:
                sv_setVoiceConf.languageCode = "en-US";
                sv_setVoiceConf.name = "en-US-Wavenet-A";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
            // 영어 남성 B 목소리를 정의한다.
            case Voice.EN_MALE_B:
                sv_setVoiceConf.languageCode = "en-US";
                sv_setVoiceConf.name = "en-US-Wavenet-B";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;   
            // 일본어 남성 A 목소리를 정의한다.
            case Voice.JP_MALE_A:
                sv_setVoiceConf.languageCode = "ja-JP";
                sv_setVoiceConf.name = "ja-JP-Wavenet-C";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
            // 일본어 남성 B 목소리를 정의한다.
            case Voice.JP_MALE_B:
                sv_setVoiceConf.languageCode = "ja-JP";
                sv_setVoiceConf.name = "ja-JP-Wavenet-D";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
            // 중국어 남성 A 목소리를 정의한다.
            case Voice.CN_MALE_A:
                sv_setVoiceConf.languageCode = "cmn-CN";
                sv_setVoiceConf.name = "cmn-CN-Wavenet-B";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
            // 중국어 남성 B 목소리를 정의한다.
            case Voice.CN_MALE_B:
                sv_setVoiceConf.languageCode = "cmn-CN";
                sv_setVoiceConf.name = "cmn-CN-Wavenet-C";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
        }
        mstts_SetTtsApi.voice = sv_setVoiceConf;
    }
}