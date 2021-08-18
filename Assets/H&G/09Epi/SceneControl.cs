using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{

    public VoiceManager mvm_VoiceManager;
    private bool mb_PlayFirstVoice = false;                                                                                         // ù��° �����̼��� ���� ������ ���� flag

    public GameObject mg_WitchText;
    public GameObject vibrate;
    public Text mt_Text;
    public bool hidestartflag = false;
    private SpriteRenderer background;
    private SpriteRenderer witch;
    // Start is called before the first frame update
    void Start()
    {
        mvm_VoiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();

        mg_WitchText.SetActive(false);
        background = GameObject.Find("Background").GetComponent<SpriteRenderer>();
        witch = GameObject.Find("witch").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!mb_PlayFirstVoice)
        {                                                             // 나레이션1 실행조건 검사
            mvm_VoiceManager.playVoice(0);
            mb_PlayFirstVoice = true;
            Invoke("SecondEvent", 4f);
            Invoke("ThirdEvent", 8f);
            Invoke("FourthEvent", 12f);
            Invoke("ColorChange", 16f);
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
        Debug.Log("2");
    }

    void ThirdEvent()
    {
        mg_WitchText.SetActive(false);
        mt_Text.text = "\n       사실 그 할머니는 아이들을 잡아먹는 무서운 마녀였어요.        \n";
        mvm_VoiceManager.playVoice(1);
        Debug.Log("3");// 나레이션1과 playVoice(0) 연결됨
    }

    void FourthEvent()
    {
        mt_Text.text = "\n       물체를 클릭해서 마녀에게로부터 헨젤과 그레텔을 숨겨주세요.        \n";
        Debug.Log("4");
    }

    void ColorChange()
    {
        background.color = new Color(85 / 255f, 85 / 255f, 85 / 255f, 255 / 255f);
        witch.color = new Color(85 / 255f, 85 / 255f, 85 / 255f, 255 / 255f);
        hidestartflag = true;
        Debug.Log("colorChange");
    }




}
