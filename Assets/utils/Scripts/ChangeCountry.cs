using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeCountry : MonoBehaviour
{
    private VoiceManager mvm_VoiceManager;
    private CaptionControl cc;
    private string temp;
    public int mn_PlayVoiceIndex;

    void Start() {
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        cc = GameObject.Find("CaptionPanel").GetComponent<CaptionControl>();
    }
    
    public void OnclickButton() {
        switch (this.gameObject.name) {
            case "korea": 
                Debug.Log("한국");
                mvm_VoiceManager.stopVoice();
                mvm_VoiceManager.country = VoiceManager.Country.KR;
                mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);
                temp = "";
                cc.mt_CaptionText.GetComponent<Text>().text = temp;
                //cc.gameObject.SetActive(true);
                break;
            case "usa": 
                Debug.Log("미국");
                mvm_VoiceManager.stopVoice();
                mvm_VoiceManager.country = VoiceManager.Country.EN;
                mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);
                temp = mvm_VoiceManager.mlva_LanguageVoices[1].mvifl_setVoiceInfoList[cc.mn_VoicIndex].words;
                cc.mt_CaptionText.GetComponent<Text>().text = temp;
                cc.gameObject.SetActive(true);
                break;
            case "japan": 
                Debug.Log("일본");
                mvm_VoiceManager.stopVoice();
                mvm_VoiceManager.country = VoiceManager.Country.JP;
                mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);
                temp = mvm_VoiceManager.mlva_LanguageVoices[2].mvifl_setVoiceInfoList[cc.mn_VoicIndex].words;
                cc.mt_CaptionText.GetComponent<Text>().text = temp;
                cc.gameObject.SetActive(true);
                break;
            case "china": 
                Debug.Log("중국");
                mvm_VoiceManager.stopVoice();
                mvm_VoiceManager.country = VoiceManager.Country.CN;
                mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);
                temp = mvm_VoiceManager.mlva_LanguageVoices[3].mvifl_setVoiceInfoList[cc.mn_VoicIndex].words;
                cc.mt_CaptionText.GetComponent<Text>().text = temp;
                cc.gameObject.SetActive(true);
                break;
        }       
    }
}
