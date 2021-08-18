using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{

    public VoiceManager mvm_VoiceManager;
    private bool mb_PlayFirstVoice = false;                                                                                         // 첫번째 나레이션의 실행 유무를 위한 flag

    public GameObject mg_WitchText;
    public GameObject vibrate;
    public Text mt_Text;
    // Start is called before the first frame update
    void Start()
    {
        mvm_VoiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
        mg_WitchText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!mb_PlayFirstVoice)
        {                                                             // 나레이션1 실행조건 검사
            mvm_VoiceManager.playVoice(0);                                                                                          // 나레이션1과 playVoice(0) 연결됨
            mb_PlayFirstVoice = true;
            Invoke("SecondEvent", 4f);
            Invoke("ThirdEvent", 8f);
            // 나레이션1 출력 완료 
        }
    }

    void StopVibrate()
    {
        vibrate.SetActive(false);
    }
    void SecondEvent()
    {
        mg_WitchText.SetActive(true);
    }

    void ThirdEvent()
    {
        mg_WitchText.SetActive(false);
        mt_Text.text = "\n       사실 그 할머니는 아이들을 잡아먹는 무서운 마녀였어요.        \n";
        mvm_VoiceManager.playVoice(1);                                                                                          // 나레이션1과 playVoice(0) 연결됨
    }
}
