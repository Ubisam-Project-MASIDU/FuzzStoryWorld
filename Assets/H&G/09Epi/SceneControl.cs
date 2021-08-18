using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{

    public VoiceManager mvm_VoiceManager;
    private bool mb_PlayFirstVoice = false;                                                                                         // ù��° �����̼��� ���� ������ ���� flag
    private Animator fearAnimation;
    public GameObject mg_WitchText;
    public GameObject vibrate;
    public Text mt_Text;
    public bool hidestartflag = false;
    private SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        mvm_VoiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
        fearAnimation = GetComponent<Animator>();
        mg_WitchText.SetActive(false);
        render = GameObject.Find("Background").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!mb_PlayFirstVoice)
        {                                                             // �����̼�1 �������� �˻�
            mvm_VoiceManager.playVoice(0);
            Debug.Log("1");
            mb_PlayFirstVoice = true;
            Invoke("SecondEvent", 4f);
            Invoke("ThirdEvent", 8f);
            Invoke("FourthEvent", 12f);
            Invoke("ColorChange", 15f);
            // �����̼�1 ��� �Ϸ� 
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
        mt_Text.text = "\n       ��� �� �ҸӴϴ� ���̵��� ��ƸԴ� ������ ���࿴���.        \n";
        mvm_VoiceManager.playVoice(1);
        Debug.Log("3");// �����̼�1�� playVoice(0) �����
    }
    
    void FourthEvent()
    {
        mt_Text.text = "\n       ��ü�� Ŭ���ؼ� ���࿡�Էκ��� ������ �׷����� �����ּ���.        \n";
        hidestartflag = true;
    }

    void ColorChange()
    {
        render.color = new Color(85 / 255f, 85 / 255f, 85 / 255f, 255 / 255f);
    }

}
