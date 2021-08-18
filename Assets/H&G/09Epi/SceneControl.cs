using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{

    public VoiceManager mvm_VoiceManager;
    private bool mb_PlayFirstVoice = false;                                                                                         // ù��° �����̼��� ���� ������ ���� flag
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
        {                                                             // �����̼�1 �������� �˻�
            mvm_VoiceManager.playVoice(0);                                                                                          // �����̼�1�� playVoice(0) �����
            mb_PlayFirstVoice = true;                                                                                               // �����̼�1 ��� �Ϸ� 
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
        //{                    // �����̼�2���� ��� ������ ���������� �̵�
          //  mg_Popup.SetActive(true);                                                                                               // ���������� �̵��ϱ� ���� �Լ�
        //}
    }

    void StopVibrate()
    {
        vibrate.SetActive(false);
    }
}
