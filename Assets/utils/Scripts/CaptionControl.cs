using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptionControl : MonoBehaviour
{
    private VoiceManager mvm_VoiceManager;
    public int mn_langIndex = 9;
    private GameObject mg_CaptionPanel;
    public GameObject mt_CaptionText;
    public int mn_VoiceIndex = 99;
    string temp;
    private GameObject OnButton;
    private GameObject OffButton;

    void Start(){
        OnButton = GameObject.Find("On");
        OffButton = GameObject.Find("Off");
        mt_CaptionText = GameObject.Find("Caption");
        mvm_VoiceManager = GameObject.FindObjectOfType<VoiceManager>();
        mg_CaptionPanel = GameObject.Find("CaptionPanel");
        mn_langIndex = ((int)mvm_VoiceManager.country);
        temp = mvm_VoiceManager.mlva_LanguageVoices[mn_langIndex].mvifl_setVoiceInfoList[mn_VoiceIndex].words;
        ShowCaption();
    }

    public void ShowCaption(){
        if (mn_langIndex == 0){ //한국어 선택 -> 자막 없애기
            this.gameObject.SetActive(false);
            OnButton.SetActive(false);
            OffButton.SetActive(false);
        }
        else{
            mt_CaptionText.GetComponent<Text>().text = temp;
        }
    }
}
