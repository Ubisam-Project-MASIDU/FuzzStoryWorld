using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoice : MonoBehaviour {

    public int mn_PlayVoiceIndex = 0;
    private VoiceManager mvm_VoiceManager;
    private bool mb_PlayOnce = false;
    
    void Start() {
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
    }

    
    void Update() {
        if (!mb_PlayOnce) {
            mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);
            mb_PlayOnce = true;
        }
    }
}
