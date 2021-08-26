using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeCountry : MonoBehaviour
{
    private VoiceManager mvm_VoiceManager;
    private CaptionControl cc;
    private string temp;
    public int mcc_langIndex = 0;
    private GameObject OnButton;
    private GameObject OffButton;
    public GameObject CaptionPanel;
    //public int mn_PlayVoiceIndex;

    void Start() {
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        cc = GameObject.Find("CaptionPanel").GetComponent<CaptionControl>();
        OnButton = GameObject.Find("On");
        OffButton = GameObject.Find("Off");
        CaptionPanel = GameObject.Find("CaptionPanel");
    }
    
    public void OnclickButton() {
        switch (this.gameObject.name) {
            case "korea": 
                Debug.Log("한국");
                mcc_langIndex = 0;
                OnButton.SetActive(false);
                OffButton.SetActive(false);
                CaptionPanel.SetActive(false);
                mvm_VoiceManager.stopVoice();
                mvm_VoiceManager.country = VoiceManager.Country.KR;
                mvm_VoiceManager.playVoice(cc.mn_VoiceIndex);
                temp = "";
                cc.mt_CaptionText.GetComponent<Text>().text = temp;
                //cc.gameObject.SetActive(true);
                break;
            case "usa": 
                Debug.Log("미국");
                mcc_langIndex = 1;
                OnButton.SetActive(true);
                OffButton.SetActive(true);
                mvm_VoiceManager.stopVoice();
                mvm_VoiceManager.country = VoiceManager.Country.EN;
                mvm_VoiceManager.playVoice(cc.mn_VoiceIndex);
                temp = mvm_VoiceManager.mlva_LanguageVoices[1].mvifl_setVoiceInfoList[cc.mn_VoiceIndex].words;
                cc.mt_CaptionText.GetComponent<Text>().text = temp;
                cc.gameObject.SetActive(true);
                break;
            case "japan": 
                Debug.Log("일본");
                mcc_langIndex = 2;
                OnButton.SetActive(true);
                OffButton.SetActive(true);
                mvm_VoiceManager.stopVoice();
                mvm_VoiceManager.country = VoiceManager.Country.JP;
                mvm_VoiceManager.playVoice(cc.mn_VoiceIndex);
                temp = mvm_VoiceManager.mlva_LanguageVoices[2].mvifl_setVoiceInfoList[cc.mn_VoiceIndex].words;
                cc.mt_CaptionText.GetComponent<Text>().text = temp;
                cc.gameObject.SetActive(true);
                break;
            case "china": 
                Debug.Log("중국");
                OnButton.SetActive(true);
                OffButton.SetActive(true);
                mcc_langIndex = 3;
                mvm_VoiceManager.stopVoice();
                mvm_VoiceManager.country = VoiceManager.Country.CN;
                mvm_VoiceManager.playVoice(cc.mn_VoiceIndex);
                temp = mvm_VoiceManager.mlva_LanguageVoices[3].mvifl_setVoiceInfoList[cc.mn_VoiceIndex].words;
                cc.mt_CaptionText.GetComponent<Text>().text = temp;
                cc.gameObject.SetActive(true);
                break;
        }       
    }
}
