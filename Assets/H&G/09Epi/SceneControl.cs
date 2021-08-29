using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{

    public VoiceManager mvm_VoiceManager;
    public CaptionControl cc;
    private bool mb_PlayFirstVoice = false;
    private bool mb_PlaySecondVoice = false;
    private bool mb_PlayThirdVoice = false;
    string temp;

    public GameObject mg_WitchText;
    public GameObject vibrate;
    public Text mt_Text;
    public bool hidestartflag = false;
    bool mb_ChangeColorOnce = false;
    private SpriteRenderer background;
    private SpriteRenderer witch;

    // Start is called before the first frame update
    void Start()
    {
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        cc = GameObject.Find("CaptionPanel").GetComponent<CaptionControl>();

        mg_WitchText.SetActive(false);
        background = GameObject.Find("Background").GetComponent<SpriteRenderer>();
        witch = GameObject.Find("witch").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!mb_PlayFirstVoice)
        {
            mvm_VoiceManager.playVoice(13); //그때무서운마녀가 나타났어요
            temp = mvm_VoiceManager.mlva_LanguageVoices[cc.mn_LangIndex].mvifl_setVoiceInfoList[13].words;
            cc.mt_CaptionText.GetComponent<Text>().text = temp;
            mb_PlayFirstVoice = true;
            Invoke("v_WitchText", 2.5f); //누가 내 집을 먹는게냐 텍스트
        }

        if (mvm_VoiceManager.isPlaying() == false && mb_PlayFirstVoice && !mb_PlaySecondVoice) //사실 그 마녀는 웅엥
        {
            mvm_VoiceManager.playVoice(14); //사실 그 할머니는 어쩌구
            cc.mn_VoiceIndex = 14;
            temp = mvm_VoiceManager.mlva_LanguageVoices[cc.mn_LangIndex].mvifl_setVoiceInfoList[14].words;
            cc.mt_CaptionText.GetComponent<Text>().text = temp;
            mb_PlaySecondVoice = true;
            mg_WitchText.SetActive(false);
            mt_Text.text = "\n       사실 그 할머니는 아이들을 잡아먹는 무서운 마녀였어요.        \n";

        }

        if (mvm_VoiceManager.isPlaying() == false && mb_PlaySecondVoice && !mb_PlayThirdVoice)
        {
            //mvm_VoiceManager.playVoice(18);
            if (PlayerPrefs.GetInt("SkipGame") == 0)
            {
                mvm_VoiceManager.playVoice(15);
                cc.mn_VoiceIndex = 15;
                temp = mvm_VoiceManager.mlva_LanguageVoices[cc.mn_LangIndex].mvifl_setVoiceInfoList[15].words;
                cc.mt_CaptionText.GetComponent<Text>().text = temp;
                mt_Text.text = "\n       물체를 클릭해서 마녀에게로부터 헨젤과 그레텔을 숨겨주세요.        \n";
                mb_PlayThirdVoice = true;
            }
            if(mb_ChangeColorOnce == false)
            {
                mb_ChangeColorOnce = true;
                Invoke("ColorChange", 2f);
            }
        }

        /*if (mvm_VoiceManager.isPlaying() == false && mb_PlayThirdVoice)
            if (!mb_PlayFirstVoice)
            {                                                             // 나레이션1 실행조건 검사
                mvm_VoiceManager.playVoice(15); //그때무서운마녀가 나타났어요
                mb_PlayFirstVoice = true;
                Invoke("SecondEvent", 4f);
                Invoke("ThirdEvent", 8f);
                Invoke("FourthEvent", 12f);
                Invoke("ColorChange", 14f);
                // 나레이션1 출력 완료 
            }
        }*/
    }
    void ColorChange()
    {
        background.color = new Color(75 / 255f, 75 / 255f, 75 / 255f, 255 / 255f);
        witch.color = new Color(85 / 255f, 85 / 255f, 85 / 255f, 255 / 255f);
        hidestartflag = true;
        Debug.Log("colorChange");
    }
}
        /*if (!mb_PlayFirstVoice)
        {                                                             // 나레이션1 실행조건 검사
            mvm_VoiceManager.playVoice(17);
            mb_PlayFirstVoice = true;
            Invoke("SecondEvent", 4f);
        }

        if (mvm_VoiceManager.isPlaying() == false && mb_PlayFirstVoice && !mb_PlaySecondVoice)
        {
            mvm_VoiceManager.playVoice(18);
            mb_PlaySecondVoice = true;
            ThirdEvent();

            // 나레이션1 출력 완료 
        }

        if (mvm_VoiceManager.isPlaying() == false && mb_PlaySecondVoice)
        {
            FourthEvent();
            Invoke("ColorChange", 2f);
        }

    
    void StopVibrate()
    {
        vibrate.SetActive(false);
    }
    void v_WitchText()
    {
        mg_WitchText.SetActive(true);
        Debug.Log("2");
    }

    void ThirdEvent()
    {
        mg_WitchText.SetActive(false);
        mt_Text.text = "\n       사실 그 할머니는 아이들을 잡아먹는 무서운 마녀였어요.        \n";
        //mvm_VoiceManager.playVoice(18);
        Debug.Log("3");// 나레이션1과 playVoice(0) 연결됨
    }

    void FourthEvent()
    {
        mvm_VoiceManager.playVoice(18);
        mt_Text.text = "\n       물체를 클릭해서 마녀에게로부터 헨젤과 그레텔을 숨겨주세요.        \n";
        Debug.Log("4");
    }
    

    void ColorChange()
    {
        background.color = new Color(75 / 255f, 75 / 255f, 75 / 255f, 255 / 255f);
        witch.color = new Color(85 / 255f, 85 / 255f, 85 / 255f, 255 / 255f);
        hidestartflag = true;
        Debug.Log("colorChange");
    }
}*/
