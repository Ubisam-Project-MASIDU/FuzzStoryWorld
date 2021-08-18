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
        {                                                             // �����̼�1 �������� �˻�
            mvm_VoiceManager.playVoice(0);                                                                                          // �����̼�1�� playVoice(0) �����
            mb_PlayFirstVoice = true;
            Invoke("SecondEvent", 4f);
            Invoke("ThirdEvent", 8f);
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
    }

    void ThirdEvent()
    {
        mg_WitchText.SetActive(false);
        mt_Text.text = "\n       ��� �� �ҸӴϴ� ���̵��� ��ƸԴ� ������ ���࿴���.        \n";
        mvm_VoiceManager.playVoice(1);                                                                                          // �����̼�1�� playVoice(0) �����
    }
}
