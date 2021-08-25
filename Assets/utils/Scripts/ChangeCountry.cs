using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeCountry : MonoBehaviour
{
    private VoiceManager mvm_VoiceManager;
    public int mn_PlayVoiceIndex;

    void Start() {
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
    }
    
    public void OnclickButton() {
        switch (this.gameObject.name) {
            case "korea": 
                Debug.Log("한국");
                mvm_VoiceManager.stopVoice();
                mvm_VoiceManager.country = VoiceManager.Country.KR;
                mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);
                break;
            case "usa": 
                Debug.Log("미국");
                mvm_VoiceManager.stopVoice();
                mvm_VoiceManager.country = VoiceManager.Country.EN;
                mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);            
                break;
            case "japan": 
                Debug.Log("일본");
                mvm_VoiceManager.stopVoice();
                mvm_VoiceManager.country = VoiceManager.Country.JP;
                mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);             
                break;
            case "china": 
                Debug.Log("중국");
                mvm_VoiceManager.stopVoice();
                mvm_VoiceManager.country = VoiceManager.Country.CN;
                mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);       
                break;
        }       
    }
}
