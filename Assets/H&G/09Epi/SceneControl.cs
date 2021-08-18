using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{

    public VoiceManager mvm_VoiceManager;
    private bool mb_PlayFirstVoice = false;                                                                                         // 첫번째 나레이션의 실행 유무를 위한 flag
    private bool mb_PlaySecondVoice = false;
    private bool mb_WitchTextFlag = false;
    public GameObject mg_WitchText;
    public GameObject vibrate;
    // Start is called before the first frame update
    void Start()
    {
        mvm_VoiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
        mg_WitchText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mvm_VoiceManager.mb_checkSceneReady && !mb_PlayFirstVoice)
        {                                                             // 나레이션1 실행조건 검사
            mvm_VoiceManager.playVoice(0);                                                                                          // 나레이션1과 playVoice(0) 연결됨
            mb_PlayFirstVoice = true;                                                                                               // 나레이션1 출력 완료 
        }

        if (mvm_VoiceManager.isPlaying() == false && mb_PlayFirstVoice)
        {
            mg_WitchText.SetActive(true);
            mb_WitchTextFlag = true;
            Invoke("mg_PopUp", 2f);
        }

        if (mb_WitchTextFlag && !mb_PlaySecondVoice)
        {
           
        }

        //if (mvm_VoiceManager.isPlaying() == false && mvm_VoiceManager.mb_checkSceneReady && mb_PlaySecondVoice)
        //{                    // 나레이션2까지 출력 끝나면 다음씬으로 이동
          //  mg_Popup.SetActive(true);                                                                                               // 다음씬으로 이동하기 위한 함수
        //}
    }

    void StopVibrate()
    {
        vibrate.SetActive(false);
    }
}
